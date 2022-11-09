using FluentValidation;

namespace CleanOrders.Application.Commands.Accounts
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(CreateAccountCommand => CreateAccountCommand.Name)
                .NotEmpty()
                .WithErrorCode("An account name is required");
            RuleFor(CreateAccountCommand => CreateAccountCommand.Password)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(16)
                .WithErrorCode("{PropertyName} must be between 8-16 characters and include special character");
            RuleFor(CreateAccountCommand => CreateAccountCommand.Email)
                .EmailAddress()
                .WithErrorCode("Please enter a valid email address");
        }
    }
}
