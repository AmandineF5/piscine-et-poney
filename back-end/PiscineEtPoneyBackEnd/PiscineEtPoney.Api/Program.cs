using PiscineEtPoney.Application.Interfaces;
using PiscineEtPoney.Application.Services;
using PiscineEtPoney.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using PiscineEtPoney.Application.Interfaces.Repositories;
using PiscineEtPoney.Infrastructure.Repositories;
using PiscineEtPoney.Application.Interfaces.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseLazyLoadingProxies().UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(10, 5, 0)) // Vérifie la version de MariaDB installée
    ));
builder.Services.AddScoped<IChildRepository, ChildRepository>();
builder.Services.AddScoped<IChildService, ChildService>();
builder.Services.AddScoped<IParentRepository, ParentRepository>();
builder.Services.AddScoped<IParentService, ParentService>();

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy.WithOrigins("http://localhost:3000") // React dev server URL
                         .AllowAnyHeader()
                         .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//   options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Ajouter le contexte de la base de données MariaDB
/* builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(10, 5, 0)) // Vérifie la version de MariaDB installée
    )
); */


app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.Run();


app.Run();


