using FluentValidation;
using SquadManager.Dtos.Members;

namespace SquadManager.Services.Validation;

public class EfMemberCreatorValidator : AbstractValidator<SaveMemberDto>
{
    public EfMemberCreatorValidator()
    {
        RuleFor(x => x.FirstName)
            .MaximumLength(30)
            .NotEmpty();

        RuleFor(x => x.LastName)
            .MaximumLength(30)
            .NotEmpty();

        RuleFor(x => x.Email)
            .EmailAddress()
            .MaximumLength(50)
            .NotEmpty();

        RuleFor(x => x.Mobile)
            .MinimumLength(9)
            .MaximumLength(10)
            .Matches(@"\d")
            .NotEmpty();
    }
}
