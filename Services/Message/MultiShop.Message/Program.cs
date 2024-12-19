using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DAL.Context;
using MultiShop.Message.Services;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);




builder.Services.AddEntityFrameworkNpgsql().AddDbContext<MessageContext>(opts =>
{
    opts.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));

});
builder.Services.AddScoped<IUserMessageService, UserMessageService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opts =>
//{
//    opts.Authority = builder.Configuration["IdentityServerUrl"];
//    opts.RequireHttpsMetadata = false;
//    opts.Audience = "Resource_Message";
//});

builder.Services.AddControllers(opts =>
{
 
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
