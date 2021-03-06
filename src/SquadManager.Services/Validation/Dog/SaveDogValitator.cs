using FluentValidation;
using SquadManager.Dto.Dogs;


namespace SquadManager.Services.Validation.Dog;

public class SaveDogValidator : AbstractValidator<SaveDogDto>
{
    public SaveDogValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(30)
            .NotEmpty();

        RuleFor(x => x.OwnerId)
            .NotEmpty();
    }
}
