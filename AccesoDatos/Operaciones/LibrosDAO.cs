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
    public class LibrosDAO
    {
        // Creamos un objeto de contexto de BD
        LibreriaContext contexto = new LibreriaContext();

        // Método para todos los libros
        public List<Libros> GetLibros()
        {
            var libros = contexto.Libros.Include(a => a.Author).ToList();
            return libros;
        }

        // Método para un libro en específico por ID
        public Libros GetLibro(int id)
        {
            var libro = contexto.Libros.Include(a => a.Author).FirstOrDefault(libro => libro.Id == id);
            return libro;
        }

        // Método para insertar un nuevo libro en la BD
        public bool Insertar(Libros libro)
        {
            try
            {
                contexto.Libros.Add(libro);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        // Método para actualizar los datos de un libro en la BD
        public bool Actualizar(Libros libro)
        {
            try
            {
                var libros = contexto.Libros.Find(libro.Id);
                if (libros == null)
                {
                    return false;
                }
                else
                {
                    // Actualizar propiedades del libro según sea necesario
                    libros.Title = libro.Title;
                    libros.Chapters = libro.Chapters;
                    libros.Pages = libro.Pages;
                    libros.Price = libro.Price;
                    libros.AuthorId = libro.AuthorId;

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
