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
    public class SalesHeaderConfiguration : IEntityTypeConfiguration<SalesHeader>
    {
        public void Configure(EntityTypeBuilder<SalesHeader> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(s => s.SalesPrice)
                .IsRequired()
                .HasPrecision(18, 2);
        }
    }
}
