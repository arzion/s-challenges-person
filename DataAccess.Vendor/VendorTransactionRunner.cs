using PersonManagement.Domain;

namespace PersonManagement.DataAccess.Vendor
{
    public class VendorTransactionRunner : ITransactionRunner
    {
        public Task RunAsync(Func<ITransaction, Task> action)
        {
            // TODO: instantiate a transaction and run the action providing the transaction
            throw new NotImplementedException();
        }

        public Task<TResult> RunAsync<TResult>(Func<ITransaction, Task<TResult>> action)
        {
            // TODO: instantiate a transaction and run the action providing the transaction, this overload is used if the action returns a result
            throw new NotImplementedException();
        }
    }
}
