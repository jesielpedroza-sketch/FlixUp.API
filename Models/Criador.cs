using System.Text.Json.Serialization;

public class Criador
{
    public int ID { get; set; }
    public string Nome { get; set; } = string.Empty;

    [JsonIgnore]                // evita ciclos por navegação invertida
    public List<Conteudo> Conteudos { get; set; } = new();
}
