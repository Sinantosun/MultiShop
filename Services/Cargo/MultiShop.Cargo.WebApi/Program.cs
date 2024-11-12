using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using MultiShop.Cargo.BussinesLayer.Container;
using MultiShop.Cargo.BussinesLayer.Mapping;
using MultiShop.Cargo.DataAccsessLayer.Concrete;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(AutoMapperConfig).Assembly);

builder.Services.AddDbContext<CargoContext>();
builder.Services.AddProjectDepenencies();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opts =>
{
    opts.Audience = "Resource_Cargo";
    opts.RequireHttpsMetadata = false;
    opts.Authority = builder.Configuration["IdentityServerUrl"];
});
builder.Services.AddControllers(opts =>
{
    opts.Filters.Add(new AuthorizeFilter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
