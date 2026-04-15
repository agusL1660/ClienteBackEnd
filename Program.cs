using ClienteBackend.Middleware;
using ClienteBackEnd.Data;
using ClienteBackEnd.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ClienteData>();
builder.Services.AddScoped<ClienteRepository>();

builder.Services.AddControllers();
// Add services to the container.
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
app.UseMiddleware<TiempoMiddleware>();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
