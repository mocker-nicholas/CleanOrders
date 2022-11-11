using OrdersDomain.Core.Aggregates.Entities.Accounts;

namespace CleanOrders.Application.Interfaces.Repositories
{
    public interface IAccountRepositoryAsync : IGenericRepositoryAsync<Account>
    {
        Task<bool> EmailIsUnique(string email);
    }
}
