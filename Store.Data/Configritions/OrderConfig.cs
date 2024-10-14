using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Data.Entites.OrderEntityies;

namespace Store.Data.Configritions
{
    internal class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(x => x.shepingAdress, x =>
            {
                x.WithOwner();
            });
            builder.HasMany(x => x.orderItems).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
