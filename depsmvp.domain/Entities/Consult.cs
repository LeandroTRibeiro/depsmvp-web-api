namespace depsmvp.domain.Entities;

public class Consult
{
    public int Id { get; set; }
    
    public string? Query { get; set; }
    
    public string? Document { get; set; }
    
    public DateTime SearchtDate { get; set; }
    
    
    public int UserId { get; set; }
    
    public User User { get; set; }
    
}