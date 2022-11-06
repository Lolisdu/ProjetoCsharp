using Microsoft.EntityFrameworkCore;
using Myproject.Database;
using Myproject.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connetionMySql = builder.Configuration.GetConnectionString("DefaultConnetion");
builder.Services.AddDbContext<UsuarioDbContext>(
    options => options.UseMySql(connetionMySql,ServerVersion.Parse("8.0.31-mysql"))
);

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();


builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
