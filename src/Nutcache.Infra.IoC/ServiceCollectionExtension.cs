using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nutcache.Application.DTO;
using Nutcache.Application.Middlewares;
using Nutcache.Application.Queries.Handlers;
using Nutcache.Application.Validations;
using Nutcache.Infra.Data;
using Nutcache.Infra.Data.Repository;

namespace Nutcache.Infra.IoC
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddMediatR(typeof(EmployeeQueryHandler));
            services.AddAutoMapper(typeof(EmployeeDto));
            services.AddValidatorsFromAssemblyContaining<EmployeeDtoValidation>();
            services.AddFluentValidationAutoValidation();
            services.AddDbContext<NutcacheContext>(opt => opt.UseInMemoryDatabase("Nutcache"));
        }

        public static void RegisterMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandler>();
        }
    }
}