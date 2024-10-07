
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Store.Data.Contexts;
using Store.Reposatrys.Basket;
using Store.Reposatrys.Interfaces;
using Store.Reposatrys.Reposatrys;
using Store.Serveses.BasketService;
using Store.Serveses.ProductServes;
using Store.Web.Helper;
using Store.Web.Middelware;

namespace Store.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddDbContext<StoreDBcontext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("localConnection"));
            });
            builder.Services.AddDbContext<StoreIdentityDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityDB"));
            });
            builder.Services.AddSingleton<IConnectionMultiplexer>(config =>
            {
                return ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis"));
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IProductServes, ProductServes>();
            builder.Services.AddScoped<IBasketService, BasketService>();
            builder.Services.AddScoped<IBasketReposatry, BasketRepostry>();
            builder.Services.AddAutoMapper(typeof(ProductProfile));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            await ApplySeeding.ApplySeedingAsync(app);
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ExsptionMiddelware>();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
