
using TestTiendaApi.Models;
using TestTiendaApi.Repositories;
using TestTiendaApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITiendaRepository, TiendaRepository>();
builder.Services.AddScoped<ITiendaService, TiendaService>();

builder.Services.AddScoped<IArticuloTiendaRepository, ArticuloTiendaRepository>();
builder.Services.AddScoped<IArticuloTiendaService, ArticuloTiendaService>();

builder.Services.AddScoped<IArticuloService, ArticuloService>();
builder.Services.AddScoped<IArticuloRepository, ArticuloRepository>();

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

builder.Services.AddScoped<IClienteArticuloRepository, ClienteArticuloRepository>();
builder.Services.AddScoped<IClienteArticuloService, ClienteArticuloService>();

builder.Services.AddScoped<DbtesttiendaContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
