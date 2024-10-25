namespace depsmvp.domain.Entities;

public class CompanyConsult
{
    public int CompanyId { get; set; }
    public Company.Company Company { get; set; }
    
    public int ConsultationId { get; set; }
    public Consultation Consultation { get; set; }
    
    public DateTime AssociatedDate { get; set; } = DateTime.UtcNow;
}