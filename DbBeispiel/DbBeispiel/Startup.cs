using DbBeispiel.Data;
using DbBeispiel.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DbBeispiel
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
      services.Configure<CookiePolicyOptions>(options =>
      {
        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
      });

      services.AddDbContext<ApplicationDbContext>(options =>
          options.UseSqlServer(
              Configuration.GetConnectionString("DefaultConnection")));

      services.AddDefaultIdentity<IdentityUser>()
          .AddEntityFrameworkStores<ApplicationDbContext>();

      // Model-Klassen anlegen:
      //  Scaffold-DbContext "Server=(localdb)\MSSQLLocalDB;Initial Catalog=MondialCore2;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
      // https://docs.microsoft.com/de-de/ef/core/get-started/aspnetcore/existing-db



      services.AddDbContext<MondialCore2Context>(options =>
      {
        options.UseSqlServer(Configuration.GetConnectionString("Mondial"));
      });

      // https://www.c-sharpcorner.com/article/claim-based-and-policy-based-authorization-with-asp-net-core-2-1/
      services.AddAuthorization(options =>
      {
        options.AddPolicy(MyPolicyNames.DerDarfDas, policy => policy.RequireClaim("dings","bums"));
      });

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

      services.AddMemoryCache();

      services.AddSession(options =>
      {
        // Set a short timeout for easy testing.
        options.IdleTimeout = TimeSpan.FromSeconds(10);
        options.Cookie.HttpOnly = true;
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseDatabaseErrorPage();
      }
      else
      {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
      }
      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseCookiePolicy();
      app.UseSession();

      app.UseAuthentication();

      app.UseMvc();
    }
  }
}
