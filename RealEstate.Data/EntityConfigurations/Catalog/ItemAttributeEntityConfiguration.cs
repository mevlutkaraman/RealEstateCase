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
    public sealed class ItemAttributeEntityConfiguration : IEntityTypeConfiguration<ItemAttribute>
    {
        public void Configure(EntityTypeBuilder<ItemAttribute> builder)
        {
            builder.ToTable(nameof(ItemAttribute));
            builder.HasKey(itemAttribute => itemAttribute.Id);
        }
    }
}
