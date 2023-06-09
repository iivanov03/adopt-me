﻿namespace AdoptMe.Web
{
    using System.Globalization;
    using System.Reflection;

    using AdoptMe.Data;
    using AdoptMe.Data.Common;
    using AdoptMe.Data.Common.Repositories;
    using AdoptMe.Data.Models;
    using AdoptMe.Data.Repositories;
    using AdoptMe.Data.Seeding;
    using AdoptMe.Services.Data;
    using AdoptMe.Services.Data.AdministrationServices;
    using AdoptMe.Services.Mapping;
    using AdoptMe.Web.Infrastructure.EmailSender;
    using AdoptMe.Web.ViewModels;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Localization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Razor;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder.Services, builder.Configuration);
            var app = builder.Build();
            Configure(app);
            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<SmtpSettings>(configuration.GetSection("Smtp"));

            //services.AddAuthentication().AddFacebook(facebookOptions =>
            //{
            //    facebookOptions.AppId = configuration["Authentication:Facebook:AppId"];
            //    facebookOptions.AppSecret = configuration["Authentication:Facebook:AppSecret"];
            //});

            services.Configure<CookiePolicyOptions>(
                options =>
                {
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });

            services.AddControllersWithViews(
            options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            }).AddRazorRuntimeCompilation();

            services.AddAntiforgery(options =>
            {
                // Set Cookie properties using CookieBuilder properties†.
                options.HeaderName = "X-CSRF-TOKEN";
            });

            services.AddRazorPages();

            services.AddSingleton(configuration);

            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddMvc()
              .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
              .AddDataAnnotationsLocalization();

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<ISettingsService, SettingsService>();
            services.AddTransient<IGetCountService, GetCountService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IPetProfileService, PetProfileService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ISearchService, SearchService>();
            services.AddTransient<IDonateService, DonateService>();
            services.AddTransient<ICommentsService, CommentsService>();
            services.AddTransient<IViewRenderService, ViewRenderService>();
        }

        private static void Configure(WebApplication app)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            var supportedCultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("bg-BG"),
            };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("bg-BG"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
            });

            // Seed data on application startup
            using (var serviceScope = app.Services.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/StatusCodeError?errorCode={0}");
                app.UseStatusCodePagesWithRedirects("/Home/StatusCodeError?errorCode={0}"); app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                {
                    app.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();
                });
        }
    }
}
