using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Soa.Data;
using Soa.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SoaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SoaContext") ?? throw new InvalidOperationException("Connection string 'SoaContext' not found.")));

//builder.Services.AddDbContext<SoaContext>(options => options.UseInMemoryDatabase("test"));

//Add services to the container.
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookRepository, BookRepository>();
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
