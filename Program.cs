
//using Microsoft.EntityFrameworkCore;
//using Microsoft.OpenApi.Models;
//using WebCurriculum.Interface.Respositoty;
//using WebCurriculum.Interface.Service;
//using WebCurriculum.Repositoy;
//using WebCurriculum.Services;
//using YourNamespace.Data;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();

//// Configura��o do DbContext com SQL Server
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//// Registro dos reposit�rios e servi�os para inje��o de depend�ncia
//builder.Services.AddScoped<ICurriculoRepository, CurriculoRepository>();
//builder.Services.AddScoped<IArquivoRepository, ArquivoRepository>();
//builder.Services.AddScoped<ICurriculoService, CurriculoService>();
//builder.Services.AddScoped<IArquivoService, ArquivoService>();

//// Configura��o do Swagger
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CurriculosAPI", Version = "v1" });
//});

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(c =>
//    {
//        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CurriculosAPI v1");
//    });
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();


using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebCurriculum.Data;
using WebCurriculum.DTOs;
using WebCurriculum.Interface.Respositoty;
using WebCurriculum.Interface.Service;
using WebCurriculum.Repository;
using WebCurriculum.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configura��o do DbContext com SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro dos reposit�rios e servi�os para inje��o de depend�ncia
builder.Services.AddScoped<ICurriculoRepository, CurriculoRepository>();
builder.Services.AddScoped<IArquivoRepository, ArquivoRepository>();
builder.Services.AddScoped<ICurriculoService, CurriculoService>();
builder.Services.AddScoped<IArquivoService, ArquivoService>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configura��o do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CurriculosAPI", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CurriculosAPI v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
