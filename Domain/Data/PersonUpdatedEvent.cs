namespace PersonManagement.Domain.Data;

public class PersonUpdatedEvent
{
    public required string Id { get; set; }
    public string? NewFirstName { get; set; }
    public string? NewLastName { get; set; }
    public DateTime? NewBirthDate { get; set; }
}