using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private LibrosDAO librosDAO = new AccesoDatos.Operaciones.LibrosDAO();
        // Consultar todas los libros
        [HttpGet("libros")]
        public ActionResult<IEnumerable<Libros>> GetLibros()
        {
            List<Libros> libros = librosDAO.GetLibros();
            return Ok(libros);
        }

        // Obtener un libro específico por ID
        [HttpGet("libro")]
        public Libros GetLibro(int id)
        {
            return librosDAO.GetLibro(id);
        }

        /**
         * EndPoint para insertar  un libro
         * 
         */

        [HttpPost("libro")]

        public bool InsertarLibro([FromBody] Libros libro)
        {
            return librosDAO.Insertar(libro);
        }

        /**
         * EndPoint para actualizar datos del libro
         * 
         */
        [HttpPut("libro")]
        public bool ActualizarLibro([FromBody] Libros libro)
        {
            return librosDAO.Actualizar(libro);
        }
    }
}

   
