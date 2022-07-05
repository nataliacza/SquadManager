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
    private readonly IDogUpdater _dogUpdater;
    private readonly IDogDeleter _dogDeleter;


    public DogsController(
        IDogCreator dogCreator, 
        IDogGetter dogGetter,
        IDogUpdater dogUpdater,
        IDogDeleter dogDeleter)
    {
        _dogCreator = dogCreator;
        _dogGetter = dogGetter;
        _dogUpdater = dogUpdater;
        _dogDeleter = dogDeleter;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DogDto>> CreateDog([FromBody] SaveDogDto createDogDto)
    {
        var action = await _dogCreator.CreateDog(createDogDto);

        if (action == null)
        {
            return NotFound();
        }

        return CreatedAtAction(
            nameof(GetDogById),
            new { id = action.Id },
            action);
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

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DogDto>> UpdateDogById(
        [FromRoute] Guid id, [FromBody] SaveDogDto updateDto)
    {
        var action = await _dogUpdater.UpdateDog(id, updateDto);

        if (action == null)
        {
            return NotFound();
        }

        return Ok(action);
    }

    [HttpPut("{id:guid}/Details")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DogDto>> UpdateDetails(
        [FromRoute] Guid id, [FromBody] UpdateDogDetailsDto updateDetailsDto)
    {
        var action = await _dogUpdater.UpdateDogDetails(id, updateDetailsDto);

        if (action == null)
        {
            return NotFound();
        }

        return Ok(action);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DogDto>> DeleteDog([FromRoute] Guid id)
    {
        var action = await _dogDeleter.DeleteDog(id);

        if (action == null)
        {
            return NotFound();
        }

        return Ok(action);
    }
}
