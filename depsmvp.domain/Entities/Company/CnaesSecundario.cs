using System.Text.Json.Serialization;

namespace depsmvp.domain.Entities.Company;

public class CnaesSecundario
{
    public int Id { get; set; }

    [JsonPropertyName("codigo")] public int? Codigo { get; set; }

    [JsonPropertyName("descricao")] public string? Descricao { get; set; }

    public int CompanyId { get; set; }
    public Company? Company { get; set; }
}