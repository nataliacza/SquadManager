using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SquadManager.Dtos.Dogs;
using SquadManager.Services.Interfaces.Dog;

namespace SquadManager.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DogsController : ControllerBase
{
    private readonly IDogCreator _dogCreator;
    private readonly IDogGetter _dogGetter;

    public DogsController(IDogCreator dogCreator, IDogGetter dogGetter)
    {
        _dogCreator = dogCreator;
        _dogGetter = dogGetter;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DogDto>> CreateDog([FromBody] CreateDogDto createDogDto)
    {
        var action = await _dogCreator.CreateDog(createDogDto);

        return Ok(action);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<DogDto>> GetDogId([FromRoute] Guid id)
    {
        var action = await _dogGetter.GetDog(id);

        return Ok(action);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DogDto>>> GetDogs()
    {
        var action = await _dogGetter.GetDogList();

        return Ok(action);
    }
}
