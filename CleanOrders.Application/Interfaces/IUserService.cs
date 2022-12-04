using OrdersDomain.Core.Aggregates.Entities.Users;

namespace CleanOrders.Application.Interfaces
{
    public interface IUserService
    {
        LoggedInUser GetCurrentUser();
        User Authenticate(UserLogin userLogin);
        string Generate(User user);
    }
}
