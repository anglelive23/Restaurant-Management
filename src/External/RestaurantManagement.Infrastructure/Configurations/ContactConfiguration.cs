namespace RestaurantManagement.Infrastructure.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Ocupation)
                .HasMaxLength(150);

            builder.Property(c => c.PhoneNo1)
                .HasMaxLength(20);

            builder.Property(c => c.PhoneNo2)
                .HasMaxLength(20);

            builder.Property(c => c.PhoneNo3)
                .HasMaxLength(20);

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.Property(x => x.IsDeleted)
               .HasDefaultValue(false);
        }
    }
}
