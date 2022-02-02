using System;
using Victor_Estevez_Ap1_p1.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Ejemplo.BLL
{
    public class EjemploBLL
    {

        public static bool Existe(int ejemploId)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Ejemplo.Any(l => l.EjemploId == EjemploId);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static bool Guardar(Ejemplo ejemplo)
        {
            if (!Existe(ejemplo.EjemploId))
                return Insertar(ejemplo);
            else
                return Modificar(ejemplo);

        }

        private static bool Insertar(Ejemplo ejemplo)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Ejemplo.Add(ejemplo);
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        private static bool Modificar(Ejemplo ejemplo)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Entry(ejemplo).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int ejemploId)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                var ejemplo = contexto.Ejemplo.Find(ejemploId);
                if (ejemplo != null)
                {
                    contexto.Ejemplo.Remove(ejemplo);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Ejemplo? Buscar(int ejemploId)
        {
            Contexto contexto = new Contexto();
            Ejemplo? ejemplo;
            try
            {
                ejemplo = contexto.ejemplo.Find(ejemploId);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return ejemplo;
        }

        public static List<Ejemplo> GetList(Expression<Func<Ejemplo, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Ejemplo> lista = new List<Ejemplo>();
            try
            {
                lista = contexto.Ejemplo.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }

}