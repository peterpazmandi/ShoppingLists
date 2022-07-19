using API.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//a variable to hold configuration
IConfiguration Configuration;

var builder = WebApplication.CreateBuilder(args);
Configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddApplicationServices(Configuration);

builder.Services.AddControllers();
builder.Services.AddCors();

builder.Services.AddIdentityServices(Configuration);
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
