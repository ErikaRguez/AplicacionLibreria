using AccesoDatos.Context;
using AccesoDatos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operaciones
{
   public class AutorDAO
    {
        // Creamos un objeto de contexto de BD
       LibreriaContext contexto = new LibreriaContext();

        // Método para todos los autores
        public List<Autor> GetAutores()
        {
            var autores = contexto.Autor.Include(l => l.Libros).ToList<Autor>();
            return autores;
        }
        // Método para  un autor en específico
        public Autor GetAutor(int id)
        {
            var autor = contexto.Autor.Include(l => l.Libros).Where(a => a.Id == id).FirstOrDefault();
            return autor;
        }
        // Método para insertar un nuevo autor en la BD
        public bool insertar(int id, string name)
        {
            try
            {
                Autor autor = new Autor();
                autor.Id = id;
                autor.Name = name;
                
                contexto.Autor.Add(autor);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        // Método para actualizar los datos de un autor en la BD
        public bool actualizar(int id, string name)
        {
            try
            {
                var autor = GetAutor(id);
                if (autor == null)
                {
                    return false;
                }
                else
                {
                   
                    autor.Id = id;
                    autor.Name = name;
                    contexto.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
       
    }
}
