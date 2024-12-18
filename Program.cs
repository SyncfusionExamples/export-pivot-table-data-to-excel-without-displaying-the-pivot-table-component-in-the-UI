using PivotController.Controllers;
using Microsoft.Extensions.DependencyInjection;
using PivotController.Services;

var builder = WebApplication.CreateBuilder(args);
var CustomOrigins = "_customOrigins";

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddTransient<PivotController.Controllers.PivotController>();
builder.Services.AddHostedService<TimedHostedService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(CustomOrigins,
    builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
builder.Services.AddMemoryCache((options) =>
{
    options.SizeLimit = 100;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors(CustomOrigins);

// Trigger the export logic immediately when the application starts
var scope = app.Services.CreateScope();
var pivotController = scope.ServiceProvider.GetRequiredService<PivotController.Controllers.PivotController>();
await pivotController.Post(); // Optionally, pass necessary args if required

app.Run();