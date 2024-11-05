### Person Management

This project demonstrates my approach to organizing dependencies and structuring code for robust, scalable applications.

#### Key Design Focus

The primary focus of this implementation is to create a **Domain module** that holds responsibility for business logic and enforces **ACID requirements**. By providing clear abstractions, the Domain module enables dependent components to follow these requirements effectively.

The solution encapsulates **Data Access** and **Message Bus layers** into separate modules, making it easy to replace or switch out vendors if needed.

#### Core Components

1. **Data Access Layer**:
   - The Data Access layer implements the following key interfaces:
     - **`ITransactionRunner`**: Executes code within the scope of a transaction.
     - **`ITransaction`**: Provides control over transactions, supporting commit and rollback operations.
     - **Repository Interface**: Supplies CRUD operations for entity management.

   - The **`IPersonRepository`** interface accepts an `ITransaction` object for update operations. By attaching changes to the transaction, the repository ensures that updates can be rolled back if necessary.

   - The Data Access layer also uses an optimistic concurrency approach by incorporating a **LastUpdatedAt** field. This acts as a concurrency token to prevent multiple threads from making conflicting updates to a `Person` entity.

2. **Event Publisher with Idempotency**:
   - To ensure **idempotency** for event publishing, each event includes the timestamp of the initiating action. Combined with a unique user ID, this allows consumers to detect and ignore duplicate events. This is particularly useful in cases where the message queue cursor may be reset, such as with Kafka.

#### Idempotency in Consumer Implementations

Idempotency is a critical factor in designing consumer applications, as it ensures that repeated messages do not lead to inconsistent states. By providing unique identifiers and timestamps in the event payload, consumers can reliably discard duplicates without risk of processing the same event multiple times.
