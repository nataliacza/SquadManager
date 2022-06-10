using SquadManager.Database.Enums;
using System.ComponentModel.DataAnnotations;

namespace SquadManager.Dtos.MemberProperty;

public class UpdateMemberRoleDto
{
    [EnumDataType(typeof(RoleType))]
    public RoleType RoleType { get; set; }
}
