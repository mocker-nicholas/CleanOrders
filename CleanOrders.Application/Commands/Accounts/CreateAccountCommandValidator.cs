using FluentValidation;

namespace CleanOrders.Application.Commands.Accounts
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(CreateAccountCommand => CreateAccountCommand.Name)
                .NotEmpty()
                 .MinimumLength(4)
                .MaximumLength(100)
                .WithErrorCode("An account name is required");
            RuleFor(CreateAccountCommand => CreateAccountCommand.Password)
                .NotEmpty()
                .MinimumLength(8)
                .MaximumLength(16)
                .WithErrorCode("{PropertyName} must be between 8-16 characters")
                .Matches("[A-Z]").WithMessage("'{PropertyName}' must contain one or more capital letters.")
                .Matches("[a-z]").WithMessage("'{PropertyName}' must contain one or more lowercase letters.")
                .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("'{ PropertyName}' must contain one or more special characters.")
                .Matches("^[^£# “”]*$").WithMessage("'{PropertyName}' must not contain the following characters £ # “” or spaces.");
            RuleFor(CreateAccountCommand => CreateAccountCommand.Email)
                .EmailAddress()
                .WithErrorCode("Please enter a valid email address");
        }
    }
}
