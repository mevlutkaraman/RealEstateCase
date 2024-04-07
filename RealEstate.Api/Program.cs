using Microsoft.Extensions.Options;
using RealEstate.Core.Settings;
using RealEstate.Data;
using RealEstate.Api.Framework.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseConfigurationSettings>(option =>
{
    option.ConnectionString = builder.Configuration.GetValue<string>("RealEstateDbConnectionString") ?? string.Empty;
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dataConfigurationSettingsServiceProvider = builder.Services.BuildServiceProvider();
var dataConfigurationSettings = dataConfigurationSettingsServiceProvider.GetRequiredService<IOptions<DatabaseConfigurationSettings>>().Value;
builder.Services.AddEfCore(dataConfigurationSettings);

builder.Services.ConfigureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "RealEstate.Api v1");
        c.DisplayRequestDuration();
        c.DocumentTitle = "Real Estate Api";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
