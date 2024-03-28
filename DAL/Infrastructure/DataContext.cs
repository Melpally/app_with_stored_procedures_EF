using DBSD.CW2._13768._14055._13287.DAL.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DBSD.CW2._13768._14055._13287.DAL.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DataContext()
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ClientAddress> ClientAddresses { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Conventions.Remove(typeof(TableNameFromDbSetConvention));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
            if (!optionsBuilder.IsConfigured)
            {
                /*optionsBuilder.UseSqlServer("Data Source=LAPTOP-JC5GS3F6\\SQLEXPRESS;Initial Catalog=DBSD_CW2; User Id=malika; Password=malika.temurova;TrustServerCertificate=true;");*/
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DBSD_CW2;Integrated Security=True;Trust Server Certificate=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courier>(entity =>
            {
                entity.Property(p => p.FirstName).HasMaxLength(200);
                entity.Property(p => p.LastName).HasMaxLength(200);
                entity.Property(p => p.City).HasMaxLength(200);
                entity.Property(p => p.TGUserName).HasMaxLength(200);
                entity.Property(p => p.PhoneNumber).HasMaxLength(200);
            });

            modelBuilder.Entity<Client>()
                .HasMany<ClientAddress>()
                .WithOne()
                .HasForeignKey(e => e.ClientId)
                .IsRequired();

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(p => p.FirstName).HasMaxLength(200);
                entity.Property(p => p.LastName).HasMaxLength(200);
                entity.Property(p => p.PhoneNumber).HasMaxLength(200);
                
            });

            modelBuilder.Entity<ClientAddress>(entity =>
            {
                entity.Property(p => p.City).HasMaxLength(200);
                entity.Property(p => p.Street).HasMaxLength(200);
                entity.Property(p => p.HomeNumber).HasMaxLength(200);

            });

            modelBuilder.Entity<Order>(entity =>
            { 
                entity.Property(p => p.Id).
                UseIdentityColumn()
                .IsRequired();
            });

            modelBuilder.Entity<Order>()
                .HasOne<Courier>()
                .WithMany()
                .HasForeignKey(e => e.CourierId)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .HasOne<Client>()
                .WithMany()
                .HasForeignKey(e => e.ClientId)
                .IsRequired();

            modelBuilder.Entity<Courier>()
                .HasData
                (
                new Courier { Id = 1, City = "Tashkent", FirstName = "Avaz", LastName = "Khalikov", PhoneNumber = "+998991234567", BirthDate = new DateOnly(1990,12,1), TGUserName = "@avaz_IT", HasDrivingLicense = false },

                new Courier { Id = 2, City = "Tashkent", FirstName = "Jane", LastName = "Doe", PhoneNumber = "+998991234567", BirthDate = new DateOnly(1999, 11, 11), TGUserName = "@janedoe", HasDrivingLicense = true },

                new Courier { Id = 3, City = "Samarkand", FirstName = "John", LastName = "Doe", PhoneNumber = "+998991234567", BirthDate = new DateOnly(1980, 2, 1), TGUserName = "@johndoe", HasDrivingLicense = false },

                new Courier { Id = 4, City = "Tashkent", FirstName = "Rupert", LastName = "Kovalsky", PhoneNumber = "+998991234567", BirthDate = new DateOnly(1978, 5, 13), TGUserName = "@ruppy", HasDrivingLicense = true },

                new Courier { Id = 5, City = "Samarkand", FirstName = "Hariette", LastName = "Willey", PhoneNumber = "+998991234567", BirthDate = new DateOnly(1990, 12, 1), TGUserName = "@hanriette", HasDrivingLicense = false },

                new Courier { Id = 6, City = "Tashkent", FirstName = "Richard", LastName = "Willey", PhoneNumber = "+998991234567", BirthDate = new DateOnly(2000, 12, 21), TGUserName = "@richwill", HasDrivingLicense = true },

                new Courier { Id = 7, City = "London", FirstName = "Gladys", LastName = "Foster", PhoneNumber = "+998991234567", BirthDate = new DateOnly(2004, 3, 22), TGUserName = "@ineedpigden", HasDrivingLicense = false }
                 ) ;

            modelBuilder.Entity<ClientAddress>()
                .HasData
                (   
                    new ClientAddress { Id = 1, City = "Tashkent", HomeNumber = "12", Street = "Istiqbol str", ClientId = 1},
                    new ClientAddress { Id = 2, City = "Tashkent", HomeNumber = "13", Street = "Shakhrisabz str", ClientId = 2},
                    new ClientAddress { Id = 3, City = "Tashkent", HomeNumber = "14", Street = "Amir Temur str", ClientId = 2 },
                    new ClientAddress { Id = 4, City = "Tashkent", HomeNumber = "15", Street = "Istiqbol", ClientId = 3 },
                    new ClientAddress { Id = 5, City = "Tashkent", HomeNumber = "16", Street = "Taras Shevchenko str", ClientId = 4 },
                    new ClientAddress { Id = 6, City = "Tashkent", HomeNumber = "17", Street = "Shastri str", ClientId = 5 },
                    new ClientAddress { Id = 7, City = "Tashkent", HomeNumber = "18", Street = "Oybek str", ClientId = 6}
                );

            modelBuilder.Entity<Client>()
                .HasData
                (
                    new Client { Id = 1, FirstName = "Butch", LastName = "Cassidy", PhoneNumber = "+998901235678"},
                    new Client { Id = 2, FirstName = "Calamity", LastName = "Janet", PhoneNumber = "+998901235678"},
                    new Client { Id = 3, FirstName = "Billy", LastName = "Joel", PhoneNumber = "+998901235678"},
                    new Client { Id = 4, FirstName = "Kit", LastName = "Carson", PhoneNumber = "+998901235678"},
                    new Client { Id = 5, FirstName = "Helga", LastName = "Storm", PhoneNumber = "+998901235678"},
                    new Client { Id = 6, FirstName = "Rose", LastName = "Doolan", PhoneNumber = "+998901235678"}
                );

            modelBuilder.Entity<Order>()
                .HasData
                (
                    new Order { }
                );
            /*modelBuilder.Entity<StoredProcEmployee>()
                .HasNoKey()
                .ToTable("ignored", t => t.ExcludeFromMigrations());*/
        }
    }
}
