using Core.Interfaces.Infrastructure;
using Infrastructure.Data;
using Infrastructure.Repositories.EFRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.ConfigureServices
{
    public static class ServicesRegistrationExtension
    {
        public static IServiceCollection ConfigureInfrastructureDependencies(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<ILoanTemplateRepository, LoanTemplateRepository>();
            services.AddTransient<ILoanRepository, LoanRepository>();
            services.AddTransient<IRepositoryProvider, RepositoryProvider>();
            services.AddTransient<ICarBrandRepository, CarBrandRepository>();
            services.AddTransient<IFieldValueRepository, FieldValueRepository>();
            services.AddTransient<IFieldRepository, FieldRepository>();
            return services;
        }
    }
}
