using PersonManagement.Domain.Data;
using PersonManagement.Domain.Model;

namespace PersonManagement.Domain;

public interface IPersonRepository
{
    Task<Person?> GetPersonAsync(string personId);
    Task UpdatePersonAsync(string personId, UpdatePersonData data, DateTime lastUpdated, ITransaction? transaction = null);
}