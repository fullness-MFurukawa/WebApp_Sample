namespace WebApp_Sample.Infrastructures.Context;
using Microsoft.EntityFrameworkCore;
using WebApp_Sample.Infrastructures.Entities;
/// <summary>
/// samplesテーブルにアクセスするDBContextの継承
/// </summary>
public class AppDbContext : DbContext{

    public DbSet<EmployeeEntity> Employees { get; set; }       = null!;
    public DbSet<DepartmentEntity> Departments { get; set; }    = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}