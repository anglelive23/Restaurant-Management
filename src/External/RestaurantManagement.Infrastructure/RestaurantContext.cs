namespace RestaurantManagement.Infrastructure
{
    public class RestaurantContext : IdentityDbContext<ApplicationUser>
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {
        }

        #region DbSets
        public DbSet<Addon> Addons { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<SalesHeader> SalesHeaders { get; set; }
        public DbSet<SalesLine> SalesLines { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Table> Tables { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RestaurantContext).Assembly);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>()
                .ToTable("Roles", "security");

            modelBuilder.Entity<ApplicationUser>()
                .ToTable("Users", "security");

            modelBuilder.Entity<IdentityRoleClaim<string>>()
                .ToTable("RoleClaims", "security");

            modelBuilder.Entity<IdentityUserClaim<string>>()
                .ToTable("UserClaims", "security");

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .ToTable("UserLogins", "security");

            modelBuilder.Entity<IdentityUserRole<string>>()
                .ToTable("UserRoles", "security");

            modelBuilder.Entity<IdentityUserToken<string>>()
                .ToTable("UserTokens", "security");

            modelBuilder.Entity<RefreshToken>()
                .ToTable("RefreshToken", "security");
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        break;
                }
            }

            foreach (var entry in ChangeTracker.Entries<ApplicationUser>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
