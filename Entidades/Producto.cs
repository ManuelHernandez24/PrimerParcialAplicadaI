using System.ComponentModel.DataAnnotations;

namespace Victor_Estevez_Ap1_p1.Entidades
{
    public class Producto
    {
        [Key]
        public int ProductoId {get; set;}
        public string Descripcion {get; set;}
        public float Existencia {get; set;}
        public float Costo {get; set;}
        public float ValorInventario {get; set;}
        
        //ProductoId, Descripcion, Existencia, Costo y ValorInventario
    }
}