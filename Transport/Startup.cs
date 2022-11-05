using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Transport.Data;
using Transport.Models.Data;
using Transport.Repositories;
using Transport.Repositories.IRepository;
using Transport.Services;
using Transport.Services.IServices;
using Transport.Handlers;
using Transport.Utils;

namespace Transport
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
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<TransportDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            var dbContext = services.BuildServiceProvider()
                .GetService<TransportDbContext>();

            services.AddHttpContextAccessor();

            /*a custom authorization policy "MustBeQuestionAuthorRequirement"*/
            services.AddAuthorization(
                options => options.AddPolicy("CustomAuthorization", policy => policy.Requirements.Add(new CustomAuthorizationRequirement())));

            services.AddScoped<IAuthorizationHandler, CustomAuthorizationHandler>();

            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            // implements the cookie event handler
            services.AddTransient<CookieEventHandler>();

            // demo version of a state management to keep track of logout notifications
            services.AddSingleton<LogoutSessionManager>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = "oidc";
            })
                .AddCookie(options =>
                {
                    options.EventsType = typeof(CookieEventHandler);
                })
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = Configuration.GetSection("IdentityServer")["Authority"];
                    options.RequireHttpsMetadata = false;

                    options.ClientId = Configuration.GetSection("IdentityServer")["ClientId"];
                    options.ClientSecret = Configuration.GetSection("IdentityServer")["Secret"];

                    options.ResponseType = "code";

                    options.Scope.Clear();
                    options.Scope.Add("openid");
                    options.Scope.Add("profile");
                    //options.Scope.Add("scope1");
                    options.Scope.Add("offline_access");
                    //options.Scope.Add("271ffa58-680a-42b9-918e-9468228c3f42_api");

                    // not mapped by default
                    options.ClaimActions.MapJsonKey("website", "website");

                    // keeps id_token smaller
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.SaveTokens = true;

                    //options.TokenValidationParameters = new TokenValidationParameters
                    //{
                    //    NameClaimType = "name",
                    //    RoleClaimType = "role"
                    //};

                    CustomHandlers cHandler = new CustomHandlers(dbContext);

                    options.Events = new OpenIdConnectEvents
                    {
                        OnTicketReceived = cHandler.InitializeUserClaims
                    };
                });

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromMinutes(15);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });



            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllersWithViews();
            services.AddMemoryCache();
            //Adding the repositories
            services.AddTransient<IVehicleMaintenanceRequestRepository, VehicleMaintenanceRequestRepository>();
            services.AddTransient<IVehicleMaintenanceRequestStatusRepository, VehicleMaintenanceRequestStatusRepository>();
            services.AddTransient<IVehicleMaintenanceRequestItemRepository, VehicleMaintenanceRequestItemRepository>();
            services.AddTransient<IInsuranceRepository, InsuranceRepository>();
            services.AddTransient<IVehicleMaintenanceRequestRepository, VehicleMaintenanceRequestRepository>();
            services.AddTransient<IVehicleMaintenanceRequestStatusRepository, VehicleMaintenanceRequestStatusRepository>();
            services.AddTransient<IVehicleRepository, VehicleRepository>();
            services.AddTransient<ICollegeRepository, CollegeRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IMakeRepository,MakeRepository>();
            services.AddTransient<IModelRepository, ModelRepository>();
            services.AddTransient<IVehicleRepository, VehicleRepository>();
            services.AddTransient<IVehicleStatusRepository, VehicleStatusRepository>();
            services.AddTransient<IVehicleUseRepository, VehicleUseRepository>();
            services.AddTransient<ISparePartQuantityRepository, SparePartQuantityRepository>();
            services.AddTransient<ITyreSizeRepository, TyreSizeRepository>();
            services.AddTransient<ICollegeRepository, CollegeRepository>();
            services.AddTransient<IColourRepository, ColourRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IVehicleStatusRepository, VehicleStatusRepository>();
            services.AddTransient<IVehicleTypeRepository, VehicleTypeRepository>();
            services.AddTransient<IVehicleUseRepository, VehicleUseRepository>();
            services.AddTransient<IFuelTypeRepository, FuelTypeRepository>();
            services.AddTransient<IQuantityRepository, QuantityRepository>();
            services.AddTransient<ITransmissionTypeRepository, TransmissionTypeRepository>();
            services.AddTransient<IPermAxleLoadRepository, PermAxleLoadRepository>();
            services.AddTransient<IPhotoSectionRepository, PhotoSectionRepository>();
            services.AddTransient<IVehicleRequestPhotoReceiptRepository, VehicleRequestPhotoReceiptRepository>();
            services.AddTransient<IRequestTypeRepository, RequestTypeRepository>();


            services.AddTransient<IBusHiringPricesRepository, BusHiringPricesRepository>();
            services.AddTransient<IBusHiringDistanceRepository, BusHiringDistanceRepository>();
            services.AddTransient<IRoutineMaintenanceActivityRepository, RoutineMaintenanceActivityRepository>();
            services.AddTransient<IRoutneMaintenanceListRepository, RoutneMaintenanceListRepository>();
            services.AddTransient<IVehicleMaintenanceRequestRepository, VehicleMaintenanceRequestRepository>();
            services.AddTransient<IVehicleMaintenanceRequestStatusRepository, VehicleMaintenanceRequestStatusRepository>();
            services.AddTransient<IVehicleRoutineMaintenanceRepository, VehicleRoutineMaintenanceRepository>();
            services.AddTransient<IHirerRepository, HirerRepository>();
            services.AddTransient<IVehicleTypeForHireRepository, VehicleTypeForHireRepository>();
            services.AddTransient<ITransportStaffRepository, TransportStaffRepository>();
            //Adding Services
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IInvoiceService,InvoiceService>();
            services.AddScoped<ISparePartService, SparePartService>();
            services.AddScoped<IRoutineService, RoutineService>();
            services.AddScoped<IHiringService, HiringService>();
            services.AddScoped<IAdminService, AdminService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
