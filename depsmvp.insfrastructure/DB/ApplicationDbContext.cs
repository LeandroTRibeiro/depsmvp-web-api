using depsmvp.domain.Entities;
using depsmvp.domain.Entities.Company;
using Microsoft.EntityFrameworkCore;

namespace depsmvp.insfrastructure.DB;

public class ApplicationDbContext : DbContext
{
    public DbSet<Pep> Peps { get; set; } = null!;
    public DbSet<PepsConsult> PepConsults { get; set; } = null!;
    
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Consult> Consults { get; set; } = null!;
    public DbSet<CompanyConsult> CompanyConsults { get; set; } = null!;
    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<CnaesSecundario> CnaesSecundarios { get; set; } = null!;
    public DbSet<Qsa> Qsas { get; set; } = null!;
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PepsConsult>()
            .HasKey(pc => new { pc.PepId, pc.ConsultId });
        
        modelBuilder.Entity<CompanyConsult>()
            .HasKey(cc => new { cc.CompanyId, cc.ConsultId });
        
        modelBuilder.Entity<Consult>()
            .HasOne(c => c.User)
            .WithMany(u => u.Consults)
            .HasForeignKey(c => c.UserId);
        
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