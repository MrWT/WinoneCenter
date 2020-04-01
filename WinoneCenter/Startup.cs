using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using WinoneCenter.Models;
using WinoneCenter.Services;

namespace WinoneCenter
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
            services.Configure<DBSettings>(Configuration.GetSection(nameof(DBSettings)));

            services.AddSingleton<IDBSettings>(sp => sp.GetRequiredService<IOptions<DBSettings>>().Value);

            #region AddSingleton Servcies
            services.AddSingleton<EmployeeService>();
            services.AddSingleton<CustomerService>();
            services.AddSingleton<LogService>();
            services.AddSingleton<ProductService>();
            services.AddSingleton<SupplierService>();
            #endregion

            services.AddMvc();

            // 註冊Swagger 生成器，定義一個和多個 Swagger 文檔
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo {
                    Version = "v1",
                    Title = "WinoneCenter API",
                    Description = "",
                    Contact = new OpenApiContact
                    {
                        Name = "WT Kuo",
                        Email = "waitingpa23@gmail.com",
                    },
                });                    
            });

            var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
            var xmlPath = Path.Combine(basePath, "WebApplicationCoreAPIStudy4.xml");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1_endpoint");
            });
        }
    }
}
