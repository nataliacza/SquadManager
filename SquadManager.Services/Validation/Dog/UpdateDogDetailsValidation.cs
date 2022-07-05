using FluentValidation;
using SquadManager.Dtos.Dogs;

namespace SquadManager.Services.Validation.Dog;

public class UpdateDogDetailsValidation : AbstractValidator<UpdateDogDetailsDto>
{
    public UpdateDogDetailsValidation()
    {
        RuleFor(x => x.Breeder)
            .MaximumLength(50);

        RuleFor(x => x.Gender)
            .IsInEnum();

        RuleFor(x => x.DateOfBirth)
            .LessThanOrEqualTo(DateTime.UtcNow);

        RuleFor(x => x.ChipNumber)
            .MaximumLength(50);
    }
}
