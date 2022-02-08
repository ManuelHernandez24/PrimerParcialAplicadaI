using System;
using Victor_Estevez_Ap1_p1.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Victor_Estevez_Ap1_p1.BLL
{
    public class ProductoBLL
    {
        
        public static bool Existe(int productoId){
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try {
                encontrado = contexto.Producto.Any(l => l.ProductoId == productoId);
            } catch (Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }
            return encontrado;
        }

        public static bool Guardar(Producto producto){
            if(!Existe(producto.ProductoId)){
                return Insertar(producto);
            }else{
                return Modificar(producto);
            }
        }

        public static bool Insertar(Producto producto){
            Contexto contexto = new Contexto();
            bool paso = false;

            try{
                contexto.Producto.Add(producto);
                paso = contexto.SaveChanges() > 0;
            } catch(Exception){
                throw;
            }finally{
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Producto producto){
            Contexto contexto = new Contexto();
            bool paso = false;
            try{
                contexto.Entry(producto).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            } catch(Exception){
                throw;
            } finally{
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int productoId){
            Contexto contexto = new Contexto();
            bool paso = false;
            try{
                var producto = contexto.Producto.Find(productoId);
                if(producto != null){
                    contexto.Producto.Remove(producto);
                    paso = contexto.SaveChanges() > 0;
                }
            }catch(Exception){
                throw;
            } finally{
                contexto.Dispose();
            }
            return paso;
        }

        public static Producto? Buscar(int productoId){
            Contexto contexto = new Contexto();
            Producto ?producto;
            bool paso = false;
            try{
                producto = contexto.Producto.Find(productoId);
            } catch(Exception){
                throw;
            }finally{
                contexto.Dispose();
            }
            return producto;
        }

        public static List<Producto> GetList (Expression<Func<Producto, bool >> criterio){
            Contexto contexto = new Contexto();
            List<Producto> lista = new List<Producto>();

            try{
                lista = contexto.Producto.Where(criterio).ToList();
            }catch(Exception){
                throw;
            } finally{
                contexto.Dispose();
            }
            return lista;
        }    

        public static List<Producto> GetLista(){
            List<Producto> lista = new List<Producto>();
            Contexto contexto = new Contexto();

            try{
                lista = contexto.Producto.ToList();
            }catch(Exception){
                throw;
            } finally{
                contexto.Dispose();
            }
            return lista;
        }      
    }

}
