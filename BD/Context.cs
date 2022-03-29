using Microsoft.EntityFrameworkCore;

namespace BD;

public class Context : DbContext
{
    public Context() : base()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer("Data Source=DESKTOP-IPAEN72;Initial Catalog=ShopBD;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        optionsBuilder.UseInMemoryDatabase("AthShopTest");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<ProduktWSklepie>().HasKey(x => new { x.SklepID, x.ProduktId });
        
        modelBuilder.Entity<ProduktWSklepie>()
            .HasOne(x => x.Sklep)
            .WithMany(x => x.ProduktWSklepie)
            .HasForeignKey(x => x.SklepID);

        modelBuilder.Entity<ProduktWSklepie>()
            .HasOne(x => x.Produkt)
            .WithMany(x => x.ProduktWSklepie)
            .HasForeignKey(x => x.ProduktId);
    }
    

    public DbSet<Produkt> Products { get; set; }
    public DbSet<ProduktWSklepie> ShopProducts { get; set; }
    public DbSet<Sklep> Shops { get; set; }
    public DbSet<SzczegolyZamowienia> OrderDetails { get; set; }
    public DbSet<Zamowienia> Orders { get; set; }
    public DbSet<Kategoria> Categories { get; set; }

}
