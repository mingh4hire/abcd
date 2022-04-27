using Microsoft.AspNetCore.Authorization;
using WebApplication1.abc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("a", policy => policy.AddRequirements(new WebApplication1.abc.SReq()));
});
builder.Services.AddSingleton<IAuthorizationHandler, SimpHandler>();
var app = builder.Build();

//test


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
