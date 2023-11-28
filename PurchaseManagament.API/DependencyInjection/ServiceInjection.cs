using PurchaseManagament.Application.Abstract.Service;
using PurchaseManagament.Application.Concrete.Services.PDFServices;
using PurchaseManagament.Application.Concrete.Services;
using PurchaseManagament.Domain.Abstract;
using PurchaseManagament.Domain.Concrete;

namespace PurchaseManagament.API.DependencyInjection
{
    public static class ServiceInjection
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services)
        {
            services.AddScoped<ICompanyService, CompanyService>();

            services.AddScoped<IReportService, ReportService>();

            services.AddScoped<IDepartmentService, DepartmentService>();

            services.AddScoped<ICompanyDepartmentService, CompanyDepartmentService>();

            services.AddScoped<ICompanyStockService, CompanyStockService>();

            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped<IEmployeService, EmployeeService>();

            services.AddScoped<ILoggedService, LoggedUserService>();

            services.AddScoped<IEmployeeRoleService, EmployeeRoleService>();

            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IMeasuringUnitService, MeasuringUnitService>();

            services.AddScoped<ISupplierService, SupplierService>();

            services.AddScoped<ICurrencyService, CurrencyService>();

            services.AddScoped<IRequestService, RequestService>();

            services.AddScoped<IInvoiceService, InvoiceService>();

            services.AddScoped<IOfferService, OfferService>();

            services.AddScoped<IStockOperationsService, StockOperationsService>();

            services.AddScoped(typeof(ReportToPdfService));

            services.AddScoped<IImgProductService, ImgProductService>();
            services.AddScoped<IChartService, ChartService>();

            return services;
        }
    }
}
