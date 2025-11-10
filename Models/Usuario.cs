using FlixUp.API.Models;
using System.Text.Json.Serialization;

public class Usuario
{
    public int ID { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string SenhaHash { get; set; } = string.Empty;
    public string Papel { get; set; } = "Cliente";

    [JsonIgnore]                // evita ciclo: Usuario → Playlists → Usuario → ...
    public List<Playlist> Playlists { get; set; } = new();
}
