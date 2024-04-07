using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Domain.Catalog;
namespace RealEstate.Data.EntityConfigurations.Catalog
{
    public sealed class ItemEntityConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable(nameof(Item));
            builder.HasKey(item => item.Id);

            builder.Property(x => x.Price).HasPrecision(18, 4);
        }

    }
}
