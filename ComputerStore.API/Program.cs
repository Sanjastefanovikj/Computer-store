using ComputerStore.Application.Mapping;
using ComputerStore.Application.Interfaces;
using ComputerStore.Application.Services;
using ComputerStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ComputerStore.Domain.Repositories;
using ComputerStore.Infrastructure.Repositories;

namespace ComputerStore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Register Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register AutoMapper with your MappingProfile
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // Register EF Core DbContext with SQL Server connection string
            builder.Services.AddDbContext<ComputerStoreDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register application services
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IDiscountService, DiscountService>();


            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();


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
        }
    }
}
