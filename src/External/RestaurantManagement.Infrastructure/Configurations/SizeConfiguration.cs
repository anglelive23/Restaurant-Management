namespace RestaurantManagement.Infrastructure.Configurations
{
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.Price)
                .IsRequired()
                .HasPrecision(18, 2);

            builder.Property(s => s.RecipeId)
                .IsRequired();

            builder.Property(x => x.IsActive)
                .HasDefaultValue(true);

            builder.Property(x => x.IsDeleted)
               .HasDefaultValue(false);
        }
    }
}
