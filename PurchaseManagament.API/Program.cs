using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PurchaseManagament.API.Filters;
using PurchaseManagament.API.Middleware;
using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.AutoMapper;
using PurchaseManagament.Application.Concrete.Models.RequestModels.CompanyDepartments;
using PurchaseManagament.Application.Concrete.Services;
using PurchaseManagament.Application.Concrete.Services.PDFServices;
using PurchaseManagament.Application.Concrete.Validators.CompanyDepartman;
using PurchaseManagament.Domain.Abstract;
using PurchaseManagament.Domain.Concrete;
using PurchaseManagament.Persistence.Abstract.Repository;
using PurchaseManagament.Persistence.Abstract.UnitWork;
using PurchaseManagament.Persistence.Concrete.Context;
using PurchaseManagament.Persistence.Concrete.Repositories;
using PurchaseManagament.Persistence.Concrete.UnitWork;
using Serilog;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Logging
var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();
Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration)
        .CreateLogger();

Log.Logger.Information("Program Started...");

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new ExceptionHandlerFilter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "JwtTokenWithIdentity", Version = "v1", Description = "JwtTokenWithIdentity test app" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
                    {
                        new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
    });
});

builder.Services.AddHttpContextAccessor();


builder.Services.AddDbContext<PurchaseManagamentContext>(a => a.UseSqlServer(@"Server=.\SQLEXPRESS;Database=PURCHASEMANAGAMENT_DB;Trusted_Connection=True;TrustServerCertificate=True"));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


builder.Services.AddScoped<IUnitWork, UnitWork>();
//servicess
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IReportService, ReportService>();

builder.Services.AddScoped<IDepartmentService, DepartmentService>();

builder.Services.AddScoped<ICompanyDepartmentService, CompanyDepartmentService>();
builder.Services.AddScoped<ICompanyStockService, CompanyStockService>();

builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddScoped<IEmployeService, EmployeeService>();
builder.Services.AddScoped<ILoggedService,LoggedUserService>();

builder.Services.AddScoped<IEmployeeRoleService, EmployeeRoleService>();

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IMeasuringUnitService, MeasuringUnitService>();

builder.Services.AddScoped<ISupplierService, SupplierService>();

// CurrencyService Eklendi
builder.Services.AddScoped<ICurrencyService, CurrencyService>();

// RequestService Eklendi
builder.Services.AddScoped<IRequestService, RequestService>();

builder.Services.AddScoped<IInvoiceService, InvoiceService>();

builder.Services.AddScoped<IOfferService, OfferService>();

// Stok Operasyon Service Eklendi
builder.Services.AddScoped<IStockOperationsService, StockOperationsService>();

// RequestToPDF Service Eklendi
builder.Services.AddScoped(typeof(ReportToPdfService));

// ImgProduct Service Eklendi
builder.Services.AddScoped<IImgProductService, ImgProductService>();

//AutoMapper
builder.Services.AddAutoMapper(typeof(DomainToDto), typeof(RequestModelToDomain));

// Validators Servieces
builder.Services.AddValidatorsFromAssemblyContaining(typeof(CreateCompanyDepartmanValidator));
//builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

// JWT kimlik doðrulama servisini ekleme
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
  {
        options.IncludeErrorDetails = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"], // Tokený oluþturan tarafýn adresi
            ValidAudience = builder.Configuration["Jwt:Audiance"], // Tokenýn kullanýlacaðý hedef adres
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SigningKey"])) // Gizli anahtar
        };
   });

var app = builder.Build();

// GlobalExceptionMiddleware With Log eklendi
app.UseMiddleware<GlobalExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//ajax bağlantı kobul işlemi
app.UseCors(options => { options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
app.UseAuthorization();

app.MapControllers();

app.Run();
