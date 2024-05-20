using apirest.context;
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
    }
}
