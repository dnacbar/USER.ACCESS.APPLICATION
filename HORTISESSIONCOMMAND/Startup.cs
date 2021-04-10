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
        private string[] HortiUserHeader = { "content-type", "DN-MR-WASATAIN-COMMAND-QUERY" };
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
            app.UseFatalExceptionMiddleware();
            app.UseValidationExceptionMiddleware();
            app.UseNotFoundExceptionMiddleware();
            app.UseEntityFrameworkExceptionMiddleware();


            app.UseRouting();
            app.UseCors(HortiUserCorsConfig);
            app.UseAuthorization();

            app.UseResponseCompression();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
