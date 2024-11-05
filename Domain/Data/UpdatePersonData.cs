namespace PersonManagement.Domain.Data;

/// <summary>
/// The DTO that represents the data that can be updated on a person.
/// If null is set to the field, it is expected that the field will be ignored during the update.
/// If the field is set to a value, it is expected that the field will be updated to the new value.
/// If the field is set to an empty string, it is expected that the field will be updated to the default value.
/// </summary>
public class UpdatePersonData
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? BirthDate { get; set; }
}