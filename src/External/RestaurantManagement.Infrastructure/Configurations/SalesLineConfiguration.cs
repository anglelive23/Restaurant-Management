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
    public class SalesLineConfiguration : IEntityTypeConfiguration<SalesLine>
    {
        public void Configure(EntityTypeBuilder<SalesLine> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.SalesPrice)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(s => s.Size)
                .IsRequired();

            builder.Property(s => s.Addons)
                .IsRequired();

            builder.Property(s => s.Note)
                .HasMaxLength(100);

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.Property(x => x.IsDeleted)
               .HasDefaultValue(false);
        }
    }
}
