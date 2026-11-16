using Microsoft.EntityFrameworkCore;
using PcClubApi.Models;

namespace PcClubApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Zone> Zones { get; set; }
    public DbSet<Computer> Computers { get; set; }
    public DbSet<ComputerStatus> ComputerStatuses { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<ComputerStatus>().HasData(
            new ComputerStatus { Id = 1, Name = "Свободен" },
            new ComputerStatus { Id = 2, Name = "Занят" },
            new ComputerStatus { Id = 3, Name = "Сломан" }
        );

        modelBuilder.Entity<Zone>().HasData(
            new Zone { Id = 1, Name = "Standard", PricePerHour = 150, IsVip = false },
            new Zone { Id = 2, Name = "VIP Room", PricePerHour = 400, IsVip = true }
        );

        modelBuilder.Entity<Computer>().HasData(
            new Computer { Id = 1, Name = "PC-01", IpAddress = "192.168.1.10", Specs = "RTX 3060, i5-12400, 16GB RAM | Периферия: Монитор 144Hz, Мышь Logitech G102, Наушники HyperX", ZoneId = 1, StatusId = 1 },
            new Computer { Id = 2, Name = "PC-02", IpAddress = "192.168.1.11", Specs = "RTX 3060, i5-12400, 16GB RAM | Периферия: Монитор 144Hz, Мышь Razer DeathAdder, Клавиатура Redragon", ZoneId = 1, StatusId = 2 },
            new Computer { Id = 3, Name = "VIP-PC-01", IpAddress = "192.168.1.50", Specs = "RTX 4090, i9-13900K, 32GB RAM | Периферия: Монитор 240Hz 4K, Мышь Logitech G Pro X, Клавиатура Wooting 60HE, Наушники Audeze", ZoneId = 2, StatusId = 1 }
        );
    }
} 