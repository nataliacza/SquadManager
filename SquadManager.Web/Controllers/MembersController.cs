using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SquadManager.Dtos.Members;
using SquadManager.Services.Interfaces.Member;

namespace SquadManager.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MembersController : ControllerBase
{
    private readonly IMemberCreator _memberCreator;

    public MembersController(IMemberCreator memberCreator)
    {
        _memberCreator = memberCreator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMember([FromBody] CreateMemberDto createMemberDto)
    {
        var action = await _memberCreator.CreateMember(createMemberDto);

        return Ok(action);
    }
}
