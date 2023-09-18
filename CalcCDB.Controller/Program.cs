using CalcCDB.Domain.Interfaces;
using CalcCDB.Domain.Services;
using CalcCDB.Infrastructure.Interfaces;
using CalcCDB.Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;

namespace CalcCDB.Controller
{
    public class Program
    {
        protected Program() { }
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddSwaggerGe
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            ConfigureDependencyInjection(builder.Services);

            ConfigureSweggerGen(builder);

            ConfigureCors(builder);

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseCors("PolicyCors");

            app.UseAuthorization();

            app.MapControllers();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Api b3");
                options.RoutePrefix = string.Empty;
            });

            app.Run();

        }

        public static void ConfigureSweggerGen(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Api b3 - Calculo CDB",
                    Version = "v1",
                    Description = "Aplicação da fórmula VF = VI x [1 + (CDI x TB)]"
                });
            });
        }

        public static void ConfigureCors(WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("PolicyCors", app =>
                {
                    app.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
        }

        public static void ConfigureDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<ICdbConfigurationRepository, CdbConfigurationRepository>();
            services.AddScoped<ICdbService, CdbService>();
        }
    }
}