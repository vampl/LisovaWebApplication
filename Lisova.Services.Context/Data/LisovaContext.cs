using Lisova.Services.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lisova.Services.Context.Data;

public class LisovaContext : DbContext
{
    private const string ConnectionString = "Data Source=./Enterprise.db";
    
    public LisovaContext() { }

    public LisovaContext(DbContextOptions<LisovaContext> contextOptions) : base(contextOptions) { }

    public DbSet<Employee> Employees { get; set; } = default!;
    
    public DbSet<EmployeePosition> EmployeePositions { get; set; } = default!;
    
    public DbSet<EmployeeDepartment> EmployeeDepartments { get; set; } = default!;
    
    public DbSet<Position> Positions { get; set; } = default!;
    
    public DbSet<Department> Departments { get; set; } = default!;
    
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
            .HasKey(e => e.EmployeeNo);

        modelBuilder.Entity<Employee>()
            .Property(e => e.EmployeeNo)
            .HasDefaultValueSql("NEXT VALUE FOR EmployeeNoSequence");

        modelBuilder.Entity<Employee>()
            .Property(e => e.BirthDate)
            .HasColumnType("date");
        
        modelBuilder.Entity<EmployeePosition>()
            .HasKey(ep => new { ep.EmployeeNo, ep.PositionCode });

        modelBuilder.Entity<EmployeePosition>()
            .Property(ep => ep.From)
            .HasColumnType("date");

        modelBuilder.Entity<EmployeePosition>()
            .Property(ep => ep.To)
            .HasColumnType("date");
        
        modelBuilder.Entity<EmployeeDepartment>()
            .HasKey(ed => new { ed.EmployeeNo, ed.DepartmentCode });

        modelBuilder.Entity<EmployeeDepartment>()
            .Property(ed => ed.From)
            .HasColumnType("date");

        modelBuilder.Entity<EmployeeDepartment>()
            .Property(ed => ed.To)
            .HasColumnType("date");
    }
}