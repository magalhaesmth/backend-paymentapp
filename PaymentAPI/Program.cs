using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<PaymentDetailContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"))
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
    options.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
);

app.UseAuthorization();
app.MapControllers();
app.Run();
