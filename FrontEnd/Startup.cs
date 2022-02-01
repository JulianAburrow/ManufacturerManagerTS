using AutoMapper;
using ManufacturerManagerTS.BusinessLogic.Extensions;
using ManufacturerManagerTS.BusinessLogic.Mappers;
using ManufacturerManagerTS.BusinessLogic.Models;
using ManufacturerManagerTS.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ManufacturerManagerTS.FrontEnd
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddDbContext<ManufacturerManagerTSContext>(
                options =>
                    options.UseSqlServer(
                        Configuration.GetConnectionString(PageValues.ManufacturerManagerContext)
                    ));

            services.AddSingleton(
                new MapperConfiguration(e => { e.AddProfile(new MappingProfile()); }).CreateMapper());

            services.AddDependencies();
            services.AddRepositories();
            services.AddOther();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
