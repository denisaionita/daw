using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AspNet.Security.OAuth.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IO;

namespace ProiectDAW
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)         {             services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)                  .AddJwtBearer(jwtBearerOptions =>                 {                     jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()                     {                         ValidateActor = true,                         ValidateAudience = true,                         ValidateLifetime = true,                         ValidateIssuerSigningKey = true,                         ValidIssuer = "ProiectDAW",                         ValidAudience = "FrontendDAW",                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("89babe78-2664-4c7f-b516-8bea619af7ad"))                     };                 });              services.AddCors(options =>             {                 options.AddPolicy("CorsPolicy",                     builder => builder.AllowAnyOrigin()                     .AllowAnyMethod()                                   .AllowAnyHeader()                     .AllowCredentials());             });              services.AddMvc();         }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)         {             //if (env.IsDevelopment())             //{             //    app.UseDeveloperExceptionPage();             //    app.UseBrowserLink();             //}             //else             //{             //    app.UseExceptionHandler("/Home/Error");             //}              app.Use(async (context, next) => { await next(); if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value) && !context.Request.Path.Value.StartsWith("/api/")) { context.Request.Path = "index.html"; await next(); } }); app.UseMvcWithDefaultRoute(); app.UseDefaultFiles(); app.UseStaticFiles();              app.UseStaticFiles();             app.UseCors("CorsPolicy");             app.UseAuthentication();             app.UseMvcWithDefaultRoute();             app.UseMvc();         }
    }
}
