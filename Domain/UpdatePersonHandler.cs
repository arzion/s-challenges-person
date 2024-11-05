using PersonManagement.Domain.Data;
using PersonManagement.Domain.Model;

namespace PersonManagement.Domain;

public class UpdatePersonHandler(ITransactionRunner transactionRunner, IPersonRepository personRepository, IEventPublisher eventPublisher)
{
    public async Task UpdatePersonAsync(string personId, UpdatePersonData data)
    {
        // TODO: implement the data validation: length of the name, and range of the birthdate
        await transactionRunner.RunAsync(async transaction =>
        {
            try
            {
                // Retrieve existing person data, we will rely on it to check if the data has been modified, and then to send only modified fields to the event bus,
                // so we will use optimistic concurrency control to ensure that 2 threads won't update the same person at the same time
                var existingPerson = await personRepository.GetPersonAsync(personId);

                if (existingPerson == null)
                {
                    // TODO: consider throwing specific exception type
                    throw new InvalidOperationException("Cannot update person that does not exist");
                }

                if(!IsModified(existingPerson, data))
                {
                    // No changes, nothing to do
                    return;
                }

                await personRepository.UpdatePersonAsync(personId, data, existingPerson.LastUpdated, transaction);
                await transaction.CommitAsync();
                await eventPublisher.PublishPersonStateChangedEvent(new PersonUpdatedEvent
                {
                    Id = existingPerson.Id,
                    NewFirstName = existingPerson.FirstName != data.FirstName ? data.FirstName : null,
                    NewLastName = existingPerson.LastName != data.LastName ? data.LastName : null,
                    NewBirthDate = existingPerson.BirthDate != data.BirthDate ? data.BirthDate : null
                });
            }
            // if anything goes wrong, either on data-access layer, or we couldn't publish the event
            // we will roll back the transaction on the data-access level
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        });
    }

    private static bool IsModified(Person person, UpdatePersonData data)
    {
        return person.FirstName != data.FirstName || person.LastName != data.LastName || person.BirthDate != data.BirthDate;
    }
}