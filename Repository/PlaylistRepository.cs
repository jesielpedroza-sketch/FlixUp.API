using FlixUp.API.Data;
using FlixUp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FlixUp.API.Repository
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly ApplicationDbContext _ctx;
        public PlaylistRepository(ApplicationDbContext ctx) => _ctx = ctx;

        public List<Playlist> GetAllPlaylists() =>
            _ctx.Playlists
                .Include(p => p.Usuario)
                .Include(p => p.Itens).ThenInclude(i => i.Conteudo)
                .AsNoTracking()
                .ToList();

        public Playlist? GetPlaylistByID(int id) =>
            _ctx.Playlists
                .Include(p => p.Usuario)
                .Include(p => p.Itens).ThenInclude(i => i.Conteudo)
                .FirstOrDefault(p => p.ID == id);

        public void AddPlaylist(Playlist playlist) => _ctx.Playlists.Add(playlist);
        public void UpdatePlaylist(Playlist playlist) => _ctx.Playlists.Update(playlist);

        public void DeletePlaylist(int id)
        {
            var p = _ctx.Playlists.Find(id);
            if (p != null) _ctx.Playlists.Remove(p);
        }

        public void Save() => _ctx.SaveChanges();
    }
}
