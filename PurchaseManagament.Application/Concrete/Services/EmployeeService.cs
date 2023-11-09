using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Attributes;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Validators.Employees;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Application.Exceptions;
using PurchaseManagament.Domain.Abstract;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;
using PurchaseManagament.Utils;
using PurchaseManagament.Utils.LogServices.LoginLogServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PurchaseManagament.Application.Concrete.Services
{
    public class EmployeeService : IEmployeService
    {
        private readonly IUnitWork _uWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ILoggedService _loggedService;
        public EmployeeService(IMapper mapper, IUnitWork uWork, IConfiguration configuration, ILoggedService loggedService)
        {
            _mapper = mapper;
            _uWork = uWork;
            _configuration = configuration;
            _loggedService = loggedService;
        }

        //[Validator(typeof(CreateEmployeeValidator))]
        public async Task<Result<long>> CreateEmployee(CreateEmployeeVM createEmployeeVM)
        {
            var result = new Result<Int64>();

            //tc kimlik numrası veya Email başka kullanıca bulunmaz
            var ExistsAny = await _uWork.GetRepository<EmployeeDetail>().AnyAsync(x => x.Email == createEmployeeVM.Email || x.Employee.IdNumber == createEmployeeVM.IdNumber);
            if (ExistsAny)
            {
                throw new AlreadyExistsException($" {createEmployeeVM.Email} adresi ya {createEmployeeVM.IdNumber} kimlik numaralı personel bulunmaktadır");
            }
            var entityCD = await _uWork.GetRepository<CompanyDepartment>().GetSingleByFilterAsync(x => x.CompanyId == createEmployeeVM.CompanyId && x.DepartmentId == createEmployeeVM.DepartmentId);
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
            approvedEntity.Password = hashedPassword;
            employeeEntity.CompanyDepartment = entityCD;
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
            var employeEntity = await _uWork.GetRepository<Employee>().GetAllAsync("EmployeeDetail", "CompanyDepartment.Department");
            var employeDtos = _mapper.Map<List<EmployeeDto>>(employeEntity);
            foreach (var employee in employeDtos)
            {
                var b = await _uWork.GetRepository<EmployeeRole>().GetByFilterAsync(x => x.EmployeeId == employee.Id, "Role");
                if (b != null)
                {
                    employee.Roles = b.Select(x => x.Role.Name).ToList();
                }
            }
            result.Data = employeDtos;
            return result;
        }

        //[Validator(typeof(GetByIdEmployeeValidator))]
        public async Task<Result<List<EmployeeDto>>> GetEmployeesByCompany(GetByIdVM getByIdVM)
        {
            var result = new Result<List<EmployeeDto>>();
            var employeEntity = await _uWork.GetRepository<Employee>().GetByFilterAsync(x => x.CompanyDepartment.CompanyId == getByIdVM.Id, "EmployeeDetail", "CompanyDepartment.Department");
            var employeDtos = _mapper.Map<List<EmployeeDto>>(employeEntity);
            foreach (var employee in employeDtos)
            {
                var b = await _uWork.GetRepository<EmployeeRole>().GetByFilterAsync(x => x.EmployeeId == employee.Id, "Role");
                if (b != null)
                {
                    employee.Roles = b.Select(x => x.Role.Name).ToList();
                }
            }
            result.Data = employeDtos;
            return result;

        }

        //[Validator(typeof(GetByIdEmployeeValidator))]
        public async Task<Result<EmployeeDto>> GetEmployeeById(GetByIdVM getByIdVM)
        {
            var result = new Result<EmployeeDto>();
            var employeEntity = await _uWork.GetRepository<Employee>().GetSingleByFilterAsync(x => x.Id == getByIdVM.Id, "EmployeeDetail", "CompanyDepartment.Department");
            var employeDto = _mapper.Map<EmployeeDto>(employeEntity);
            var b = await _uWork.GetRepository<EmployeeRole>().GetByFilterAsync(x => x.EmployeeId == employeDto.Id, "Role");
            if (b != null)
            {
                employeDto.Roles = b.Select(x => x.Role.Name).ToList();
            }
            result.Data = employeDto;
            return result;

        }  
        
        public async Task<Result<bool>> Login(LoginVM loginVM)
        {
            var result = new Result<bool>();
            var hashedPassword = CipherUtils.EncryptString(_configuration["AppSettings:SecretKey"], loginVM.Password);
            var existsEmployee = await _uWork.GetRepository<Employee>().GetSingleByFilterAsync
                (x => (x.EmployeeDetail.Email == loginVM.UsernameOrEmail || x.EmployeeDetail.Username == loginVM.UsernameOrEmail) && x.EmployeeDetail.Password == hashedPassword
                , "EmployeeDetail");
            result.Data = false;
            if (existsEmployee == null)

            {
                result.Success = false;
                result.Errors.Add("Şifreniz Kullanıcı Adınız Veya Mail Adresiniz Uyuşmamaktadır.");
                return result;

            }
            if (existsEmployee.IsActive != true)
            {
                result.Success = false;
                result.Errors.Add("Kullanıcı Erişiminiz sınırlandırılmıştır bir hata olduğunu düşünüyorsanız yöneticinize başvurunuz.");
                return result;

                
            }

            // onay kodu gönderimi son aşamada tekrar acılacak
             //var deger = RandomNumberUtils.CreateRandom(0, 999999);
            var employedetails = existsEmployee.EmployeeDetail;
           // employedetails.ApprovedCode = deger;
           // _uWork.GetRepository<EmployeeDetail>().Update(employedetails);
           var ok= await _uWork.CommitAsync();
            if (ok)
            {
              //  SenderUtils.SendMail(employedetails.Email, "GIRIS ISLEMLERI", $"Giriş Doğrulama Kodunuz : {employedetails.ApprovedCode}");
            }
            else
            {
              
                throw new NotFoundException("Lütfen Daha sonra tekrar Deneyiniz");
            }
            result.Data = true;
            return result;
        }

        //[Validator(typeof(CreateEmployeeValidator))]
        public async Task<Result<TokenDto>> Login2FK (LoginVM2 loginVM)
        {
            var result = new Result<TokenDto>();
            var existsEmployee = await _uWork.GetRepository<Employee>().GetSingleByFilterAsync
                (x => (x.EmployeeDetail.Email == loginVM.UsernameOrEmail || x.EmployeeDetail.Username == loginVM.UsernameOrEmail) && x.EmployeeDetail.ApprovedCode == loginVM.OkCode
                , "EmployeeDetail");

            if (existsEmployee == null)

            {
                throw new NotFoundException("Hatalı Giriş yaptınız.");
            }
            if (existsEmployee.IsActive != true)
            {
                throw new NotFoundException("Kullanıcı Erişiminiz sınırlandırılmıştır bir hata olduğunu düşünüyorsanız yöneticinize başvurunuz.");
            }
            var companyEntity = await _uWork.GetRepository<CompanyDepartment>().GetSingleByFilterAsync(x => x.Id == existsEmployee.CompanyDepartmentId);
            var role = await _uWork.GetRepository<EmployeeRole>().GetByFilterAsync(x => x.EmployeeId == existsEmployee.Id);
            var roleList = role.ToList();

            var expireMinute = Convert.ToInt32(_configuration["Jwt:Expire"]);
            var tokenString = GenerateJwtToken(existsEmployee, roleList);

            result.Data = new TokenDto
            {
                Id = existsEmployee.Id,
                CompanyId = companyEntity.CompanyId,
                DepartmentId = companyEntity.DepartmentId,
                RolId = roleList.Select(x => x.RoleId).ToList(),
                Token = tokenString,

            };


            //Txt Login Log
            TxtLogla txtLogla = new TxtLogla();
                await txtLogla.Logla(existsEmployee);

            return result;
        }


        //[Validator(typeof(UpdateEmployeeValidator))]
        public async Task<Result<long>> UpdateEmployee(UpdateEmployeeVM updateEmployeeVM)
        {
            var result = new Result<long>();
            var entity = await _uWork.GetRepository<EmployeeDetail>().GetSingleByFilterAsync(x => x.EmployeeId == updateEmployeeVM.EmployeeId, "Employee");
            if (entity is null)
            {
                new NotFoundException("kullanıcı bulunamadı");
            }
            entity.Employee.IsActive = updateEmployeeVM.IsActive;
            var newEntity = _mapper.Map(updateEmployeeVM, entity);
            _uWork.GetRepository<EmployeeDetail>().Update(newEntity);
            await _uWork.CommitAsync();
            _uWork.Dispose();
            result.Data = newEntity.EmployeeId;
            return result;

        }

        //[Validator(typeof(UpdatePasswordEmployeeValidator))]
        public async Task<Result<long>> UpdateEmployeePassword(UpdatePasswordVM updatePasswordVM)
        {
            var result = new Result<long>();
            var existsEntity = await _uWork.GetRepository<EmployeeDetail>().GetSingleByFilterAsync(x => x.EmployeeId == _loggedService.UserId);
            if (existsEntity is null)
            {
                throw new NotFoundException("lütfen giriş yapınız");

            }
            var hashedPassword = CipherUtils.EncryptString(_configuration["AppSettings:SecretKey"], updatePasswordVM.Password);
            if (existsEntity.Password != hashedPassword)
            {
                throw new NotFoundException("şifre hatalı");
            }
            var hashedPassword2 = CipherUtils.EncryptString(_configuration["AppSettings:SecretKey"], updatePasswordVM.NewPassword);
            existsEntity.Password = hashedPassword2;
            _uWork.GetRepository<EmployeeDetail>().Update(existsEntity);
            await _uWork.CommitAsync();
            _uWork.Dispose();
            result.Data = existsEntity.Id;
            return result;
        }

        //[Validator(typeof(GetByIdEmployeeValidator))]
        public async Task<Result<List<EmployeeDto>>> GetEmployeeIsActiveByCompany(GetByIdVM getByIdVM)
        {
            var result = new Result<List<EmployeeDto>>();
            var employeEntity = await _uWork.GetRepository<Employee>().GetByFilterAsync(x => x.CompanyDepartment.CompanyId == getByIdVM.Id && x.IsActive == true, "EmployeeDetail", "CompanyDepartment.Department");
            var employeDtos = _mapper.Map<List<EmployeeDto>>(employeEntity);
            foreach (var employee in employeDtos)
            {
                var b = await _uWork.GetRepository<EmployeeRole>().GetByFilterAsync(x => x.EmployeeId == employee.Id, "Role");
                //employee.Roles =
                //b.ToList();
                if (b != null)
                {
                    employee.Roles = b.Select(x => x.Role.Name).ToList();
                }
            }
            result.Data = employeDtos;
            return result;
        }
        #region private methodlar
        private string GenerateJwtToken(Employee person, List<EmployeeRole> roles)
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
