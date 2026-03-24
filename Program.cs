using Microsoft.EntityFrameworkCore;
using SsoBarbearia.Aplicacao.Interfaces;
using SsoBarbearia.Aplicacao.Servicos;
using SsoBarbearia.Configuration;
using SsoBarbearia.Infraestrutura.Contexto;
using SsoBarbearia.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// -------------------- DATABASE --------------------

builder.Services.AddDbContext<Contexto>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

/// -------------------- CONTROLLERS --------------------

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// -------------------- OPENAPI (.NET 10 Nativo) --------------------

builder.Services.AddSwaggerConfiguration();

// -------------------- DEPENDENCY INJECTION --------------------

builder.Services.AddScoped<ISsoApp, SsoApp>();

// -------------------- CORS --------------------

builder.Services.AddCors(options =>
{
    options.AddPolicy("MinhaPoliticaCors", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


var app = builder.Build();

// -------------------- MIDDLEWARE --------------------

app.UseMiddleware<ExceptionMiddleware>();

// -------------------- PIPELINE --------------------

app.UseSwaggerConfiguration();

app.UseHttpsRedirection();

app.UseCors("MinhaPoliticaCors");

app.MapControllers();

app.Run();
