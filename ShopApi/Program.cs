using ShopApi.Config;
using ShopApi.DependencyInjection;
using ShopApi.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Variables Configuration
builder.Services.Configure<MyAppSettings>(builder.Configuration);

// Dependency Injections
builder.Services.AddItemServices(builder.Configuration);


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

// Exceptions
ExceptionMiddleware.ConfigureExceptionHandler(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

