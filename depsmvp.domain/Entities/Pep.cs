using System.Text.Json.Serialization;

namespace depsmvp.domain.Entities;

public class Pep
{
    public int Id { get; set; }
    
    public DateTime SearchDate { get; set; }
    
    [JsonPropertyName("cpf")]
    public string? Cpf { get; set; }

    [JsonPropertyName("nome")]
    public string? Nome { get; set; }

    [JsonPropertyName("sigla_funcao")]
    public string? SiglaFuncao { get; set; }

    [JsonPropertyName("descricao_funcao")]
    public string? DescricaoFuncao { get; set; }

    [JsonPropertyName("nivel_funcao")]
    public string? NivelFuncao { get; set; }

    [JsonPropertyName("cod_orgao")]
    public string? CodOrgao { get; set; }

    [JsonPropertyName("nome_orgao")]
    public string? NomeOrgao { get; set; }

    [JsonPropertyName("dt_inicio_exercicio")]
    public string? DtInicioExercicio { get; set; }

    [JsonPropertyName("dt_fim_exercicio")]
    public string? DtFimExercicio { get; set; }

    [JsonPropertyName("dt_fim_carencia")]
    public string? DtFimCarencia { get; set; }
}