using CleanOrders.Application.Commands.Users;
using CleanOrders.Application.Common.Dtos.Users;
using CleanOrders.Application.Interfaces.Repositories;
using MediatR;
using OrdersDomain.Core.Aggregates.Entities.Users;

namespace CleanOrders.Application.Handlers.Users
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
    {
        private readonly IUserRepositoryAsync _userRepository;

        public UpdateUserHandler(IUserRepositoryAsync userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                return new UpdateUserResponse("User not found");
            }
            UserDto result = new(user);
            return new UpdateUserResponse(myuser);
        }
    }
}
