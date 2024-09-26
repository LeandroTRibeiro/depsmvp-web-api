using System.Text.Json.Serialization;

namespace depsmvp.domain.Entities.Company;

public class Qsa
{
    [JsonPropertyName("identificador_de_socio")]
    public int? IdentificadorDeSocio { get; set; }

    [JsonPropertyName("nome_socio")]
    public string? NomeSocio { get; set; }

    [JsonPropertyName("cnpj_cpf_do_socio")]
    public string? CnpjCpfDoSocio { get; set; }

    [JsonPropertyName("codigo_qualificacao_socio")]
    public int? CodigoQualificacaoSocio { get; set; }

    [JsonPropertyName("percentual_capital_social")]
    public int? PercentualCapitalSocial { get; set; }

    [JsonPropertyName("data_entrada_sociedade")]
    public string? DataEntradaSociedade { get; set; }

    [JsonPropertyName("cpf_representante_legal")]
    public string? CpfRepresentanteLegal { get; set; }

    [JsonPropertyName("nome_representante_legal")]
    public string? NomeRepresentanteLegal { get; set; }

    [JsonPropertyName("codigo_qualificacao_representante_legal")]
    public int? CodigoQualificacaoRepresentanteLegal { get; set; }
}