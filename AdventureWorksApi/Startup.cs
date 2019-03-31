using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AdventureWorksApi.EF.Context;
using AdventureWorksApi.Interfaces;
using AdventureWorksApi.Mappers;
using AdventureWorksApi.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace AdventureWorksApi
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


            //string connection = "Server=(LocalDB)\\MSSQLLocalDB;Database=AdventureWorks2014;Trusted_Connection=True;MultipleActiveResultSets=true";
            //services.AddDbContext<AdventureWorksContext>(options => options.UseSqlServer(connection));


            //string connection = "Data Source=training-sql-server-raman.database.windows.net;Initial Catalog=task-sql-db;User ID=raman;Password=7502974Hjvbr;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //services.AddDbContext<AdventureWorksContext>(options => options.UseSqlServer(connection));

            services.AddDbContext<AdventureWorksContext>(options =>
options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IAdressService, AddressService>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AdventureWorksMappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
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

            
            app.UseSwagger();

           
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();
        }
       
    }
}
