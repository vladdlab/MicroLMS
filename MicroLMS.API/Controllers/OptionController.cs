using MicroLMS.Domain;
using MicroLMS.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroLMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OptionController : ControllerBase
{
    private readonly IOptionRepository _optionRepository;

    public OptionController(IOptionRepository optionRepository)
    {
        _optionRepository = optionRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IList<Option>>> IndexOption()
    {
        return Ok(await _optionRepository.GetOptionsAsync());
    }

    [HttpGet("{optionId:guid}")]
    public async Task<ActionResult<Option>> GetOption(Guid optionId)
    {
        var option = await _optionRepository.GetOptionAsync(optionId);
        if (option == null)
        {
            return NotFound();
        }

        return Ok(option);
    }

    [HttpPost]
    public async Task<ActionResult<Option>> CreateOption(Option option)
    {
        var createdOption = await _optionRepository.CreateOptionAsync(option);
        return Created(nameof(option), createdOption);
    }

    [HttpPut("{optionId:guid}")]
    public async Task<ActionResult<Option>> UpdateOption(Guid optionId, Option option)
    {
        if (optionId != option.Id)
        {
            return BadRequest();
        }

        if (!await _optionRepository.ExistsAsync(optionId))
        {
            return NotFound();
        }

        var updatedOption = await _optionRepository.UpdateOptionAsync(option);
        return Ok(updatedOption);
    }

    [HttpDelete("{optionId:guid}")]
    public async Task<IActionResult> DeleteOption(Guid optionId)
    {
        await _optionRepository.DeleteOptionAsync(optionId);
        return Ok();
    }
}