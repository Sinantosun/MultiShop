using MultiShop.SignalRRealTimeApi.Hubs;
using MultiShop.SignalRRealTimeApi.Services.CommentServices;
using MultiShop.SignalRRealTimeApi.Services.MessageServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader().AllowAnyHeader().SetIsOriginAllowed((host) => true).AllowCredentials();
    });
});
builder.Services.AddHttpClient();
builder.Services.AddSignalR();

builder.Services.AddScoped<ISignalRCommentService, SignalRCommentService>();
builder.Services.AddScoped<ISignalRMessageService, SignalRMessageService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<MultiShopSignalRHub>("/signalrhub");

app.Run();
