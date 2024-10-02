namespace depsmvp.domain.Entities;

public class PepsConsult
{
    public int PepId { get; set; }
    public Pep Pep { get; set; }
    
    public int ConsultId { get; set; }
    public Consult Consult { get; set; }
    
    public DateTime AssociatedDate { get; set; } = DateTime.UtcNow;

}