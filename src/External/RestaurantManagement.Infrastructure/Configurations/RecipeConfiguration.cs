namespace RestaurantManagement.Infrastructure.Configurations
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(x => x.InitialPrice)
                .IsRequired()
                .HasPrecision(18, 2);

            //builder.Property(x => x.Rate)
            //    .HasAnnotation("Range", new RangeAttribute(0, 5));
        }
    }
}
