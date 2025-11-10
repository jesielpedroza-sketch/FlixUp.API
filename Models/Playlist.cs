namespace FlixUp.API.Models
{
    public class Playlist
    {
        public int ID { get; set; }
        public string Nome { get; set; } = string.Empty;

        public int UsuarioID { get; set; }
        public Usuario? Usuario { get; set; }

        public List<ItemPlaylist> Itens { get; set; } = new();
    }
}
