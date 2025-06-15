namespace WebApp_Sample.Infrastructures.Context;
using Microsoft.EntityFrameworkCore;
using WebApp_Sample.Infrastructures.Entities;
public class AppDbContext : DbContext{

    public DbSet<EmmployeeEntity> Employees { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}