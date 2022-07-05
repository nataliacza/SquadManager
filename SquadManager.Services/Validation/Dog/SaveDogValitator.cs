﻿using FluentValidation;
using SquadManager.Dtos.Dogs;

namespace SquadManager.Services.Validation.Member;

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