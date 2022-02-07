using System.ComponentModel.DataAnnotations;

namespace Victor_Estevez_Ap1_p1.Entidades
{
    public class Producto
    {
        [key]
        public int ProductoId {get; set;}

        public string Descripcion {get; set;}

        public bool Existencia {get; set;}

        public float Costo {get; set;}

        public float ValorInventario {get; set;}
        
        //ProductoId, Descripcion, Existencia, Costo y ValorInventario
    
    }
}