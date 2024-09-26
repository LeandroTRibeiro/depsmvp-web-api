namespace DepsMvp.Application.DTOs;

public class CompanyResponse
{
    public string? Cnpj { get; set; }

    public int? IdentificadorMatrizFilial { get; set; }

    public string? DescricaoMatrizFilial { get; set; }

    public string? RazaoSocial { get; set; }

    public string? NomeFantasia { get; set; }

    public int? SituacaoCadastral { get; set; }

    public string? DescricaoSituacaoCadastral { get; set; }

    public string? DataSituacaoCadastral { get; set; }

    public int? MotivoSituacaoCadastral { get; set; }

    public string? NomeCidadeExterior { get; set; }

    public int? CodigoNaturezaJuridica { get; set; }

    public string? DataInicioAtividade { get; set; }

    public int? CnaeFiscal { get; set; }

    public string? CnaeFiscalDescricao { get; set; }

    public string? DescricaoTipoDeLogradouro { get; set; }

    public string? Logradouro { get; set; }

    public string? Numero { get; set; }

    public string? Complemento { get; set; }

    public string? Bairro { get; set; }

    public string? Cep { get; set; }

    public string? Uf { get; set; }

    public int? CodigoMunicipio { get; set; }

    public string? Municipio { get; set; }

    public string? DddTelefone1 { get; set; }

    public string? DddTelefone2 { get; set; }

    public string? DddFax { get; set; }

    public int? QualificacaoDoResponsavel { get; set; }

    public int? CapitalSocial { get; set; }

    public string? Porte { get; set; }

    public string? DescricaoPorte { get; set; }

    public bool OpcaoPeloSimples { get; set; }

    public string? DataOpcaoPeloSimples { get; set; }

    public string? DataExclusaoDoSimples { get; set; }

    public bool OpcaoPeloMei { get; set; }

    public string? SituacaoEspecial { get; set; }

    public string? DataSituacaoEspecial { get; set; }

    public List<CnaesSecundarioResponse>? CnaesSecundarios { get; set; }

    public List<QsaResponse>? Qsa { get; set; } 
}