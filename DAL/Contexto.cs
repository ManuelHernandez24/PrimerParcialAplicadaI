using Microsoft.EntityFrameworkCore;
using Victor_Estevez_Ap1_p1.Entidades;

public class Contexto:DbContext{
    public DbSet<Ejemplo> Ejemplo {get; set }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
         optionsBuilder.UseSqlite(@"Data Source=Data\Ejemplo.db");
    }
}