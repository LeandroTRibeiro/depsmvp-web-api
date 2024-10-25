namespace depsmvp.domain.Entities;

public class PepsConsult
{
    public int PepId { get; set; }
    public Pep Pep { get; set; }
    
    public int ConsultationId { get; set; }
    public Consultation Consultation { get; set; }
    
    public DateTime AssociatedDate { get; set; } = DateTime.UtcNow;

}