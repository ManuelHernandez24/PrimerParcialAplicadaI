using Microsoft.EntityFrameworkCore;
using Victor_Estevez_Ap1_p1.Entidades;

public class Contexto:DbContext{
    public DbSet<Producto> Producto {get; set }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
         optionsBuilder.UseSqlite(@"Data Source=Data\Producto.db");
    }
}