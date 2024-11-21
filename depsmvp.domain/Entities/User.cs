using System.Text.Json.Serialization;

namespace depsmvp.domain.Entities;

public class User
{
    public int? Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    [JsonIgnore] public string? Password { get; set; }

    public string? CreatedBy { get; set; }

    public string? CreatedAt { get; set; }

    [JsonIgnore] public ICollection<Consultation>? Consultations { get; set; }
}