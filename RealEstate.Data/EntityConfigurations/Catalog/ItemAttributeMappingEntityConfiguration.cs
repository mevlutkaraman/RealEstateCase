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
    public sealed class ItemAttributeMappingEntityConfiguration : IEntityTypeConfiguration<ItemAttributeMapping>
    {
        public void Configure(EntityTypeBuilder<ItemAttributeMapping> builder)
        {
            builder.ToTable(nameof(ItemAttributeMapping));
            builder.HasKey(itemAttributeMapping => itemAttributeMapping.Id);

            builder.HasOne(itemAttributeMapping => itemAttributeMapping.Item)
                   .WithMany(item => item.Attributes)
                   .HasForeignKey(itemAttributeMapping => itemAttributeMapping.ItemId);
        }
    }
}
