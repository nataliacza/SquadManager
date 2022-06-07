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

        return CreatedAtAction(
            nameof(GetMemberId),
            new { id = action.Id },
            action);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<MemberBasicsDto>> GetMemberId([FromRoute] Guid id)
    {
        var action = await _memberGetter.GetMember(id);

        if (action == null)
        {
            return NotFound();
        }

        return Ok(action);
    }

    [HttpGet("{id:guid}/MemberProperties")]
    public async Task<ActionResult<MemberPropertyDto>> GetMemberPropertyId([FromRoute] Guid id)
    {
        var action = await _memberGetter.GetMemberProperty(id);

        if (action == null)
        {
            return NotFound();
        }

        return Ok(action);
    }

    [HttpGet("{id:guid}/Dogs")]
    public async Task<ActionResult<IEnumerable<MemberDogDto>>> GetMemberDogs([FromRoute] Guid id)
    {
        var action = await _memberGetter.GetMemberDogList(id);

        if (action == null)
        {
            return NotFound();
        }

        return Ok(action);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetMembers()
    {
        var action = await _memberGetter.GetMemberList();

        return Ok(action);
    }
}
