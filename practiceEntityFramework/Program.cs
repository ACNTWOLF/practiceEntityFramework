using AdventureWorksAPI.Data;
using Microsoft.EntityFrameworkCore;    
using practiceEntityFramework.Interface;
using practiceEntityFramework.Data;
using practiceEntityFramework.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AdventureWorksContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AdventureWorks2022")));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AdventureWorksContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(30),
        errorNumbersToAdd: null);

    }));
builder.Services.AddScoped<IProductRepository,ProductRepository >();
builder.Services.AddScoped<IProductSpRepository, ProductspRepository>();
builder.Services.AddScoped<IProductOperation, ProductOperation>();



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
