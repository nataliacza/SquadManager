using FluentValidation;
using SquadManager.Dtos.MemberProperty;

namespace SquadManager.Services.Validation.MemberProperties;

public class UpdateMemberRoleValidator : AbstractValidator<UpdateMemberRoleDto>
{
    public UpdateMemberRoleValidator()
    {
        RuleFor(x => x.RoleType)
            .NotEmpty()
            .IsInEnum();
    }
}
