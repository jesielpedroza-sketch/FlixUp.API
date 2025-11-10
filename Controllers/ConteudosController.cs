using FlixUp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlixUp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConteudosController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ConteudosController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: /api/Conteudos
        // Lista conteúdos com informações essenciais (sem ciclos)
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var data = await _db.Conteudos
                .AsNoTracking()
                .Include(c => c.Criador)
                .Select(c => new
                {
                    c.ID,
                    c.Titulo,
                    c.Tipo,
                    Criador = new { c.CriadorID, c.Criador!.Nome }
                })
                .ToListAsync();

            return Ok(data);
        }

        // GET: /api/Conteudos/5
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var c = await _db.Conteudos
                .AsNoTracking()
                .Include(x => x.Criador)
                .Where(x => x.ID == id)
                .Select(x => new
                {
                    x.ID,
                    x.Titulo,
                    x.Tipo,
                    Criador = new { x.CriadorID, x.Criador!.Nome }
                })
                .FirstOrDefaultAsync();

            if (c is null) return NotFound();
            return Ok(c);
        }
    }
}

