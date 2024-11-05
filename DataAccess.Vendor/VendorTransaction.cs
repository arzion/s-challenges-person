using PersonManagement.Domain;

namespace PersonManagement.DataAccess.Vendor
{
    public class VendorTransaction : ITransaction
    {
        public Task CommitAsync()
        {
            // TODO: implement transaction commit
            throw new NotImplementedException();
        }

        public Task RollbackAsync()
        {
            // TODO: implement the transaction rollback
            throw new NotImplementedException();
        }
    }
}
