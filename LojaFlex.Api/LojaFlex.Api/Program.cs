using LojaFlex.Infra.Context;
using LojaFlex.Infra.Interfaces;
using LojaFlex.Infra.Repositories;
using LojaFlex.Services.Interfaces;
using LojaFlex.Services.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Configura a conexão com o MySQL
var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");
builder.Services.AddDbContext<MaramarDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddAutoMapper(typeof(Program));

// Add services to the container.
builder.Services.AddScoped<IPaisService, PaisService>();
builder.Services.AddScoped<IPaisRepository, PaisRepository>();

builder.Services.AddScoped<IFamiliaService, FamiliaService>();
builder.Services.AddScoped<IFamiliaRepository, FamiliaRepository>();

builder.Services.AddScoped<IEspecieService, EspecieService>();
builder.Services.AddScoped<IEspecieRepository, EspecieRepository>();

builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

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

app.UseRouting();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();