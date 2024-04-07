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
    public sealed class ItemAttributeValueEntityConfiguration : IEntityTypeConfiguration<ItemAttributeValue>
    {
        public void Configure(EntityTypeBuilder<ItemAttributeValue> builder)
        {
            builder.ToTable(nameof(ItemAttributeValue));
            builder.HasKey(itemAttributeValue => itemAttributeValue.Id);

            builder.HasOne(itemAttributeValue => itemAttributeValue.ItemAttribute).
                    WithMany(itemAttribute => itemAttribute.AttributeValues).
                    HasForeignKey(itemAttributeValue => itemAttributeValue.ItemAttributeId);
        }
    }
}
