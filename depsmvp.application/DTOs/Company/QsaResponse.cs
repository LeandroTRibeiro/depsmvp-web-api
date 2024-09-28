namespace DepsMvp.Application.DTOs;

public class QsaResponse
{
    public int? IdentificadorDeSocio { get; set; }

    public string? NomeSocio { get; set; }

    public string? CnpjCpfDoSocio { get; set; }

    public int? CodigoQualificacaoSocio { get; set; }

    public int? PercentualCapitalSocial { get; set; }

    public string? DataEntradaSociedade { get; set; }

    public string? CpfRepresentanteLegal { get; set; }

    public string? NomeRepresentanteLegal { get; set; }

    public int? CodigoQualificacaoRepresentanteLegal { get; set; }
}