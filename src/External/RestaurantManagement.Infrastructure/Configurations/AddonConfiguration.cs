using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Infrastructure.Configurations
{
    public class AddonConfiguration : IEntityTypeConfiguration<Addon>
    {
        public void Configure(EntityTypeBuilder<Addon> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Price)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.Property(x => x.IsDeleted)
               .HasDefaultValue(false);
        }
    }
}
