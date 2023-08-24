namespace RestaurantManagement.Infrastructure.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(a => a.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
