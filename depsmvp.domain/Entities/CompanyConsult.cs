namespace depsmvp.domain.Entities;

public class CompanyConsult
{
    public int CompanyId { get; set; }
    public Company.Company Company { get; set; }
    
    public int ConsultId { get; set; }
    public Consult Consult { get; set; }
    
    public DateTime AssociatedDate { get; set; } = DateTime.UtcNow;
}