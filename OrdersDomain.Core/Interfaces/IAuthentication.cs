using OrdersDomain.Core.Aggregates.Entities.Users;

namespace OrdersDomain.Core.Interfaces
{
    public interface IAuthentication
    {
        string Generate(User user);
        User Authenticate(UserLogin userLogin);
        LoggedInUser GetCurrentUser();
    }
}
