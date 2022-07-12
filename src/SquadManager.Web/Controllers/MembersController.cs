using Microsoft.AspNetCore.Mvc;
using SquadManager.Dto.MemberProperty;
using SquadManager.Dto.Members;
using SquadManager.Services.Interfaces.Member;


namespace SquadManager.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MembersController : ControllerBase
{
    private readonly IMemberCreator _memberCreator;
    private readonly IMemberGetter _memberGetter;
    private readonly IMemberUpdater _memberUpdater;
    private readonly IMemberDeleter _memberDeleter;

    public MembersController(
        IMemberCreator memberCreator,
        IMemberGetter memberGetter,
        IMemberUpdater memberUpdater,
        IMemberDeleter memberDeleter)
    {
        _memberCreator = memberCreator;
        _memberGetter = memberGetter;
        _memberUpdater = memberUpdater;
        _memberDeleter = memberDeleter;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MemberDto>> CreateMember([FromBody] SaveMemberDto createMemberDto)
    {
        var action = await _memberCreator.CreateMember(createMemberDto);

        return CreatedAtAction(
            nameof(GetMemberById),
            new { id = action.Id },
            action);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MemberDetailsDto>> GetMemberById([FromRoute] Guid id)
    {
        var action = await _memberGetter.GetMemberDetails(id);

        if (action == null)
        {
            return NotFound();
        }

        return Ok(action);
    }

    [HttpGet("{id:guid}/MemberProperties")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MemberDetailsDto>>> GetMembers()
    {
        var action = await _memberGetter.GetMemberList();

        return Ok(action);
    }

    [HttpGet("MembersWithProperties")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MemberWithPropertiesDto>>> GetMembersWithProperties()
    {
        var action = await _memberGetter.GetMembersWithProperties();

        return Ok(action);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MemberDetailsDto>> UpdateMemberDetails(
        [FromRoute] Guid id, [FromBody] SaveMemberDto memberDto)
    {
        var action = await _memberUpdater.UpdateDetails(id, memberDto);

        if (action == null)
        {
            return NotFound();
        }

        return Ok(action);
    }

    [HttpPut("{id:guid}/MemberProperties")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MemberPropertyDto>> UpdateMemberProperties(
        [FromRoute] Guid id, [FromBody] UpdateMemberPropertyDto propertyDto)
    {
        var action = await _memberUpdater.UpdateProperty(id, propertyDto);

        if (action == null)
        {
            return NotFound();
        }

        return Ok(action);
    }

    [HttpPatch("{id:guid}/MemberRole")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MemberPropertyDto>> UpdateMemberRole(
        [FromRoute] Guid id, [FromBody] UpdateMemberRoleDto roleDto)
    {
        var action = await _memberUpdater.UpdateRole(id, roleDto);

        if (action == null)
        {
            return NotFound();
        }

        return Ok(action);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
    public async Task<ActionResult<MemberDto>> DeleteMember([FromRoute] Guid id)
    {
        var action = await _memberDeleter.DeleteMember(id);

        if (action == null)
        {
            return NotFound();
        }

        return Ok(action);
    }
}
