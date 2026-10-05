using Microsoft.EntityFrameworkCore;
using PcClubApi.Models;

namespace PcClubApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Zone> Zones { get; set; }
    public DbSet<Computer> Computers { get; set; }
    public DbSet<ComputerStatus> ComputerStatuses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ComputerStatus>().HasData(
            new ComputerStatus { Id = 1, Name = "Свободен" },
            new ComputerStatus { Id = 2, Name = "Занят" },
            new ComputerStatus { Id = 3, Name = "Сломан" }
        );
    }
}