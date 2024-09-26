using System.Text.Json.Serialization;

namespace depsmvp.domain.Entities.Company;

public class CnaesSecundario
{
    [JsonPropertyName("codigo")]
    public int? Codigo { get; set; }

    [JsonPropertyName("descricao")]
    public string? Descricao { get; set; }
}