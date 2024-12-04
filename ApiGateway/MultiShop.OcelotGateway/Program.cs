using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();

builder.Services.AddOcelot(configuration);

builder.Services.AddAuthentication().AddJwtBearer("OcelotAuthenticationScheme", opts =>
{
    opts.Audience = builder.Configuration["IdentityServerUrl"];
    opts.Audience = "Resource_Ocelot";
    opts.RequireHttpsMetadata = false;
});

var app = builder.Build();

await app.UseOcelot();

app.MapGet("/", () => "Hello World!");

app.Run();
