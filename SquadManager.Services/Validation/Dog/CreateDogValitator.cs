using FluentValidation;
using SquadManager.Dtos.Dogs;

namespace SquadManager.Services.Validation.Member;

public class CreateDogValidator : AbstractValidator<CreateDogDto>
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
