using System.Globalization;
using System.Linq;
using System.Net;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Sharmila_Textile_WebApp.Data;
using Sharmila_Textile_WebApp.FluentValidation.Responses;
using Sharmila_Textile_WebApp.FluentValidation.Validators;

namespace Sharmila_Textile_WebApp {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddDbContextPool<AppDBContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );
            services.AddAutoMapper(typeof(Startup));

            services.AddSession();

            services.AddMvc()
//                .ConfigureApiBehaviorOptions(option => {
//                option.InvalidModelStateResponseFactory = (context) => {
//                    var errors = context.ModelState.Values.SelectMany(x => x.Errors.Select(p => new ErrorModel() {
//                        ErrorCode = ((int)HttpStatusCode.BadRequest).ToString(CultureInfo.CurrentCulture),
//                        Message = p.ErrorMessage
//                    })).ToList();
//                    var result = new ErrorResponse {
//                        Errors = errors,
//                        ResponseCode = (int)HttpStatusCode.BadRequest
//
//                    };
//                    return new BadRequestObjectResult(result);
//                };
//            })
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddControllersWithViews().
                AddJsonOptions(options => {
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDBContext context) {
            context.Database.Migrate();

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Dashboard}/{action=Index}");
            });
        }
    }
}
