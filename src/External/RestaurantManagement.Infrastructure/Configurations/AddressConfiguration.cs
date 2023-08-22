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
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.AddressLine1)
                .IsRequired()
                .HasMaxLength(120)
                .HasDefaultValue(string.Empty);

            builder.Property(a => a.AddressLine2)
                .HasMaxLength(120)
                .HasDefaultValue(string.Empty);


            builder.Property(a => a.AddressLine3)
                .HasMaxLength(120)
                .HasDefaultValue(string.Empty);
        }
    }
}
