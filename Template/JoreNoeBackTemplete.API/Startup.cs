using Autofac;
using Autofac.Configuration;
using AutoMapper;
using Exceptionless;
using JoreNoe.Extend;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using JoreNoeBackTemplete.DomainService;

namespace JoreNoeBackTemplete.API
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ZerroMovies.API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            //添加Redis
            this.AddRedis(services, Configuration);
            this.AddAutoMapper(services);
            this.configJoreNoe(services);
            //添加Exceptionless
            this.AddExceptionless(services, Configuration);

            //启用定时
            this.EnableQuartz();
        }

        /// <summary>
        /// 配置JoreNoe数据库连接
        /// </summary>
        /// <param name="Services"></param>
        private void configJoreNoe(IServiceCollection Services)
        {
            //Register.AddJoreNoeEntityFrameworkSQLServer(Services);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var config = new ConfigurationBuilder();
            config.AddJsonFile("./Configs/Autofac.json");
            builder.RegisterModule(new ConfigurationModule(config.Build()));
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZerroMovies.API v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseExceptionless();

            app.UseAuthorization();

            this.UseAutoMapper(app);

            app.UseObjectToOBjectExtension();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
