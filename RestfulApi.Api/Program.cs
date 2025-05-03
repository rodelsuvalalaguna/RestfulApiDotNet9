using Microsoft.EntityFrameworkCore;
using RestfulApi.Application.Interfaces;
using RestfulApi.Application.Mappings;
using RestfulApi.Application.Services;
using RestfulApi.Infrastructure.Data;
using RestfulApi.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaulConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAutoMapper(typeof(UserProfile).Assembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{ 
    app.UseSwagger();   
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();  
app.MapControllers();   
app.Run();  

