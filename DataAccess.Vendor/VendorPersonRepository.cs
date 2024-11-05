using PersonManagement.Domain;
using PersonManagement.Domain.Data;
using PersonManagement.Domain.Model;

namespace PersonManagement.DataAccess.Vendor;

public class VendorPersonRepository : IPersonRepository
{
    public Task<Person?> GetPersonAsync(string personId)
    {
        // TODO: implement reading the person by its Identifier according to the Vendor DB
        throw new NotImplementedException();
    }

    public Task UpdatePersonAsync(string personId, UpdatePersonData data, DateTime lastUpdated, ITransaction? transaction = null)
    {
        // TODO: implement updating the person according to the Vendor DB
        // if transaction is provided, the update operation should be registered in the transaction so it can be committed or rolled back
        // last updated should be checked to ensure that the data has not been updated since it was read, otherwise, the operation should be aborted (optimistic concurrency)
        throw new NotImplementedException();
    }
}