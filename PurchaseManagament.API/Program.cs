using Autofac.Extensions.DependencyInjection;
using Autofac;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PurchaseManagament.API.DependencyInjection;
using PurchaseManagament.API.Filters;
using PurchaseManagament.API.Middleware;
using PurchaseManagament.Application.Concrete.AutoMapper;
using PurchaseManagament.Application.Concrete.Validators.CompanyDepartman;
using PurchaseManagament.Persistence.Abstract.Repository;
using PurchaseManagament.Persistence.Abstract.UnitWork;
using PurchaseManagament.Persistence.Concrete.Context;
using PurchaseManagament.Persistence.Concrete.Repositories;
using PurchaseManagament.Persistence.Concrete.UnitWork;
using Serilog;
using PurchaseManagament.Application.Concrete.Inteceptors;

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
    //opt.Filters.Add(new ControllingProps());

});


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutoFacİnterceptor());
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Swagger JWT arayüzü
builder.Services.AddJWTSwaggerService();

builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<PurchaseManagamentContext>(a => a.UseSqlServer(@"Server=.\SQLEXPRESS;Database=PURCHASEMANAGAMENT_DB;Trusted_Connection=True;TrustServerCertificate=True"));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<IUnitWork, UnitWork>();

//Services
builder.Services.AddDIServices();

//AutoMapper
builder.Services.AddAutoMapper(typeof(DomainToDto), typeof(RequestModelToDomain));

// Validators
builder.Services.AddValidatorsFromAssemblyContaining(typeof(CreateCompanyDepartmanValidator));
//builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

// JWT kimlik doðrulama servisini ekleme
builder.Services.AddAuthenticationService(builder);

var app = builder.Build();

//Requestleri loglayan / hatalı olanları loglayan
//app.UseRequestLoggingMiddleware("~\\..\\..\\LogSaves\\RequestLogsSaves\\requests.log");
//app.TrimPropertiesMiddleware();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//ajax bağlantı kobul işlemi
app.UseHttpsRedirection();
app.UseCors(options => { options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
app.UseAuthorization();

app.MapControllers();
app.UseStaticFiles();

app.Run();
