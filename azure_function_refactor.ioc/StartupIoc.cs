using azure_function_refactor.dados.Contextos;
using azure_function_refactor.dados.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace azure_function_refactor.ioc
{
    public static class StartupIoc
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration["ConnectionString"]));

            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<ContentModelRepositorio>();
            services.AddScoped<MetadataRepositorio>();
        }
    }
}
