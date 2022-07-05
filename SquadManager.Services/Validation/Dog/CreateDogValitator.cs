using FluentValidation;
using SquadManager.Dtos.Dogs;

namespace SquadManager.Services.Validation.Member;

public class CreateDogValidator : AbstractValidator<SaveDogDto>
{
    public CreateDogValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(30)
            .NotEmpty();

        RuleFor(x => x.OwnerId)
            .NotEmpty();
    }
}
