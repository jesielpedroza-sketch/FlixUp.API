using FlixUp.API.Models;
using FlixUp.API.Repository;   // <- mantenha só este
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlixUp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize]  // Habilite depois que o JWT estiver configurado no Program.cs
    public class PlaylistsController : ControllerBase
    {
        private readonly IPlaylistRepository _playlistRepository;

        public PlaylistsController(IPlaylistRepository playlistRepository)
        {
            _playlistRepository = playlistRepository;
        }

        // POST api/playlists
        [HttpPost]
        // [Authorize(Roles = "Criador, Admin")]
        public IActionResult PostPlaylist([FromBody] Playlist playlist)
        {
            if (playlist is null) return BadRequest();

            _playlistRepository.AddPlaylist(playlist);
            _playlistRepository.Save(); // IMPORTANTE
            return CreatedAtAction(nameof(GetPlaylist), new { id = playlist.ID }, playlist);
        }

        // GET api/playlists
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<Playlist>> GetAllPlaylists()
        {
            var playlists = _playlistRepository.GetAllPlaylists();
            return Ok(playlists);
        }

        // GET api/playlists/5
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public ActionResult<Playlist> GetPlaylist(int id)
        {
            var playlist = _playlistRepository.GetPlaylistByID(id);
            return playlist is null ? NotFound() : Ok(playlist);
        }

        // PUT api/playlists/5
        [HttpPut("{id:int}")]
        // [Authorize(Roles = "Criador, Admin")]
        public IActionResult PutPlaylist(int id, [FromBody] Playlist playlist)
        {
            if (playlist is null || id != playlist.ID) return BadRequest();

            _playlistRepository.UpdatePlaylist(playlist);
            _playlistRepository.Save(); // IMPORTANTE
            return NoContent();
        }

        // DELETE api/playlists/5
        [HttpDelete("{id:int}")]
        // [Authorize(Roles = "Criador, Admin")]
        public IActionResult DeletePlaylist(int id)
        {
            _playlistRepository.DeletePlaylist(id);
            _playlistRepository.Save(); // IMPORTANTE
            return NoContent();
        }
    }
}
