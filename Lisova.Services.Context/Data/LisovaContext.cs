using Lisova.Services.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lisova.Services.Context.Data;

public class LisovaContext : DbContext
{
    private const string ConnectionString = "Data Source=./Enterprise.db";
    
    public LisovaContext() { }

    public LisovaContext(DbContextOptions<LisovaContext> contextOptions) : base(contextOptions) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Position>()
            .HasKey(p => p.PositionCode);

        modelBuilder.Entity<Position>()
            .Property(p => p.Salary)
            .HasPrecision(10, 2);
        
        modelBuilder.Entity<Department>()
            .HasKey(d => d.DepartmentCode);
        
        modelBuilder.Entity<Employee>()
            .HasKey(e => e.EmployeeNo); // Set EmployeeNo as the unique key

        modelBuilder.Entity<Employee>()
            .Property(e => e.EmployeeNo)
            .HasDefaultValueSql("NEXT VALUE FOR EmployeeNoSequence"); // Use a sequence for EmployeeNo

        modelBuilder.Entity<Employee>()
            .Property(e => e.BirthDate)
            .HasColumnType("date");
    }
}