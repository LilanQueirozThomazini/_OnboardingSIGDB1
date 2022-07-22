using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Data.Repositories;
using OnboardingSIGDB1.Domain.AutoMapper;
using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Interfaces;
using OnboardingSIGDB1.Domain.Interfaces.Cargos;
using OnboardingSIGDB1.Domain.Interfaces.Empresas;
using OnboardingSIGDB1.Domain.Interfaces.Funcionarios;
using OnboardingSIGDB1.Domain.Interfaces.FuncionariosCargo;
using OnboardingSIGDB1.Domain.Notifications;
using OnboardingSIGDB1.Domain.Services.Cargos;
using OnboardingSIGDB1.Domain.Services.Empresas;
using OnboardingSIGDB1.Domain.Services.Funcionarios;
using OnboardingSIGDB1.Domain.Services.FuncionariosCargo;
using System;
using System.Linq;

namespace OnboardingSIGDB1.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            InicializaAutoMapper.Initialize();

            services.AddDbContext<DataContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("OnboardingSIGDB1.Data")));

            services.AddControllers();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


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

            services.AddScoped<IRemoverCargoService, RemoverCargoService>();
            services.AddScoped<IRemoverEmpresaService, RemoverEmpresaService>();
            services.AddScoped<IRemoverFuncionarioService, RemoverFuncionarioService>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OnboardingSIGDB1.API", Version = "v1" });
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) => {
                await next.Invoke();
                string method = context.Request.Method;
                var allowedMethodsToCommit = new string[] { "POST", "PUT", "DELETE", "PATCH" };

                if (!allowedMethodsToCommit.Contains(method))
                    return;

                var notificationContext = context.RequestServices.GetService<INotificationContext>();
                if (!notificationContext.HasNotifications)
                {
                    var unitOfWork = (IUnitOfWork)context.RequestServices.GetService(typeof(IUnitOfWork));
                    unitOfWork.Commit();
                }
            });



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OnboardingSIGDB1.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
