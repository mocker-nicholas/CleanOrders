using FluentValidation;

namespace CleanOrders.Application.Commands.Accounts
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(CreateAccountCommand => CreateAccountCommand.BusinessName)
                .NotEmpty()
                 .MinimumLength(1)
                .WithErrorCode("An account name is required");
            RuleFor(CreateAccountCommand => CreateAccountCommand.BusinessName)
                .MaximumLength(100)
                .WithErrorCode("Account name max length 100 characters");
            RuleFor(CreateAccountCommand => CreateAccountCommand.Email)
                .EmailAddress()
                .WithErrorCode("Please enter a valid email address");
            RuleFor(CreateAccountCommand => CreateAccountCommand.City)
                .MinimumLength(1)
                .WithErrorCode("A city is required");
            RuleFor(CreateAccountCommand => CreateAccountCommand.City)
                .MaximumLength(50)
                .Matches(@"^[0-9a-zA-Z ]+$")
                .WithErrorCode("A city can only be 50 alpha characters");
        }
    }
}
