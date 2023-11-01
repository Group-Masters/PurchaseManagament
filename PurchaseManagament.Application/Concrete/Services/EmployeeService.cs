using AutoMapper;
using AutoMapper.Execution;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Application.Exceptions;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;
using PurchaseManagament.Utils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Application.Concrete.Services
{
    public class EmployeeService : IEmployeService
    {
        private readonly IUnitWork _uWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public EmployeeService(IMapper mapper, IUnitWork uWork, IConfiguration configuration)
        {
            _mapper = mapper;
            _uWork = uWork;
            _configuration = configuration;
        }

        public async Task<Result<long>> CreateEmployee(CreateEmployeeVM createEmployeeVM)
        {
            var result = new Result<Int64>();

            //tc kimlik numrası veya Email başka kullanıca bulunmaz
            var ExistsAny = await _uWork.GetRepository<EmployeeDetail>().AnyAsync(x => x.Email == createEmployeeVM.Email || x.Employee.IdNumber == createEmployeeVM.IdNumber);
            if (ExistsAny)
            {
                throw new AlreadyExistsException($" {createEmployeeVM.Email} adresi ya {createEmployeeVM.IdNumber} kimlik numaralı personel bulunmaktadır");
            }

            // kullanıcı somut olmalı hayalı olmamalı  tc kotrolü
            //var personControl = await IdentityUtils.TCControl(long.Parse(createEmployeeVM.IdNumber), createEmployeeVM.Name, createEmployeeVM.Surname, int.Parse(createEmployeeVM.BirthYear));

            //if (personControl == false)
            //{
            //    throw new NotFoundException("kimlik bilgileriniz Uyuşmamaktadır");
            //}
            //şifre hashleme
            var hashedPassword = CipherUtils.EncryptString(_configuration["AppSettings:SecretKey"], createEmployeeVM.Password);

            var employeeEntity = _mapper.Map<Employee>(createEmployeeVM);
            var approvedEntity = _mapper.Map<EmployeeDetail>(createEmployeeVM);


            employeeEntity.EmployeeDetail = approvedEntity;
            _uWork.GetRepository<Employee>().Add(employeeEntity);

            _uWork.GetRepository<EmployeeDetail>().Add(approvedEntity);


            await _uWork.CommitAsync();
            _uWork.Dispose();
            result.Data = employeeEntity.Id;
            return result;


        }

        public async Task<Result<List<EmployeeDto>>> GetAllEmployes()
        {
            var result = new Result<List<EmployeeDto>>();
            var employeEntity = await _uWork.GetRepository<Employee>().GetAllAsync("EmployeeDetail");
            foreach (var employee in employeEntity)
            {
                var a = employee.EmployeeDetail;
            }
            var employeDtos = _mapper.Map<List<EmployeeDto>>(employeEntity);
            result.Data = employeDtos;
            return result;
        }



        public Task<Result<EmployeeDto>> GetEmployee()
        {
            throw new NotImplementedException();
        }

        public async Task<Result<TokenDto>> Login(LoginVM loginVM)
        {

            var result = new Result<TokenDto>();
            var hashedPassword = CipherUtils.EncryptString(_configuration["AppSettings:SecretKey"], loginVM.Password);

            var existsEmployee = await _uWork.GetRepository<Employee>().GetSingleByFilterAsync
                (x => (x.EmployeeDetail.Email == loginVM.UsernameOrEmail || x.EmployeeDetail.Username == loginVM.UsernameOrEmail) && x.EmployeeDetail.Password == hashedPassword,"EmployeeDetail" );
            if (existsEmployee == null)
          
            {
                throw new NotFoundException("kullanıcı bulunamadı");
            }
            var companyEntity = await  _uWork.GetRepository<CompanyDepartment>().GetSingleByFilterAsync(x => x.Id == existsEmployee.CompanyDepartmentId);
            var role =await _uWork.GetRepository<EmployeeRole>().GetByFilterAsync(x => x.EmployeeId == existsEmployee.Id);
            var roleList=role.ToList();

            var expireMinute = Convert.ToInt32(_configuration["Jwt:Expire"]);
            //var expireDate = DateTime.Now.AddMinutes(expireMinute);
            var tokenString = GenerateJwtToken(existsEmployee, roleList);
         
            result.Data = new TokenDto
            {
                Id = existsEmployee.Id,
                CompanyId = companyEntity.CompanyId,
                DepartmentId = companyEntity.DepartmentId,
                RolId=roleList.Select(x=>x.RoleId).ToList(),
                Token = tokenString,

            };
            return result;
        }
        #region private methodlar
        private string GenerateJwtToken(Employee person,List<EmployeeRole> roles)
        {
            var secretkey = _configuration["Jwt:SigningKey"];
            var ıssuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audiance"];




            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secretkey); // appsettings.json içinde JWT ayarlarınızı yapmalısınız

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = audience,
                Issuer = ıssuer,
                

                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, person.EmployeeDetail.Email),
                    new Claim(ClaimTypes.Name, person.EmployeeDetail.Username),

                    new Claim(ClaimTypes.Sid, person.Id.ToString()),
                   
                    
                  
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            foreach (var r in roles)
            {
               tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, r.RoleId.ToString()));
            }

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        #endregion
    }
}
