using ADSProjectBackend.DBContext;
using ADSProjectBackend.Repositories;
using ADSProjectBackend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//IOC Services
builder.Services.AddTransient<IEstudianteRepositorio, EstudianteRepositorio>();
builder.Services.AddTransient<ICarreraRepositorio, CarreraRepositorio>();
builder.Services.AddTransient<IMateriaRepositorio, MateriaRepositorio>();
builder.Services.AddTransient<IProfesorRepositorio, ProfesorRepositorio>();
builder.Services.AddTransient<IGrupoRepositorio, GrupoRepositorio>();

//DBServices
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.WithOrigins("http://localhost:4200")
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors("MyPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();