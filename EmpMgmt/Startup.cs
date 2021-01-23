using EmpMgmt.Business.Interface;
using EmpMgmt.Business.Manager;
using EmpMgmt.DAO.Entites;
using EmpMgmt.DataAccess.Interface;
using EmpMgmt.DataAccess.Repository;
using EmpMgmt.Mapper.Interface;
using EmpMgmt.Mapper.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmpMgmt
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
            services.AddCors(option => option.AddPolicy("GDPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
            }));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContextPool<GatewayDigitalContext>(item =>
                item.UseSqlServer(Configuration.GetConnectionString("EmpDBConnection"))
            );

            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDepartmentMapper, DepartmentMapper>();
            services.AddScoped<IDeptManager, DeptManager>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeMapper, EmployeeMapper>();
            services.AddScoped<IEmpManager, EmpManager>();

            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ILoginMapper, LoginMapper>();
            services.AddScoped<ILoginManager, LoginManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors("GDPolicy");
            app.UseMvc();
        }
    }
}