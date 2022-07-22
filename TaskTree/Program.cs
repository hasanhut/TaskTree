using Microsoft.EntityFrameworkCore;
using TaskTree.Helpers;
using TaskTree.Repositories.Abstract;
using TaskTree.Repositories.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => {
    options.UseNpgsql("WebApiDatabase");
});
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProjectTaskRepository, ProjectTaskRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder =>
 builder.WithOrigins("http://localhost:3000")
 .AllowAnyHeader()
 .AllowCredentials()
 .AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
