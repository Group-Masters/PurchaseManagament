using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Attributes;
using PurchaseManagament.Application.Concrete.Models.Dtos;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Employee;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Invoices;
using PurchaseManagament.Application.Concrete.Models.RequestModels.Request;
using PurchaseManagament.Application.Concrete.Validators.Employees;
using PurchaseManagament.Application.Concrete.Validators.Request;
using PurchaseManagament.Application.Concrete.Wrapper;
using PurchaseManagament.Application.Exceptions;
using PurchaseManagament.Domain.Abstract;
using PurchaseManagament.Domain.Entities;
using PurchaseManagament.Persistence.Abstract.UnitWork;
using PurchaseManagament.Persistence.Concrete.UnitWork;
using PurchaseManagament.Utils;
using PurchaseManagament.Utils.LogServices.LoginLogServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PurchaseManagament.Application.Concrete.Services
{
    [NullCheckParam]
    public class EmployeeService : IEmployeService
    {
        private readonly IUnitWork _uWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ILoggedService _loggedService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public EmployeeService(IMapper mapper, IUnitWork uWork, IConfiguration configuration, ILoggedService loggedService, IWebHostEnvironment hostEnvironment)
        {
            _mapper = mapper;
            _uWork = uWork;
            _configuration = configuration;
            _loggedService = loggedService;
            _hostingEnvironment = hostEnvironment;
        }

        [Validator(typeof(CreateEmployeeValidator))]
        public async Task<Result<long>> CreateEmployee(CreateEmployeeVM? createEmployeeVM)
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
            var password = RandomNumberUtils.CreateRandom(0, 999999);
            //şifre hashleme
            var hashedPassword = CipherUtils.EncryptString(_configuration["AppSettings:SecretKey"], password);

            var employeeEntity = _mapper.Map<Employee>(createEmployeeVM);
            var approvedEntity = _mapper.Map<EmployeeDetail>(createEmployeeVM);
            approvedEntity.Password = hashedPassword;
            employeeEntity.CompanyDepartment = entityCD;
            employeeEntity.EmployeeDetail = approvedEntity;
            _uWork.GetRepository<Employee>().Add(employeeEntity);
            _uWork.GetRepository<EmployeeDetail>().Add(approvedEntity);
            await _uWork.CommitAsync();
            SenderUtils.SendMail(approvedEntity.Email, "HESAP BİLGİLENDİRME", $"XYZ Holding giriş şifreniz {password} olarak kaydedilmiştir. ");
            _uWork.Dispose();
            result.Data = employeeEntity.Id;
            return result;


        }

        public async Task<Result<List<EmployeeDto>>> GetAllEmployes()
        {
            var result = new Result<List<EmployeeDto>>();
            var employeEntity = await _uWork.GetRepository<Employee>().GetAllAsync("EmployeeDetail", "CompanyDepartment.Department", "EmployeeRoles.Role");
            var employeDtos = _mapper.Map<List<EmployeeDto>>(employeEntity);
            result.Data = employeDtos;
            return result;
        }

        [Validator(typeof(GetByIdEmployeeValidator))]
        public async Task<Result<List<EmployeeDto>>> GetEmployeesByCompany(GetByIdVM getByIdVM)
        {
            var result = new Result<List<EmployeeDto>>();
            var employeEntity = await _uWork.GetRepository<Employee>().GetByFilterAsync(x => x.CompanyDepartment.CompanyId == getByIdVM.Id, "EmployeeDetail", "CompanyDepartment.Department", "EmployeeRoles.Role");
            var employeDtos = _mapper.Map<List<EmployeeDto>>(employeEntity);
            result.Data = employeDtos;
            return result;

        }

        //[Validator(typeof(GetByIdEmployeeValidator))] Validasyon yazılacak
        public async Task<Result<EmployeeDto>> GetEmployeeByIdentity(GetByIdentityVM getByIdVM)
        {
            var result = new Result<EmployeeDto>();
            var employeEntity = await _uWork.GetRepository<Employee>().GetSingleByFilterAsync(x => x.IdNumber == getByIdVM.IdentityNumber, "EmployeeDetail", "CompanyDepartment.Department", "EmployeeRoles.Role", "CompanyDepartment.Company");
            var employeDto = _mapper.Map<EmployeeDto>(employeEntity);
            result.Data = employeDto;
            return result;

        }

        [Validator(typeof(GetByIdEmployeeValidator))]
        public async Task<Result<EmployeeDto>> GetEmployeeById(GetByIdVM getByIdVM)
        {
            var result = new Result<EmployeeDto>();
            var employeEntity = await _uWork.GetRepository<Employee>().GetSingleByFilterAsync(x => x.Id == getByIdVM.Id, "EmployeeDetail", "CompanyDepartment.Department", "EmployeeRoles.Role", "CompanyDepartment.Company");
            var employeDto = _mapper.Map<EmployeeDto>(employeEntity);
            result.Data = employeDto;
            return result;

        }

        [Validator(typeof(LoginEmployeeValidator))]
        public async Task<Result<bool>> Login(LoginVM loginVM)
        {
            var result = new Result<bool>();
            var hashedPassword = CipherUtils.EncryptString(_configuration["AppSettings:SecretKey"], loginVM.Password);
            var existsEmployee = await _uWork.GetRepository<Employee>().GetSingleByFilterAsync
                (x => (x.EmployeeDetail.Email == loginVM.UsernameOrEmail || x.EmployeeDetail.Username == loginVM.UsernameOrEmail) && x.EmployeeDetail.Password == hashedPassword
                , "EmployeeDetail", "EmployeeRoles");
            result.Data = false;
            if (existsEmployee == null)

            {
                result.Success = false;
                result.Errors.Add("Şifreniz Kullanıcı Adınız Veya Mail Adresiniz Uyuşmamaktadır.");
                result.Errors.Add("Şifrenizi Unuttuysanız 0 (364) 888 00 88 İle İletişime Geçiniz.");

                return result;
            }
            if (existsEmployee.IsActive != true)
            {
                result.Success = false;
                result.Errors.Add("Kullanıcı Erişiminiz sınırlandırılmıştır bir hata olduğunu düşünüyorsanız yöneticinize başvurunuz.");
                return result;
            }
            if (existsEmployee.EmployeeRoles.IsNullOrEmpty())
            {
                result.Success = false;
                result.Errors.Add("Hesabınız kullanıma hazır değildir .Bir sorun olduğunu düşünüyorsanız yöneticinize başvurunuz.");
                return result;
            }

            // onay kodu gönderimi son aşamada tekrar acılacak
            var deger = RandomNumberUtils.CreateRandom(0, 999999);
            var employedetails = existsEmployee.EmployeeDetail;
            employedetails.ApprovedCode = deger;
            _uWork.GetRepository<EmployeeDetail>().Update(employedetails);
            var ok = await _uWork.CommitAsync();
            if (ok)
            {
                 //SenderUtils.SendMail(employedetails.Email, "GIRIS ISLEMLERI", $"Giriş Doğrulama Kodunuz : {employedetails.ApprovedCode}");              
            }
            else
            {
                throw new NotFoundException("Lütfen Daha sonra tekrar Deneyiniz");
            }
            result.Data = true;
            return result;
        }

        [Validator(typeof(CreateEmployeeValidator))]
        public async Task<Result<TokenDto>> Login2FK(LoginVM2 loginVM)
        {
            var result = new Result<TokenDto>();
            var existsEmployee = await _uWork.GetRepository<Employee>().GetSingleByFilterAsync
                (x => (x.EmployeeDetail.Email == loginVM.UsernameOrEmail || x.EmployeeDetail.Username == loginVM.UsernameOrEmail) && x.EmployeeDetail.ApprovedCode == loginVM.OkCode
                , "EmployeeDetail", "CompanyDepartment", "EmployeeRoles");
            if (existsEmployee == null)
            {
                throw new NotFoundException("Hatalı Giriş yaptınız.");
            }
            if (existsEmployee.IsActive != true)
            {
                throw new NotFoundException("Kullanıcı Erişiminiz sınırlandırılmıştır bir hata olduğunu düşünüyorsanız yöneticinize başvurunuz.");
            }
            var expireMinute = Convert.ToInt32(_configuration["Jwt:Expire"]);
            var tokenString = GenerateJwtToken(existsEmployee, existsEmployee.EmployeeRoles.ToList());
            var dtos = _mapper.Map<TokenDto>(existsEmployee);
            dtos.Token = tokenString;
            result.Data = dtos;
            // Txt Login Log
            TxtLogla txtLogla = new TxtLogla();
            await txtLogla.Logla(existsEmployee);
            return result;
        }


        [Validator(typeof(UpdateEmployeeValidator))]
        public async Task<Result<long>> UpdateEmployee(UpdateEmployeeVM updateEmployeeVM)
        {
            var result = new Result<long>();
            var entity = await _uWork.GetRepository<EmployeeDetail>().GetSingleByFilterAsync(x => x.EmployeeId == updateEmployeeVM.EmployeeId, "Employee");
            if (entity is null)
            {
                new NotFoundException("kullanıcı bulunamadı");

            }
            var ExistsAny = await _uWork.GetRepository<EmployeeDetail>().AnyAsync(x => x.Email == updateEmployeeVM.Email && x.EmployeeId != updateEmployeeVM.EmployeeId);
            if (ExistsAny)
            {
                throw new AlreadyExistsException($" {updateEmployeeVM.Email} adresi kullanılmaktadır.");
            }
            entity.Employee.IsActive = updateEmployeeVM.IsActive;
            var newEntity = _mapper.Map(updateEmployeeVM, entity);
            _uWork.GetRepository<EmployeeDetail>().Update(newEntity);
            await _uWork.CommitAsync();
            _uWork.Dispose();

            result.Data = newEntity.EmployeeId;
            return result;
        }

        [Validator(typeof(UpdatePasswordEmployeeValidator))]
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

        [Validator(typeof(GetByIdEmployeeValidator))]
        public async Task<Result<List<EmployeeDto>>> GetEmployeeIsActiveByCompany(GetByIdVM getByIdVM)
        {
            var result = new Result<List<EmployeeDto>>();
            var employeEntity = await _uWork.GetRepository<Employee>().GetByFilterAsync(x => x.CompanyDepartment.CompanyId == getByIdVM.Id && x.IsActive == true, "EmployeeDetail", "CompanyDepartment.Department", "EmployeeRoles.Role");
            var employeDtos = _mapper.Map<List<EmployeeDto>>(employeEntity);
            result.Data = employeDtos;
            return result;
        }

        [Validator(typeof(GetRequestByCIdDIdValidator))]
        public async Task<Result<List<EmployeeDto>>> GetEmployeeIsActiveByCIdDId(GetRequestByCIdDIdRM getByCIdDId)
        {
            var result = new Result<List<EmployeeDto>>();
            var employeEntity = await _uWork.GetRepository<Employee>().GetByFilterAsync(x => x.CompanyDepartment.CompanyId == getByCIdDId.CompanyId && x.CompanyDepartment.DepartmentId == getByCIdDId.DepartmentId
                && x.IsActive == true, "EmployeeDetail", "CompanyDepartment.Department");
            var employeDtos = _mapper.Map<List<EmployeeDto>>(employeEntity);
            result.Data = employeDtos;
            return result;
        }
        [Validator(typeof(GetByIdValidator))]
        public async Task<Result<bool>> SendPassword(GetByIdVM getByIdVM)
        {
            var result = new Result<bool>();
            var entity = await _uWork.GetRepository<EmployeeDetail>().GetSingleByFilterAsync(x => x.EmployeeId == getByIdVM.Id);
            var password = RandomNumberUtils.CreateRandom(0, 999999);
            SenderUtils.SendMail(entity.Email, "ŞİFRE İŞLEMLERİ", $"Talebiniz üzerine şifreniz sıfırlanmıştır . Şifreniz {password}");
            entity.Password = CipherUtils.EncryptString(_configuration["AppSettings:SecretKey"], password);
            _uWork.GetRepository<EmployeeDetail>().Update(entity);
            var data = await _uWork.CommitAsync();
            result.Data = data;
            return result; 
        }
        [Validator(typeof(CreateEmployeeImageValidator))]
        public async Task<Result<long>> CreateImg(CreateEmployeeImageVM createEmployeeImageVM)
        {
            var result = new Result<long>();
            var entity = await _uWork.GetRepository<EmployeeDetail>().GetSingleByFilterAsync(x => x.EmployeeId == createEmployeeImageVM.Id);
            if (entity is null)
            {
                throw new NotFoundException("kullanıcı Bulunamadı.");

            }
            //Dosyanın ismi belirleniyor.
            var fileName = PathUtil.GenerateFileNameFromBase64File(createEmployeeImageVM.ImageString);
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration["Paths:EmployeeImages"], fileName);

            //Base64 string olarak gelen dosya byte dizisine çevriliyor.
            var imageDataAsByteArray = Convert.FromBase64String(createEmployeeImageVM.ImageString);
            //byte dizisi FileStream'e yazmak üzere FileStream'e aktarılıyor.
            var ms = new MemoryStream(imageDataAsByteArray);
            ms.Position = 0;

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                ms.CopyTo(fs);
                fs.Close();
            }
            //Dosyanı yolu [Projenin kök dizininin yolu]+["images"]+"["product-images"]+["dosyanın adı.uzantısı"]


            //images/product-images/14_8_2023_21_56_39_987.png
            entity.ImageSrc = $"{_configuration["Paths:EmployeeImages"]}/{fileName}";

            _uWork.GetRepository<EmployeeDetail>().Update(entity);
            await _uWork.CommitAsync();
            result.Data = entity.Id;
            return result;
        }
       
         public async Task<Result<TokenDto>> LoginData(LoginVM loginData)
        {
            var result = new Result<TokenDto>();
            var hashedPassword = CipherUtils.EncryptString(_configuration["AppSettings:SecretKey"], loginData.Password);
            var existsEmployee = await _uWork.GetRepository<Employee>().GetSingleByFilterAsync
                (x => (x.EmployeeDetail.Email == loginData.UsernameOrEmail || x.EmployeeDetail.Username == loginData.UsernameOrEmail) && x.EmployeeDetail.Password == hashedPassword
                , "EmployeeDetail", "EmployeeRoles", "CompanyDepartment");
            if (existsEmployee == null)

            {
                result.Success = false;
                result.Errors.Add("Şifreniz Kullanıcı Adınız Veya Mail Adresiniz Uyuşmamaktadır.");
                result.Errors.Add("Şifrenizi Unuttuysanız 0 (364) 888 00 88 İle İletişime Geçiniz.");

                return result;
            }
            if (existsEmployee.IsActive != true)
            {
                result.Success = false;
                result.Errors.Add("Kullanıcı Erişiminiz sınırlandırılmıştır bir hata olduğunu düşünüyorsanız yöneticinize başvurunuz.");
                return result;
            }
            if (existsEmployee.EmployeeRoles.IsNullOrEmpty())
            {
                result.Success = false;
                result.Errors.Add("Hesabınız kullanıma hazır değildir .Bir sorun olduğunu düşünüyorsanız yöneticinize başvurunuz.");
                return result;
            }

            var expireMinute = Convert.ToInt32(_configuration["Jwt:Expire"]);
            var tokenString = GenerateJwtToken(existsEmployee, existsEmployee.EmployeeRoles.ToList());
            var dtos = _mapper.Map<TokenDto>(existsEmployee);
            dtos.Token = tokenString;
            result.Data = dtos;
            // Txt Login Log
            TxtLogla txtLogla = new TxtLogla();
            await txtLogla.Logla(existsEmployee);
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
                //Console.WriteLine(r.ToString());
            }
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        #endregion
    }
}
