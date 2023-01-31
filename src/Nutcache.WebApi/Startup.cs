using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Nutcache.Application.Validations;
using Nutcache.Infra.Data;
using Nutcache.Infra.IoC;
using System.Text.Json.Serialization;

namespace Nutcache.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<NutcacheContext>(opt => opt.UseInMemoryDatabase("Nutcache"));
            services.RegisterServices();
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.RegisterMiddlewares();
        }
    }
}
