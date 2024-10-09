using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Data.Contexts;
using Store.Data.Entites;
using Store.Reposatrys;

namespace Store.Web.Helper
{
    public class ApplySeeding
    {
        public static async Task ApplySeedingAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var serveses = scope.ServiceProvider;
                var factory = serveses.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = serveses.GetRequiredService<StoreDBcontext>();
                    var useridentity = serveses.GetRequiredService<UserManager<AppUser>>();

                    await context.Database.MigrateAsync();
                    await SeedingContext.SeedAsync(context, factory);
                    //await identitySeedContext.SeedUserAsync(useridentity);
                }
                catch (Exception ex)
                {
                    var loger = factory.CreateLogger<ApplySeeding>();
                    loger.LogError(ex.Message);
                }
            }
        }
    }
}
