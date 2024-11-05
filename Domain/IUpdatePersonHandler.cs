using PersonManagement.Domain.Data;

namespace PersonManagement.Domain;

public interface IUpdatePersonHandler
{
    Task UpdatePersonAsync(string personId, UpdatePersonData data);
}