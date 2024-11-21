using System.ComponentModel.DataAnnotations;

namespace depsmvp.application.Requests;

public class GetCompanyByCnpjRequest
{
    [Required] public string Cnpj { get; set; }

    [Required] public string ReferenceDate { get; set; }

    [Required] public int Interval { get; set; }
}