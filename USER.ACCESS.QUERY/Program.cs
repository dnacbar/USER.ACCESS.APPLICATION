using Microsoft.EntityFrameworkCore;
using MIDDLEWARE.LOG.APPLICATION.LOG.MIDDLEWARE;
using USER.ACCESS.COMMAND.REPOSITORY.CONTEXT;
using USER.ACCESSQUERY;

IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
StartupService.Service(builder.Services);
builder.Services.AddDbContext<DBUSERCONTEXT>(x => x.UseSqlServer(configuration.GetConnectionString("DBUSERCONNECTION")));

builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.PropertyNamingPolicy = null;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseFatalExceptionMiddleware();
app.UseValidationExceptionMiddleware();
app.UseDataBaseExceptionMiddleware();
app.UseNotFoundExceptionMiddleware();
app.UseBadGatewayExceptionMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();