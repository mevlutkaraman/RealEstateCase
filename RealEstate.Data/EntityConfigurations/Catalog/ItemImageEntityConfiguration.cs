using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstate.Domain.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Data.EntityConfigurations.Catalog
{
    public sealed class ItemImageEntityConfiguration : IEntityTypeConfiguration<ItemImage>
    {
        public void Configure(EntityTypeBuilder<ItemImage> builder)
        {
            builder.ToTable(nameof(ItemImage));
            builder.HasKey(itemImage => itemImage.Id);

            builder.HasOne(itemImage => itemImage.Item).WithMany(item => item.Images).HasForeignKey(itemImage => itemImage.ItemId);
        }
    }
}
