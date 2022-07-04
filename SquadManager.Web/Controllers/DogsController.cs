using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SquadManager.Database.Models;
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
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DogDto>> CreateDog([FromBody] CreateDogDto createDogDto)
    {
        var action = await _dogCreator.CreateDog(createDogDto);

        if (action == null)
        {
            return NotFound();
        }

        return Ok(action);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DogDto>> GetDogById([FromRoute] Guid id)
    {
        var action = await _dogGetter.GetDog(id);

        if (action == null)
        {
            return NotFound();
        }

        return Ok(action);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DogListDto>>> GetDogs()
    {
        var action = await _dogGetter.GetDogList();

        return Ok(action);
    }
}
