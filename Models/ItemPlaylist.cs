using FlixUp.API.Models;
using System.Text.Json.Serialization;

public class ItemPlaylist
{
    public int PlaylistID { get; set; }

    [JsonIgnore]                // evita ciclo: Item → Playlist → Itens → ...
    public Playlist? Playlist { get; set; }

    public int ConteudoID { get; set; }
    public Conteudo? Conteudo { get; set; }
}
