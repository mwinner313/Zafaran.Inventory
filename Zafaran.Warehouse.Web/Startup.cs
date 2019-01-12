using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Zafaran.Warehouse.Core.Contracts.Repositories;
using Zafaran.Warehouse.Core.Contracts.Services;
using Zafaran.Warehouse.Core.Events;
using Zafaran.Warehouse.Core.Events.Handlers;
using Zafaran.Warehouse.Core.Repositories;
using Zafaran.Warehouse.Core.Services.CommodityRequestCheckoutServices;
using Zafaran.Warehouse.Core.Services.Warehouses;
using Zafaran.Warehouse.Infrastructure.Repositories;
using Zafaran.WareHouse.Core.Contracts;
using Zafaran.WareHouse.Core.Entities;
using Zafaran.WareHouse.Core.Services.CommodityRequestFormServices;
using Zafaran.WareHouse.Infrastructure;
using Zafaran.WareHouse.Web.Infrastructure;
using ICommodityRepository = Zafaran.Warehouse.Core.Contracts.Repositories.ICommodityRepository;

namespace Zafaran.WareHouse.Web
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
            services.AddMvc(options => { options.Filters.Add(typeof(ValidateModelStateAttribute)); })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            ConfigureIdentitySystem(services);
            ConfigureSwagger(services);
            ConfigureDbContext(services);
            services.AddAutoMapper(x => x.AddProfiles(typeof(IEntity<>).Assembly));

            services.AddScoped<IEventDispatcher, EventDispatcher>();
            services.AddScoped<ICommodityRequestCheckoutService, CommodityRequestCheckoutService>();
            services.AddScoped<ICommodityRequestFormService, CommodityRequestFormService>();
            services.AddScoped<IWarehouseService, WarehouseService>();
            services.RegisterEventHandlers();
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<ICommodityRequestCheckoutRepository, CommodityRequestCheckoutRepository>();
            services.AddScoped<ICommodityRepository, CommodityRepostory>();
            services.AddScoped<ICommodityRequestFormRepository, CommodityRequestFormRepository>();
        }

        private void ConfigureDbContext(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opts =>
            {
                opts.UseSqlServer(Configuration.GetConnectionString(Configuration["SelectedConnectionString"]),
                    b => { b.MigrationsAssembly("Zafaran.Warehouse.Web"); });
            });
        }

        private static void ConfigureIdentitySystem(IServiceCollection services)
        {
            services.AddIdentity<User, Role>().AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                options.Tokens.ChangePhoneNumberTokenProvider = "Phone";
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.User.RequireUniqueEmail = false;
            });
        }

        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.OperationFilter<AddAuthorizationHeaderParameterOperationFilter>();
                c.SwaggerDoc("v1", new Info {Title = "My API", Version = "v1"});
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider _serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Webpack initialization with hot-reload.
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });
            app.UseAuthentication();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new {controller = "Home", action = "Index"});
            });
        }
    }
}
