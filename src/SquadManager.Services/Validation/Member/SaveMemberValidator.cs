using FluentValidation;
using SquadManager.Dto.Members;

namespace SquadManager.Services.Validation.Member;

public class SaveMemberValidator : AbstractValidator<SaveMemberDto>
{
    public SaveMemberValidator()
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
