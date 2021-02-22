using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Management.Trip.Service.Domain;
using Management.Trip.Service.Infrastructure.Domain;
using Microsoft.OpenApi.Models;
using Management.Trip.Service.Application.Commands.CreateTrip;
using Management.Trip.Service.Infrastructure.DataAccess;
using MediatR;
using Management.Trip.Service.Application.Commands.CancelTrip;
using Management.Trip.Service.Application.Commands.EditTrip;
using Management.Trip.Service.Application.Queries.GetAllTrips;

namespace Management.Trip.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<TripDbContext>(
                options => options.UseSqlServer(this.Configuration.GetConnectionString("DbConnection")));

            services.AddScoped<ITripRepository, TripRepository>();

            services.AddMediatR(typeof(CreateTripCommandHandler));
            services.AddMediatR(typeof(CancelTripCommandHandler));
            services.AddMediatR(typeof(EditTripCommandHandler));
            services.AddMediatR(typeof(GetAllTripsQueryHandler));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My TripManagement Api", Version = "v1" });
            });
        }

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

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My TripManagement API V1");
            });
        }
    }
}
