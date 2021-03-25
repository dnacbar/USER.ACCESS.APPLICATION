using HORTI.CORE.CROSSCUTTING.MIDDLEWARE;
using HORTIUSERCOMMAND.REPOSITORY;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.IO.Compression;

namespace HORTIUSERCOMMAND
{
    public class Startup
    {
        private const string HortiUserCorsConfig = "HORTIUSERCORSCONFIG";
        private const string HortiUserHeader = "HORTI-USER-COMMAND";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DBHORTIUSERCONTEXT>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("DBHORTICONTEXT"));
                opt.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
            });

            services.AddCors(x => x.AddPolicy(HortiUserCorsConfig, p => { p.WithHeaders(HortiUserHeader); }));

            services.AddResponseCompression(x =>
            {
                x.Providers.Add<BrotliCompressionProvider>();
                x.Providers.Add<GzipCompressionProvider>();
            });

            services.Configure<BrotliCompressionProviderOptions>(x => x.Level = CompressionLevel.Optimal);
            services.Configure<GzipCompressionProviderOptions>(x => x.Level = CompressionLevel.Optimal);

            services.AddControllers();

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo
            {
                Description = "WS REST - WEB API HORTIUSER COMMAND",
                Title = "WS REST - WEB API HORTIUSER COMMAND",
                Version = "v1"
            }));

            StartupServices.Services(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseResponseCompression();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WS REST  - HORTIUSER COMMAND"));
            
            app.UseRouting();
            app.UseCors(HortiUserCorsConfig);

            app.UseAuthorization();

            app.UseFatalExceptionMiddleware();
            app.UseValidationExceptionMiddleware();
            app.UseEntityFrameworkExceptionMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
