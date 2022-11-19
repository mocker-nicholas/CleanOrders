using OrdersDomain.Core.Aggregates.Entities.Users;

namespace CleanOrders.Application.Interfaces.Repositories
{
    public interface IUserRepositoryAsync : IGenericRepositoryAsync<User>
    {
        Task<bool> EmailIsUnique(string email);
    }
}
