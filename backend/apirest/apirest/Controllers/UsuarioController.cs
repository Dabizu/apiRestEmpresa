using apirest.context;
using apirest.model;
using Microsoft.AspNetCore.Mvc;

namespace apirest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private BaseContext contextB;
        public UsuarioController(BaseContext context) {
            this.contextB = context;
        }
        //para inciiar sesion en el login
        [HttpPost("/login")]
        public IActionResult login(string correo, string password) {
            var usuarios=this.contextB.Usuarios;
            var result=usuarios.Where(usuarios=>usuarios.correo.Equals(correo) && usuarios.password.Equals(password)).FirstOrDefault();
            if(result!=null)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }
        //para listar los usuarios
        [HttpGet("/listarUsuarios")]
        public IEnumerable<Usuario> listarUsuarios()
        {
            return contextB.Usuarios.ToList();
        }
        //para buscar por usuario
        [HttpGet("/buscarUsuario")]
        public IActionResult buscaUsuario(string username) 
        { 
            var usuarios=contextB.Usuarios;
            var result=usuarios.Where(usuarios=> usuarios.username.Equals(username)).FirstOrDefault();
            return Ok(result);
        }
        //eliminacion
        [HttpDelete("/eliminarUsuario")]
        public IActionResult eliminarUsuario(Usuario usuario) {
            var resultado = this.contextB.Usuarios.Remove(usuario);
            this.contextB.SaveChanges();
            if(resultado != null)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

        //actualizar usuario
        [HttpPut("/actualizacionUsuario")]
        public IActionResult modificarUsuario(Usuario usuario)
        {
            var resultado = this.contextB.Usuarios.Update(usuario);
            this.contextB.SaveChanges();
            if (resultado != null)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }


        //registrar usuario
        [HttpPost("/registrarUsuario")]
        public IActionResult registrarUsuario(Usuario usuario)
        {
            var resultado=this.contextB.Usuarios.Add(usuario);
            this.contextB.SaveChanges();
            if (resultado != null)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }

    }
}
