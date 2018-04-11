using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Travelers.CSS.ApprovalFlow.Repositories;
using Travelers.CSS.ApprovalFlow.Repositories.Interfaces;
using System.Linq.Expressions;
using Travelers.CSS.ApprovalFlow.Domain.Interfaces;
using Travelers.CSS.ApprovalFlow.Domain;
using Travelers.CSS.ApprovalFlow.DLL;
using Microsoft.EntityFrameworkCore;

namespace Travelers.CSS.ApprovalFlow
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
            //string connString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string connString = "Data Source = SUNIL-PC; Initial Catalog = Approval-Flow; User ID = sunil; Password = aditi123$";

            //Data Source = SUNIL - PC; Initial Catalog = ApprovalFlow; User ID = sunil; Password = ***********



            services.AddMvc();
            services.AddDbContext<ApprovalFlowDBContext>(options => options.UseSqlServer(connString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEmployeeDomainService, EmployeeDomainService>();
            services.AddScoped<IApprovalRuleDomainService, ApprovalRuleDomainService>();

           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                ApprovalFlowDBContext dbContext = serviceScope.ServiceProvider.GetRequiredService<ApprovalFlowDBContext>();
                dbContext.Database.Migrate();

                // TODO: Use dbContext if you want to do seeding etc.
            }
        }
    }
}
