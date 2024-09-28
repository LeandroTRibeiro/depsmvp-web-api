namespace depsmvp.domain.Entities;

public class User
{
    public int? Id { get; set; }
    
    public string? Name { get; set; }
    
    public string? Email { get; set; }
    
    public string? Password { get; set; }
    
    public string? CreatedBy { get; set; }
    
    public string? CreatedAt { get; set; }
    
    public ICollection<Consult>? Consults { get; set; }
}