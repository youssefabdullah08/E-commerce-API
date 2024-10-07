using Microsoft.AspNetCore.Identity;
using Store.Data.Contexts;
using Store.Data.Entites;

namespace Store.Web.Exstntions
{
    public static class IdentityBuilder
    {
        public static IServiceCollection AddIdentityConfigritions(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<AppUser>();

            builder = new Microsoft.AspNetCore.Identity.IdentityBuilder(builder.UserType, builder.Services);

            builder.AddEntityFrameworkStores<StoreIdentityDBContext>();

            builder.AddSignInManager<SignInManager<AppUser>>();
            return services;
        }
    }
}
