using Car.Demo.Common.Enums;
using Car.Demo.DLL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Car.Demo.DLL;
using Car = Entities.Car;

public class CarDbContext: DbContext
{
    #region DbSets

    public DbSet<User>? Users { get; set; }
    
    public DbSet<Car>? Cars { get; set; }
    
    public DbSet<Company>? Companies { get; set; }

    #endregion

    public CarDbContext(DbContextOptions<CarDbContext> options): base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.EnableDetailedErrors();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Configuring

        var user = modelBuilder.Entity<User>();
        user.HasKey(x => x.Id);
        user.HasIndex(x => x.Email)
            .IsUnique();
        user.HasMany(u => u.Cars)
            .WithOne(c => c.Publisher);
        user.Property(x => x.Email)
            .IsRequired();
        user.Property(x => x.Name)
            .IsRequired();
        user.Property(x => x.PhoneNumber)
            .IsRequired();
        user.Property(x => x.Role)
            .HasDefaultValue(RoleTypes.Consumer)
            .IsRequired();
        user.Property(x => x.HashPassword)
            .IsRequired();
        user.Property(x => x.LastChanged)
            .HasDefaultValueSql("GetUtcDate()")
            .IsRequired();
        
        var car = modelBuilder.Entity<Car>();

        car.HasKey(x => x.Id);
        car.Property(x => x.Brand).IsRequired();
        car.Property(x => x.Model).IsRequired();
        car.Property(x => x.Price).IsRequired();
        car.Property(x => x.Country).IsRequired();

        var company = modelBuilder.Entity<Company>();
        
        company.HasKey(x => x.Id);
        company.Property(x => x.Name).IsRequired();

        user.HasMany(x => x.Companies)
            .WithMany(x => x.Users)
            .UsingEntity<Subscription>(
                builder => builder.HasOne(s => s.Company)
                    .WithMany(c => c.Subscriptions)
                    .HasForeignKey(s => s.CompanyId),
                builder => builder.HasOne(s => s.User)
                    .WithMany(u => u.Subscriptions)
                    .HasForeignKey(s => s.UserId),
                builder =>
                {
                    builder.HasKey(s => new { s.UserId, s.CompanyId });
                    builder.ToTable("Subscription");
                }
            );
        
        #endregion
        
        #region Seeding

        modelBuilder.Entity<User>()
            .HasData(
                new User()
                {
                    Id = Guid.Parse("dd2e3a6b-ec8f-4e9f-a72c-57e08f779f58"),
                    Name = "Celeste Bassett",
                    Email = "c.basset@gmail.com",
                    HashPassword = BCrypt.Net.BCrypt.HashPassword("CB123@!"),
                    PhoneNumber = "0683006027",
                    Role = RoleTypes.Admin,
                },
                new User()
                {
                    Id = Guid.Parse("26af7842-53e0-4680-96cb-8c02a696e59f"),
                    Name = "Lacey Wilkins",
                    Email = "l.wilkins@gmail.com",
                    HashPassword = BCrypt.Net.BCrypt.HashPassword("LW123@!"),
                    PhoneNumber = "0683006024",
                    Role = RoleTypes.Manager,
                },
                new User()
                {
                    Id = Guid.Parse("7e892c70-763f-456e-b392-cb9211e681d3"),
                    Name = "Safwan Newman",
                    Email = "s.newman@gmail.com",
                    HashPassword = BCrypt.Net.BCrypt.HashPassword("SN123@!"),
                    PhoneNumber = "0683006024",
                    Role = RoleTypes.Consumer,
                }
            );

        modelBuilder.Entity<Car>()
            .HasData(
                new Car()
                {
                    Id = Guid.Parse("ca0cde35-50b0-49e5-8534-f0aa08115d76"),
                    Brand = "Mercedes",
                    Model = "CLS",
                    Country = "Germany",
                    PublisherId = Guid.Parse("dd2e3a6b-ec8f-4e9f-a72c-57e08f779f58"),
                    Price = 30000
                },
                new Car()
                {
                    Id = Guid.Parse("73e35e11-ec5c-477b-a491-b8ce2bb5e922"),
                    Brand = "BMW",
                    Model = "X5",
                    Country = "Germany",
                    PublisherId = Guid.Parse("dd2e3a6b-ec8f-4e9f-a72c-57e08f779f58"),
                    Price = 25000
                },
                new Car()
                {
                    Id = Guid.Parse("7dc52b77-dbce-4fd7-b48a-069dbc2d5b40"),
                    Brand = "Audi",
                    Model = "A5",
                    Country = "Germany",
                    PublisherId = Guid.Parse("dd2e3a6b-ec8f-4e9f-a72c-57e08f779f58"),
                    Price = 20000
                }
            );

        modelBuilder.Entity<Company>()
            .HasData(
                new Company()
                {
                    Id = Guid.Parse("a9ac07e2-2402-480d-9b3e-fcd0da8d2f64"),
                    Name = "Mercedes-benz"
                },
                new Company()
                {
                    Id = Guid.Parse("bc0a09f3-0fdd-4a8b-a419-86235a775760"),
                    Name = "Audi"
                },
                new Company()
                {
                    Id = Guid.Parse("7ac01ada-b23d-4fa8-8b45-a5f6ef0847c8"),
                    Name = "BMW"
                }
            );

        #endregion
    }
}