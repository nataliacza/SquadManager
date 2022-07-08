using SquadManager.Database.Enums;
using System.ComponentModel.DataAnnotations;


namespace SquadManager.Dto.MemberProperty;

public class UpdateMemberRoleDto
{
    [EnumDataType(typeof(RoleType))]
    [Range(0, 14)]
    public RoleType RoleType { get; set; }
}
