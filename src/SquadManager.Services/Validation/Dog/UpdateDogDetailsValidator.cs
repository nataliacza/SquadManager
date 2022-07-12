using FluentValidation;
using SquadManager.Database.Enums;
using SquadManager.Dto.Dogs;


namespace SquadManager.Services.Validation.Dog;

public class UpdateDogDetailsValidator : AbstractValidator<UpdateDogDetailsDto>
{
    public UpdateDogDetailsValidator()
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
