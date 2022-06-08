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
    private readonly IMemberUpdater _memberUpdater;

    public MembersController(
        IMemberCreator memberCreator,
        IMemberGetter memberGetter,
        IMemberUpdater memberUpdater)
    {
        _memberCreator = memberCreator;
        _memberGetter = memberGetter;
        _memberUpdater = memberUpdater;
    }

    [HttpPost]
    public async Task<ActionResult<MemberDto>> CreateMember([FromBody] SaveMemberDto createMemberDto)
    {
        var action = await _memberCreator.CreateMember(createMemberDto);

        return CreatedAtAction(
            nameof(GetMemberDetailsById),
            new { id = action.Id },
            action);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<MemberDetailsDto>> GetMemberDetailsById([FromRoute] Guid id)
    {
        var action = await _memberGetter.GetMemberDetails(id);

        if (action == null)
        {
            return NotFound();
        }

        return Ok(action);
    }

    [HttpGet("{id:guid}/MemberProperties")]
    public async Task<ActionResult<MemberPropertyDto>> GetMemberPropertyById([FromRoute] Guid id)
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

    [HttpPatch("{id:guid}")]
    public async Task<ActionResult<MemberDto>> UpdateMemberDetails(
        [FromRoute] Guid id, [FromBody] SaveMemberDto memberDto)
    {
        var action = await _memberUpdater.UpdateMemberBasicDetails(id, memberDto);

        if (action == null)
        {
            return NotFound();
        }

        return Ok(action);
    }
}
