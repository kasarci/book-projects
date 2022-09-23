using _14_efcore_northwind;
using _20_webapi.Repositories;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Northwind>(options =>
                                         options.UseSqlite(@"FileName=C:\sqlite\Northwind\Northwind.db"));

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SupportedSubmitMethods(new[] {
            SubmitMethod.Get,
            SubmitMethod.Post,
            SubmitMethod.Put,
            SubmitMethod.Delete
        });
    });
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
