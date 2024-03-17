using bootcamp.Application.Interface;
using bootcamp.Application.Services;
using bootcamp.Domain.IntefaceRepositories;
using bootcamp.Domain.Repositories;
using bootcamp.Infrastructure.Data;
using bootcamp.Infrastructure.ServiceImplementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IApplicantRepository, ApplicantRepository>();


//Services Lifetime
builder.Services.AddScoped<IApplicantService, ApplicantService>();


//builder.Services.AddDbContext<BootcampDbContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
//b => b.MigrationsAssembly("bootcamp.Api")
//));

builder.Services.AddDbContext<BootcampDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("SqlCon"),
b => b.MigrationsAssembly("bootcamp.Api")
));
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
