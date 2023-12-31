﻿namespace RestaurantManagement.Infrastructure.Configurations
{
    public class SalesHeaderConfiguration : IEntityTypeConfiguration<SalesHeader>
    {
        public void Configure(EntityTypeBuilder<SalesHeader> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(s => s.SalesPrice)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.Property(x => x.IsDeleted)
               .HasDefaultValue(false);
        }
    }
}
