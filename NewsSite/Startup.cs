using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using NewsSite.Entities;

namespace NewsSite
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
            services.AddDbContext<NewsSiteDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<NewsSiteDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdministratorRights", policy => policy.RequireClaim("NewsSiteRole", "Administrator"));
                options.AddPolicy("PublisherRights", policy => policy.RequireAssertion(context =>
                {
                    var user = context.User;
                    var newsSiteRoleClaimsValue = user.Claims.Where(u => u.Type == "NewsSiteRole").Select(c => c.Value).FirstOrDefault();

                    if (newsSiteRoleClaimsValue == "Administrator" || newsSiteRoleClaimsValue == "Publisher")
                        return true;
                    else
                        return false;

                }));
                options.AddPolicy("EconomyPublisherRights", policy => policy.RequireAssertion(context =>
                {
                    var user = context.User;
                    var newsSiteRoleClaimsValue = user.Claims.Where(u => u.Type == "NewsSiteRole").Select(c => c.Value).FirstOrDefault();
                    var categoryPublisherClaimsValues = user.Claims.Where(u => u.Type == "CategoryPublisher").Select(c => c.Value).ToList();

                    if (newsSiteRoleClaimsValue == "Administrator")
                    {
                        return true;
                    }
                    else if (newsSiteRoleClaimsValue == "Publisher" && categoryPublisherClaimsValues.Contains("Economy"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }));
                options.AddPolicy("SportsPublisherRights", policy => policy.RequireAssertion(context =>
                {
                    var user = context.User;
                    var newsSiteRoleClaimsValue = user.Claims.Where(u => u.Type == "NewsSiteRole").Select(c => c.Value).FirstOrDefault();
                    var categoryPublisherClaimsValues = user.Claims.Where(u => u.Type == "CategoryPublisher").Select(c => c.Value).ToList();

                    if (newsSiteRoleClaimsValue == "Administrator")
                    {
                        return true;
                    }
                    else if (newsSiteRoleClaimsValue == "Publisher" && categoryPublisherClaimsValues.Contains("Sports"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }));
                options.AddPolicy("CulturePublisherRights", policy => policy.RequireAssertion(context =>
                {
                    var user = context.User;
                    var newsSiteRoleClaimsValue = user.Claims.Where(u => u.Type == "NewsSiteRole").Select(c => c.Value).FirstOrDefault();
                    var categoryPublisherClaimsValues = user.Claims.Where(u => u.Type == "CategoryPublisher").Select(c => c.Value).ToList();

                    if (newsSiteRoleClaimsValue == "Administrator")
                    {
                        return true;
                    }
                    else if (newsSiteRoleClaimsValue == "Publisher" && categoryPublisherClaimsValues.Contains("Culture"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }));
                options.AddPolicy("SubscriberRights", policy => policy.RequireAssertion(context =>
                {
                    var user = context.User;
                    var newsSiteRoleClaimsValue = user.Claims.Where(u => u.Type == "NewsSiteRole").Select(c => c.Value).FirstOrDefault();

                    if (newsSiteRoleClaimsValue == "Administrator" || newsSiteRoleClaimsValue == "Publisher" || newsSiteRoleClaimsValue == "Subscriber")
                        return true;
                    else
                        return false;
                }));
                options.AddPolicy("ViewRights", policy => policy.RequireAssertion(context =>
                {
                    var user = context.User;
                    var newsSiteRoleClaimsValue = user.Claims.Where(u => u.Type == "NewsSiteRole").Select(c => c.Value).FirstOrDefault();
                    var applicationUserAgeClaimValue = user.Claims.Where(u => u.Type == "Age").Select(c => c.Value).SingleOrDefault();
                    Int32.TryParse(applicationUserAgeClaimValue, out int parsedApplicationUserAgeClaimValue);

                    if (newsSiteRoleClaimsValue == "Administrator" || newsSiteRoleClaimsValue == "Publisher")
                    {
                        return true;
                    }
                    else if (newsSiteRoleClaimsValue == "Subscriber" && parsedApplicationUserAgeClaimValue >= 20)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }));
            });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDirectoryBrowser();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
