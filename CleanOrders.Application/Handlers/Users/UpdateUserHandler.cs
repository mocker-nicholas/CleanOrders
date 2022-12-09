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
            User userToUpdate = await _userRepository.GetByIdAsync(request.Id);
            if (userToUpdate == null)
            {
                return new UpdateUserResponse("User not found");
            }

            bool emailIsUnique = await _userRepository.EmailIsUnique(request.Email);
            if (!emailIsUnique && request.Email != userToUpdate.Email)
            {
                return new UpdateUserResponse("Email for that account already exists");
            }

            userToUpdate.Email = request.Email;
            userToUpdate.RoleId = request.RoleId;

            User updatedUser = await _userRepository.UpdateAsync(userToUpdate);
            UserDto result = new(updatedUser);
            return new UpdateUserResponse(result);
        }
    }
}
