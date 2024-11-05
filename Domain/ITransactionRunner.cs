namespace PersonManagement.Domain;

public interface ITransactionRunner
{
    Task<TResult> RunAsync<TResult>(Func<ITransaction, Task<TResult>> action);
    Task RunAsync(Func<ITransaction, Task> action);
}