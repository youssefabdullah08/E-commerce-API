
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Store.Data.Contexts;
using Store.Reposatrys.Basket;
using Store.Reposatrys.Interfaces;
using Store.Reposatrys.Reposatrys;
using Store.Serveses.BasketService;
using Store.Serveses.OrderService;
using Store.Serveses.PaymentService;
using Store.Serveses.ProductServes;
using Store.Serveses.TokenServece;
using Store.Serveses.UserService;
using Store.Web.Exstntions;
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
            builder.Services.AddIdentityConfig(builder.Configuration);

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IProductServes, ProductServes>();
            builder.Services.AddScoped<IBasketService, BasketService>();
            builder.Services.AddScoped<IBasketReposatry, BasketRepostry>();
            builder.Services.AddScoped<ITokenServece, TokenServece>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddAutoMapper(typeof(ProductProfile));
            builder.Services.AddAutoMapper(typeof(OrderProfile));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwagerService();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Stripe", police =>
                {
                    police.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });

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
            app.UseCors("Stripe");


            app.MapControllers();

            app.Run();
        }
    }
}
