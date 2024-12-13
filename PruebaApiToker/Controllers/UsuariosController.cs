using Microsoft.AspNetCore.Mvc;
using NLog;
using PruebaApiToker.Models;

namespace PruebaApiToker.Controllers
{
    [ApiController]
    public class UsuariosController : Controller
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private static readonly List<Usuario> Usuarios = [];

        [Route("RecibirUsuario")]
        [HttpPost]
        public IActionResult RegistrarUsuario([FromBody] Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.Nombre) || string.IsNullOrEmpty(usuario.Telefono))
            {
                return BadRequest("Verifique datos. Faltan datos obligatorios.");
            }

            //Guardar Usuario
            Usuarios.Add(usuario);

            //Enviar Mensaje
            Logger.Info($"Mensaje de bienvenida enviado a {usuario.Nombre} al teléfono {usuario.Telefono}");

            return Ok(new { mensaje = "Datos recibidos y almacenados exitosamente." });
        }
    }
}
