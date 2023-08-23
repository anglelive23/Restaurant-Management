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

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.Property(x => x.IsDeleted)
               .HasDefaultValue(false);
        }
    }
}
