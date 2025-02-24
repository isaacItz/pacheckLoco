using Aplication.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SistemaCreditos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario usuario)
        {
            if (usuario.Email == "admin@sistemacreditos.com" && usuario.PasswordHash == "123456") // Simulación de autenticación
            {
                var token = _authService.GenerarToken(usuario);
                return Ok(new { token });
            }

            return Unauthorized("Credenciales inválidas");
        }
    }
}
