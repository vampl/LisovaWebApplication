using Lisova.Services.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lisova.Services.Context.Data;

public class LisovaContext : DbContext
{
    private const string ConnectionString = "Data Source=./LisovaEmployees.db;Mode=Memory;Cache=Shared;";
    
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
        ConfigureEmployeeEntity(modelBuilder);
        
        ConfigureEmployeePositionEntity(modelBuilder);
        ConfigureEmployeeDepartmentEntity(modelBuilder);
        
        ConfigurePositionEntity(modelBuilder);
        ConfigureDepartmentEntity(modelBuilder);
    }

    private void ConfigureEmployeeEntity(ModelBuilder modelBuilder)
    {
        // Configure key value of Employee.
        modelBuilder.Entity<Employee>()
            .HasKey(e => e.EmployeeNo);

        modelBuilder.Entity<Employee>()
            .Property(e => e.EmployeeNo)
            .HasDefaultValueSql("10000");

        // Configure date containing column to only date.
        modelBuilder.Entity<Employee>()
            .Property(e => e.BirthDate)
            .HasColumnType("date");
        
        // Configure relationship between Employee-EmployeePositions.
        modelBuilder.Entity<Employee>()
            .HasMany(e => e.EmployeePositions)
            .WithOne(ep => ep.Employee)
            .HasForeignKey(ep => ep.EmployeeNo)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Configure relationship between Employee-EmployeeDepartments.
        modelBuilder.Entity<Employee>()
            .HasMany(e => e.EmployeeDepartments)
            .WithOne(ed => ed.Employee)
            .HasForeignKey(ed => ed.EmployeeNo)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private void ConfigureEmployeePositionEntity(ModelBuilder modelBuilder)
    {
        // Configure key value of EmployeePosition.
        modelBuilder.Entity<EmployeePosition>()
            .HasKey(ep => new { ep.EmployeeNo, ep.PositionCode });

        // Configure date containing columns to only date.
        modelBuilder.Entity<EmployeePosition>()
            .Property(ep => ep.From)
            .HasColumnType("date");

        modelBuilder.Entity<EmployeePosition>()
            .Property(ep => ep.To)
            .HasColumnType("date");
        
        // Configure relationship between EmployeePositions-Employee.
        modelBuilder.Entity<EmployeePosition>()
            .HasOne(ep => ep.Employee)
            .WithMany(e => e.EmployeePositions)
            .HasForeignKey(ep => ep.EmployeeNo);
        
        // Configure relationship between EmployeePositions-Position.
        modelBuilder.Entity<EmployeePosition>()
            .HasOne(ep => ep.Position)
            .WithMany(p => p.EmployeePositions)
            .HasForeignKey(ep => ep.PositionCode);
    }

    private void ConfigureEmployeeDepartmentEntity(ModelBuilder modelBuilder)
    {
        // Configure key value of EmployeeDepartment.
        modelBuilder.Entity<EmployeeDepartment>()
            .HasKey(ed => new { ed.EmployeeNo, ed.DepartmentCode });

        // Configure date containing columns to only date.
        modelBuilder.Entity<EmployeeDepartment>()
            .Property(ed => ed.From)
            .HasColumnType("date");

        modelBuilder.Entity<EmployeeDepartment>()
            .Property(ed => ed.To)
            .HasColumnType("date");
        
        // Configure relationship between EmployeeDepartments-Employee.
        modelBuilder.Entity<EmployeeDepartment>()
            .HasOne(ed => ed.Employee)
            .WithMany(e => e.EmployeeDepartments)
            .HasForeignKey(ed => ed.EmployeeNo);
        
        // Configure relationship between EmployeeDepartments-Position.
        modelBuilder.Entity<EmployeeDepartment>()
            .HasOne(ed => ed.Department)
            .WithMany(d => d.EmployeeDepartments)
            .HasForeignKey(ed => ed.DepartmentCode);
    }

    private void ConfigurePositionEntity(ModelBuilder modelBuilder)
    {
        // Configure key value of EmployeeDepartment.
        modelBuilder.Entity<Position>()
            .HasKey(p => p.PositionCode);

        // Configure salary to decimal proper format.
        modelBuilder.Entity<Position>()
            .Property(p => p.Salary)
            .HasPrecision(10, 2);
    }

    private void ConfigureDepartmentEntity(ModelBuilder modelBuilder)
    {
        // Configure key value of EmployeeDepartment.
        modelBuilder.Entity<Department>()
            .HasKey(d => d.DepartmentCode);
    }
}