using AutoMapper;
using Microsoft.Extensions.Configuration;
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
using System.Linq;
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
            var approvedEntity =_mapper.Map<EmployeeDetail>(createEmployeeVM);
                
                
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
            var result=new Result<List<EmployeeDto>>();
          var employeEntity= await _uWork.GetRepository<Employee>().GetAllAsync("EmployeeDetail");
         foreach (var employee in employeEntity)
            {
               var a= employee.EmployeeDetail;
            }
           var employeDtos=_mapper.Map<List<EmployeeDto>>(employeEntity);
            result.Data = employeDtos;
            return result;
        }

        public Task<Result<EmployeeDto>> GetEmployee(GetByIdVM CompanyId)
        {
            throw new NotImplementedException();
        }
    }
}
