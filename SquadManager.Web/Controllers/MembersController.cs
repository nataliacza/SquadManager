using Microsoft.AspNetCore.Mvc;
using SquadManager.Dtos.Members;
using SquadManager.Services.Interfaces.Member;

namespace SquadManager.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MembersController : ControllerBase
{
    private readonly IMemberCreator _memberCreator;
    private readonly IMemberGetter _memberGetter;

    public MembersController(IMemberCreator memberCreator, IMemberGetter memberGetter)
    {
        _memberCreator = memberCreator;
        _memberGetter = memberGetter;
    }

    [HttpPost]
    public async Task<ActionResult<MemberDto>> CreateMember([FromBody] CreateMemberDto createMemberDto)
    {
        var action = await _memberCreator.CreateMember(createMemberDto);

        return Ok(action);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<MemberDto>> GetMemberId([FromRoute] Guid id)
    {
        var action = await _memberGetter.GetMember(id);

        return Ok(action);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetMembers()
    {
        var action = await _memberGetter.GetMemberList();

        return Ok(action);
    }
}
