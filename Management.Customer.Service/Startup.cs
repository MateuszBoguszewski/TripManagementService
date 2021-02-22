using Management.Customer.Service.Application.Commands.AssignCustomerToTrip;
using Management.Customer.Service.Application.Commands.CreateCustomer;
using Management.Customer.Service.Application.Commands.EditCustomer;
using Management.Customer.Service.Application.Queries.GetAllCustomers;
using Management.Customer.Service.Domain;
using Management.Customer.Service.Infrastructure.DataAccess;
using Management.Customer.Service.Infrastructure.Domain;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Management.Customer.Service
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
            services.AddControllers();
            services.AddDbContext<CustomerDbContext>(
                options => options.UseSqlServer(this.Configuration.GetConnectionString("DbConnection")));

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddMediatR(typeof(CreateCustomerCommandHandler));
            services.AddMediatR(typeof(EditCustomerCommandHandler));
            services.AddMediatR(typeof(GetAllCustomersQueryHandler));
            services.AddMediatR(typeof(AssignCustomerToTripCommandHandler));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My CustomerManagement Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            scope.ServiceProvider.GetService<CustomerDbContext>().Database.EnsureCreated();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My CustomerManagement API V1");
            });
        }
    }
}
