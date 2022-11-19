using CleanOrders.Application.Commands.Users;
using CleanOrders.Application.Common.Dtos.Users;
using CleanOrders.Application.Interfaces.Repositories;
using FluentValidation.Results;
using MediatR;
using OrdersDomain.Core.Aggregates.Entities.Users;

namespace CleanOrders.Application.Handlers.Users
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUserRepositoryAsync _userRepositoryAsync;
        public CreateUserHandler(IUserRepositoryAsync userRepositoryAsync)
        {
            _userRepositoryAsync = userRepositoryAsync;
        }
        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            CreateUserCommandValidator Validator = new();
            ValidationResult result = Validator.Validate(request);
            if (!result.IsValid)
            {
                return new CreateUserResponse(result.ToString());
            }

            bool emailIsUnique = await _userRepositoryAsync.EmailIsUnique(request.Email);
            if (!emailIsUnique)
            {
                return new CreateUserResponse("A user with that email address already exists");
            }

            User user = new(
                request.AccountId,
                request.Email,
                request.Password,
                request.RoleId
            );
            await _userRepositoryAsync.AddAsync(user);
            UserDto newUser = new(user);
            return new CreateUserResponse(newUser);

        }
    }
}
