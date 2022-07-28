using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnboardingSIGDB1.Domain.AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Services.Funcionarios;
using OnboardingSIGDB1.Domain.Services.Empresas;
using OnboardingSIGDB1.Domain.Services.Cargos;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;
using OnboardingSIGDB1.Domain.Interfaces.Empresas;
using OnboardingSIGDB1.Domain.Interfaces.Cargos;
using OnboardingSIGDB1.Domain.Interfaces.FuncionariosCargo;
using OnboardingSIGDB1.Domain.Services.FuncionariosCargo;
using OnboardingSIGDB1.Data.Repositories;
using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Notifications;
using AutoMapper;

namespace OnboardingSIGDB1.IOC
{
    public static class StartupIoc
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            InicializaAutoMapper.Initialize();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<DataContext>(x => x.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("OnboardingSIGDB1.Data")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<INotificationContext, NotificationContext>();

            services.AddScoped<IRepository<Cargo>, Repository<Cargo>>();
            services.AddScoped<IRepository<Empresa>, Repository<Empresa>>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IRepository<FuncionarioCargo>, Repository<FuncionarioCargo>>();

            services.AddScoped<IGravarCargoService, GravarCargoService>();
            services.AddScoped<IGravarEmpresaService, GravarEmpresaService>();
            services.AddScoped<IGravarFuncionarioService, GravarFuncionarioService>();
            services.AddScoped<IGravarFuncionarioCargoService, GravarFuncionarioCargoService>();

            services.AddScoped<IConsultarFuncionarioCargo, ConsultarFuncionarioCargo>();
            services.AddScoped<IConsultaFuncionario, ConsultaFuncionario>();

            services.AddScoped<IRemoverCargoService, RemoverCargoService>();
            services.AddScoped<IRemoverEmpresaService, RemoverEmpresaService>();
            services.AddScoped<IRemoverFuncionarioService, RemoverFuncionarioService>();


        }
    }
}
