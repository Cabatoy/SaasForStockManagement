using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Core.DependencyResolvers;
using Core.Utilities.Security.Encyption;
using Core.Utilities.Security.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.HangFire;
using Hangfire;
using Hangfire.SqlServer;
using NSwag;

namespace WebCoreApi
{   /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Startup
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        ///  This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMemoryCache();
            services.AddControllers();
            services.AddCors(options =>
            {
                //normalde localhost yerine domain gelecek.
                //options.AddPolicy("AllowOrigin",
                //    builder => builder.WithOrigins("http://localhost:3000"));
                options.AddPolicy("AllowOrigin",
                    builder => builder.WithOrigins("https://bsite.net/Cabatoy"));
            });
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                //(string)Convert.ChangeType(Configuration["TokenOptions:ValidAudience"], typeof(string)),
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)

                };

            });
            services.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule()
            });
           
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = (doc =>
                {
                    doc.Info.Title = "SaasForEducationApi Doc.";
                    doc.Info.Version = "13.0.1.3";
                    doc.Info.Contact = new OpenApiContact()
                    {
                        Name = "Çahatay Özdemir",
                        Url = "",
                        Email = "cahatayozdemir@gmail.com",
                    };
                });

            });

            ////// Add Hangfire services.
            //  var hangFireOptions = Configuration.GetSection("HangFireConfiguration").Get<HangFireOptions>();
            //services.AddHangfire(configuration => configuration
            //    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            //    .UseSimpleAssemblyNameTypeSerializer()
            //    .UseRecommendedSerializerSettings()
            //    .UseSqlServerStorage(hangFireOptions.Connection, new SqlServerStorageOptions
            //    {
            //        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
            //        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
            //        QueuePollInterval = TimeSpan.Zero,
            //        UseRecommendedIsolationLevel = true,
            //        DisableGlobalLocks = true
            //    }));

            //// Add the processing server as IHostedService
            //services.AddHangfireServer();

            // Add framework services.
            services.AddMvc();

        }
        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //debug ederken burayi kapatirsan hatalari kabak gibi gorebilirsin Çahatay
            app.ConfigureCustomExceptionMiddleware();

            app.UseCors(builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            //neler yapilabilir.(evde ne yapilabilir) tokenla yetkiyi yakalmis olucaz
            app.UseAuthentication();

            //anahtar(eve giris) giris bilgileri ile login saglamak icin
            app.UseAuthorization();

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
