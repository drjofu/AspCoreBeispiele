﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Kursverwaltung.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSwag;
using NSwag.AspNetCore;

namespace KursverwaltungApi
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
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

      services.AddDbContext<KursverwaltungContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("KursverwaltungContext")));

      services.AddSwagger();
      services.AddCors(options=>
      {
        options.AddPolicy("default", cpb =>
        {
          cpb.AllowAnyHeader();
          cpb.AllowAnyMethod();
          cpb.AllowAnyOrigin();
        });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }

      app.UseHttpsRedirection();

      app.UseCors("default");
      app.UseSwaggerUi3(typeof(Startup).Assembly);

      app.UseMvc();
    }
  }
}
