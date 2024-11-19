using System.ComponentModel.DataAnnotations;

namespace depsmvp.application.Requests;

public class PostPepsByCpfRequest
{
    [Required]
    public string Cpf { get; set; }
    
    [Required]
    public string ReferenceDate { get; set; }
    
    [Required]
    public int Interval { get; set; }
}