using CadastroMvc.Context;
using CadastroMvc.Identity;
using CadastroMvc.Identity.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CadastroMvc.Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection GetInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoles, SeedUserRoles>();

            services.AddIdentity<ApplicationUser, IdentityRole>().
                    AddEntityFrameworkStores<AppDbContext>().
                    AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(x => x.AccessDeniedPath = "/Account/Login");

            return services;
        }
    }
}
