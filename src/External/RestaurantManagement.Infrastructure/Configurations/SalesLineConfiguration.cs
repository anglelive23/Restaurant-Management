namespace RestaurantManagement.Infrastructure.Configurations
{
    public class SalesLineConfiguration : IEntityTypeConfiguration<SalesLine>
    {
        public void Configure(EntityTypeBuilder<SalesLine> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.SizeId)
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
