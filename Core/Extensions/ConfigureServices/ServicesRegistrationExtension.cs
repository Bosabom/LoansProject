using Core.FieldValueValidation;
using Core.FieldValueValidation.Providers;
using Core.Interfaces.Core;
using Core.Interfaces.Core.CustomValidation;
using Core.Interfaces.Core.CustomValidation.Providers;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions.ConfigureServices
{
    public static class ServicesRegistrationExtension
    {
        public static IServiceCollection ConfigureCoreDependencies(this IServiceCollection services)
        {
            services.AddTransient<ILoanService, LoanService>();
            services.AddTransient<ILoanTemplateService, LoanTemplateService>();
            services.AddTransient<ICarBrandService, CarBrandService>();
            services.AddTransient<IFieldValueService, FieldValueService>();

            services.AddScoped<IFieldValueValidator, FieldValueValidator>();
            services.AddScoped<IValidatorProvider, ValidatorProvider>();
            services.AddScoped<IFieldOperationProvider, FieldOperationProvider>();
            services.AddScoped<IFieldValueProvider, FieldValueProvider>();
            services.AddScoped<ICalculatedFieldProvider, CalculatedFieldProvider>();

            return services;
        }
    }
}
