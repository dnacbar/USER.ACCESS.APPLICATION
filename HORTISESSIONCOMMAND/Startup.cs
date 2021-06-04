using Flurl.Http;
using HORTI.CORE.CROSSCUTTING.MIDDLEWARE;
using HORTIUSERCOMMAND.REPOSITORY;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO.Compression;
using System.Text;

namespace HORTIUSERCOMMAND
{
    public class Startup
    {
        private const string HortiUserCorsConfig = "HORTIUSERCORSCONFIG";
        private string[] HortiUserHeader = { "Content-Type", "Authorization", "DN-MR-WASATAIN-COMMAND-QUERY" };
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            FlurlHttp.Configure(x =>
            {
                x.Timeout = new TimeSpan(0, 0, 3);
            });

            services.AddDbContext<DBHORTIUSERCONTEXT>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("DBHORTIUSERCONTEXT"));
                opt.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
            });

            services.AddCors(x => x.AddPolicy(HortiUserCorsConfig, p =>
            {
                p.WithOrigins("http://localhost:4200");
                p.WithHeaders(HortiUserHeader);
            }));

            services.AddResponseCompression(x =>
            {
                x.Providers.Add<BrotliCompressionProvider>();
                x.Providers.Add<GzipCompressionProvider>();
            });

            services.Configure<BrotliCompressionProviderOptions>(x => x.Level = CompressionLevel.Optimal);
            services.Configure<GzipCompressionProviderOptions>(x => x.Level = CompressionLevel.Optimal);

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo
            {
                Description = "WS REST - WEB API HORTIUSER COMMAND",
                Title = "WS REST - WEB API HORTIUSER COMMAND",
                Version = "v1"
            }));

            var key = Encoding.ASCII.GetBytes("888AAE896C564B76E67703B2A3499AB0C8");
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddControllers().AddJsonOptions(x => { x.JsonSerializerOptions.PropertyNamingPolicy = null; });

            StartupServices.Services(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WS REST  - HORTIUSER COMMAND"));

            app.UseFatalExceptionMiddleware();
            app.UseValidationExceptionMiddleware();
            app.UseNotFoundExceptionMiddleware();
            app.UseEntityFrameworkExceptionMiddleware();
            app.UseBadGatewayExceptionMiddleware();


            app.UseRouting();
            app.UseCors(HortiUserCorsConfig);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseResponseCompression();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
