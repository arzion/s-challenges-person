namespace PersonManagement.Domain.Model;

public class Person
{
    public required string Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime? BirthDate { get; set; }
    public DateTime LastUpdated { get; set; }
    public int? Age
    {
        get
        {
            if(!BirthDate.HasValue)
            {
                return null;
            }

            var today = DateTime.Today;
            var age = today.Year - BirthDate.Value.Year;

            // Adjust if the birthday hasn't occurred this year
            if (BirthDate.Value.Date > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }
}