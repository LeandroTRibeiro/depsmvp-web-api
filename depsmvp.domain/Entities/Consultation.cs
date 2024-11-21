namespace depsmvp.domain.Entities;

public class Consultation
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public DateTime ConsultationDate { get; set; }

    public string? ConsultationType { get; set; }

    public string? ConsultationCode { get; set; }

    public DateTime? ConsultationDateReference { get; set; }

    public int? ConsultationInterval { get; set; }
}