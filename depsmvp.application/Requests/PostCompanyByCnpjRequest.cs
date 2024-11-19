using System.ComponentModel.DataAnnotations;

namespace depsmvp.application.Requests;

public class PostCompanyByCnpjRequest
{
    [Required]
    public string Cnpj { get; set; }
    
    [Required]
    public string referenceDate { get; set; }
    
    [Required]
    public int interval { get; set; }
}