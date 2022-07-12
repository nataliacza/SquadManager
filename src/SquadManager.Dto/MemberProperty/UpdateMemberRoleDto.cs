using SquadManager.Database.Enums;


namespace SquadManager.Dto.MemberProperty;

public class UpdateMemberRoleDto
{
    //[EnumDataType(typeof(RoleType))]
    //[Range(0, 14)]
    public RoleType RoleType { get; set; }
}
