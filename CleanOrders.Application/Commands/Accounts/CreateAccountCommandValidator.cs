using FluentValidation;

namespace CleanOrders.Application.Commands.Accounts
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(CreateAccountCommand => CreateAccountCommand.BusinessName)
                .NotEmpty()
                 .MinimumLength(4)
                .MaximumLength(100)
                .WithErrorCode("An account name is required");
            RuleFor(CreateAccountCommand => CreateAccountCommand.Email)
                .EmailAddress()
                .WithErrorCode("Please enter a valid email address");
        }
    }
}
