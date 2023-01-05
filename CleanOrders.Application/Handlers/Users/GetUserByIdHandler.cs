using CleanOrders.Application.Common.Dtos.Users;
using CleanOrders.Application.Interfaces.Repositories;
using CleanOrders.Application.Queries.Users;
using MediatR;

namespace CleanOrders.Application.Handlers.Users
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdResponse>
    {
        private readonly IUserRepositoryAsync _userRepositoryAsync;

        public GetUserByIdHandler(IUserRepositoryAsync userRepositoryAsync)
        {
            _userRepositoryAsync = userRepositoryAsync;
        }

        public async Task<GetUserByIdResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepositoryAsync.GetByIdAsync(request.id);
            if (result != null && result.AccountId == request.userId)
            {
                UserDto user = new(result);
                return new GetUserByIdResponse(user);
            }
            return new GetUserByIdResponse("No user was found");
        }
    }
}
