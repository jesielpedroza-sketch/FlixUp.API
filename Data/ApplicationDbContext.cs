using FlixUp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FlixUp.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Criador> Criadores => Set<Criador>();
        public DbSet<Conteudo> Conteudos => Set<Conteudo>();
        public DbSet<Playlist> Playlists => Set<Playlist>();
        public DbSet<ItemPlaylist> ItensPlaylist => Set<ItemPlaylist>();

        protected override void OnModelCreating(ModelBuilder b)
        {
            b.Entity<ItemPlaylist>().HasKey(ip => new { ip.PlaylistID, ip.ConteudoID });

            b.Entity<Playlist>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Playlists)
                .HasForeignKey(p => p.UsuarioID)
                .OnDelete(DeleteBehavior.Cascade);

            b.Entity<Conteudo>()
                .HasOne(c => c.Criador)
                .WithMany(cr => cr.Conteudos)
                .HasForeignKey(c => c.CriadorID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

