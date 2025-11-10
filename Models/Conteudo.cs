using FlixUp.API.Models;
using System.Text.Json.Serialization;

public class Conteudo
{
    public int ID { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;

    public int CriadorID { get; set; }
    public Criador? Criador { get; set; }

    [JsonIgnore]                // evita ciclo: Conteudo → Itens → Playlist → Itens → ...
    public List<ItemPlaylist> Itens { get; set; } = new();
}

