namespace PersonManagement.Domain;

public interface ITransaction
{
    Task CommitAsync();
    Task RollbackAsync();
}