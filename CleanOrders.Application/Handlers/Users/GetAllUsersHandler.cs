using CleanOrders.Application.Common.Dtos.Users;
using CleanOrders.Application.Interfaces.Repositories;
using CleanOrders.Application.Queries.Accounts;
using MediatR;

namespace CleanOrders.Application.Handlers.Users
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, GetAllUsersResponse>
    {
        private readonly IUserRepositoryAsync _userRepositoryAsync;

        public GetAllUsersHandler(IUserRepositoryAsync userRepositoryAsync)
        {
            _userRepositoryAsync = userRepositoryAsync;
        }

        public async Task<GetAllUsersResponse> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            List<UserDto> users = await _userRepositoryAsync.GetAllAsync(request.AccountId);
            GetAllUsersResponse result = new(users);
            return result;
        }
    }
}
