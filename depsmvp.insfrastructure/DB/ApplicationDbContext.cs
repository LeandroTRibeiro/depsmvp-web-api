using depsmvp.domain.Entities.Company;
using Microsoft.EntityFrameworkCore;

namespace depsmvp.insfrastructure.DB;

public class ApplicationDbContext : DbContext
{
    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<CnaesSecundario> CnaesSecundarios { get; set; } = null!;
    public DbSet<Qsa> Qsas { get; set; } = null!;
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CnaesSecundario>()
            .HasOne(c => c.Company)
            .WithMany(c => c.CnaesSecundarios)
            .HasForeignKey(c => c.CompanyId);
        
        modelBuilder.Entity<Qsa>()
            .HasOne(c => c.Company)
            .WithMany(c => c.Qsa)
            .HasForeignKey(c => c.CompanyId);
    }
}