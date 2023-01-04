using FluentValidation;

namespace CleanOrders.Application.Commands.Accounts
{
    public class UpdateAccountCommandValidator : AbstractValidator<UpdateAccountCommand>
    {
        public UpdateAccountCommandValidator()
        {
            RuleFor(UpdateAccountCommand => UpdateAccountCommand.BusinessName)
                .NotEmpty()
                 .MinimumLength(4)
                .MaximumLength(100)
                .WithErrorCode("An account name is required");
            RuleFor(UpdateAccountCommand => UpdateAccountCommand.Email)
                .EmailAddress()
                .WithErrorCode("Please enter a valid email address");
            RuleFor(UpdateAccountCommand => UpdateAccountCommand.BusinessName)
                 .MinimumLength(1)
                 .MaximumLength(50)
                 .WithErrorCode("Business name must be between 1 and 50 chars");
            RuleFor(UpdateAccountCommand => UpdateAccountCommand.City)
                .MinimumLength(1)
                .MaximumLength(50)
                .Matches(@"^[0-9a-zA-Z ]+$")
                .WithErrorCode("City name must be between 1 and 50 alpha characters");
            RuleFor(UpdateAccountCommand => UpdateAccountCommand.PostalCode)
                .MinimumLength(5)
                .MaximumLength(5)
                .WithErrorCode("Please provide 5 digit zip code");
        }
    }
}
