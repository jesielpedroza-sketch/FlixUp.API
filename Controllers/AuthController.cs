using FlixUp.API.Data;
using FlixUp.API.Models;
using FlixUp.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlixUp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IAuthService _auth;

        public AuthController(ApplicationDbContext db, IAuthService auth)
        {
            _db = db;
            _auth = auth;
        }

        // POST /api/Auth/login
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var user = await _db.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email.ToLower() == model.Email.ToLower());

            if (user is null)
                return Unauthorized(new { message = "Credenciais inválidas." });

            // >>>> DEV: senha em texto (combina com o seu DbSeeder) <<<<
            if (user.SenhaHash != model.Senha)
                return Unauthorized(new { message = "Credenciais inválidas." });

            var token = _auth.GerarToken(user);
            return Ok(new { token });
        }

        // (opcional) debug para ver usuários seedados
        [HttpGet("debug-users")]
        [AllowAnonymous]
        public async Task<IActionResult> DebugUsers()
        {
            var users = await _db.Usuarios
                .Select(u => new { u.ID, u.Nome, u.Email, u.Papel })
                .ToListAsync();
            return Ok(users);
        }
    }
}
