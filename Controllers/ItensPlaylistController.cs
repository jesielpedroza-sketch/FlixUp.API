using FlixUp.API.Data;
using FlixUp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlixUp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItensPlaylistController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ItensPlaylistController(ApplicationDbContext db)
        {
            _db = db;
        }

        // POST: api/ItensPlaylist
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddItem([FromBody] ItemPlaylist item)
        {
            var playlist = await _db.Playlists.FindAsync(item.PlaylistID);
            if (playlist == null)
                return NotFound(new { message = "Playlist não encontrada." });

            var conteudo = await _db.Conteudos.FindAsync(item.ConteudoID);
            if (conteudo == null)
                return NotFound(new { message = "Conteúdo não encontrado." });

            _db.ItensPlaylist.Add(item);
            await _db.SaveChangesAsync();

            return Ok(item);
        }

        // GET: api/ItensPlaylist/{playlistId}
        [HttpGet("{playlistId}")]
        [Authorize]
        public async Task<IActionResult> GetItens(int playlistId)
        {
            var itens = await _db.ItensPlaylist
                .Include(i => i.Conteudo)
                .Where(i => i.PlaylistID == playlistId)
                .ToListAsync();

            return Ok(itens);
        }

        // DELETE: api/ItensPlaylist/{id}
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _db.ItensPlaylist.FindAsync(id);
            if (item == null)
                return NotFound(new { message = "Item não encontrado." });

            _db.ItensPlaylist.Remove(item);
            await _db.SaveChangesAsync();

            return Ok(new { message = "Item removido com sucesso." });
        }
    }
}
