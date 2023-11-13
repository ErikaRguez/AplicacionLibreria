using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
   
        public class AutorController : ControllerBase
    {
        private AutorDAO autorDAO = new AccesoDatos.Operaciones.AutorDAO();
        // Consultar todas los libros
        [HttpGet("autores")]
        public ActionResult<IEnumerable<Autor>> GetAutores()
        {
            List<Autor> autor = autorDAO.GetAutores();
            return Ok(autor);
        }
        /**
         * EndPoint para obtener un autor especifico
         * 
         */
        [HttpGet("autor")]
        public Autor getAutor(int id)
        {
            return autorDAO.GetAutor(id);
        }
        /**
         * EndPoint para insertar  un autor
         * 
         */

        [HttpPost("autor")]

        public bool insertar([FromBody] Autor autor, int id)
        {

            return autorDAO.insertar(autor.Id, autor.Name);
        }

        /**
         * EndPoint para actualizar datos del autor
         * 
         */
        [HttpPut("autor")]
        public bool actualizarAutor([FromBody] Autor autor)
        {

            return autorDAO.actualizar(autor.Id, autor.Name);
        }
        

    }
}
