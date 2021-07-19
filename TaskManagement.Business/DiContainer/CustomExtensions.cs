using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Business.Concrete;
using TaskManagement.Business.CustomLogger;
using TaskManagement.Business.Interfaces;
using TaskManagement.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using TaskManagement.DataAccess.Interfaces;

namespace TaskManagement.Business.DiContainer
{
   public static class CustomExtensions
    {
        public static void AddContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<IGorevService, GorevManager>();
            services.AddScoped<IAciliyetService, AciliyetManager>();
            services.AddScoped<IRaporService, RaporManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IDosyaService, DosyaManager>();
            services.AddScoped<IBildirimService, BildirimManager>();

            services.AddScoped<IGorevDal, EfGorevRepository>();
            services.AddScoped<IAciliyetDal, EfAciliyetRepository>();
            services.AddScoped<IRaporDal, EfRaporRepository>();
            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<IBildirimDal, EfBildirimRepository>();

            services.AddTransient<ICustomLogger, NLogLogger>();
        }
    }
}
