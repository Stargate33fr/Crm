using Crm.Api.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Crm.Api.Infrastructure
{
    public class CrmDbContext: DbContext
    {
        public CrmDbContext()
        {
            //ChangeTracker.Tracked += OnEntityTracked;
            //ChangeTracker.StateChanged += OnEntityStateChanged;
        }

        public CrmDbContext(DbContextOptions options)
         : base(options)
        {
            //ChangeTracker.Tracked += OnEntityTracked;
            //ChangeTracker.StateChanged += OnEntityStateChanged;
        }

        void OnEntityTracked(object sender, EntityTrackedEventArgs e)
        {
            if (e.Entry.Entity is TrackedEntity entity && !e.FromQuery)
            {
                switch (e.Entry.State)
                {
                    case EntityState.Added:
                        entity.Created = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entity.Updated = DateTime.Now;
                        break;
                }
            }
        }

        void OnEntityStateChanged(object sender, EntityStateChangedEventArgs e)
        {
            if (e.NewState == EntityState.Modified && e.Entry.Entity is TrackedEntity entity)
                entity.Updated = DateTime.Now;
        }

        [DbFunction("remove_diacritics", "dbo")]
        public static string RemoveDiacritics(string input)
        {
            throw new NotImplementedException("This method can only be called in LINQ-to-Entities!");
        }

        public void DetachAllEntities()
        {
            var changedEntriesCopy = this.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }

        [DbFunction("extract_numbers", "dbo")]
        public static string ExtractNumbers(string input)
        {
            throw new NotImplementedException("This method can only be called in LINQ-to-Entities!");
        }

        public virtual DbSet<UserEntity>? User { get; set; }
        public virtual DbSet<AddressEntity>? Address { get; set; }
        public virtual DbSet<CivilityEntity>? Civility { get; set; }
        public virtual DbSet<DepartmentEntity>? Department { get; set; }
        public virtual DbSet<CountryEntity>? Country { get; set; }
        public virtual DbSet<CityEntity>? City { get; set; }
        public virtual DbSet<RegionEntity>? Region { get; set; }
        public virtual DbSet<ContactEntity>? Contact { get; set; }
        public virtual DbSet<CompanyEntity>? Company { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=IDP-21011\\MSSQL2019;Initial Catalog=CrmDb;Persist Security Info=True;Encrypt=true;TrustServerCertificate=true;User ID=sa2;Password=Fr@d040418+");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            //Tables intermédiaire relation plusieurs à plusieurs doit spécifier manuellement la clé composite
            modelBuilder.Entity<CityEntity>()
             .HasIndex(v => v.SearchName);

            modelBuilder.Entity<CityEntity>()
                .HasIndex(v => v.PostalCode);

            modelBuilder.Entity<DepartmentEntity>()
                .HasIndex(v => v.SearchName);

            modelBuilder.Entity<UserEntity>()
                .Property(pt => pt.MobilePhoneNumber)
                .HasMaxLength(32);

            modelBuilder.Entity<UserEntity>()
                .Property(pt => pt.PhoneNumber)
                .HasMaxLength(32);

            modelBuilder.Entity<UserEntity>()
                .HasIndex(u => u.Mail)
                .IsUnique();

            modelBuilder.Entity<ContactEntity>()
               .HasIndex(u => u.Mail)
               .IsUnique();

            modelBuilder.Entity<DepartmentEntity>()
              .HasIndex(v => v.Code);

            modelBuilder.Entity<RegionEntity>()
                .HasIndex(v => new { v.SearchName });

            modelBuilder.Entity<CountryEntity>()
                .ToTable("Country");
        }
    }
}