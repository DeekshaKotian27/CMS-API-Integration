using API.Data;
using API.Repository.Interface;
using API.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(options => {
    options.AddPolicy("AllowFromSpecificOrigin", builder =>
    {
        builder.WithOrigins("https://localhost:5000").AllowAnyHeader().AllowAnyMethod();
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductDBContext>(
    options=>options.UseSqlServer(
        builder.Configuration.GetConnectionString("ProductCMSDB")));
builder.Services.AddTransient<IProductRepository,ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFromSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
