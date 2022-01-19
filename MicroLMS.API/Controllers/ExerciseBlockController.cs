using MicroLMS.Domain;
using MicroLMS.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroLMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExerciseBlockController : ControllerBase
{
    private readonly IExerciseBlockRepository _exerciseBlockRepository;

    public ExerciseBlockController(IExerciseBlockRepository exerciseBlockRepository)
    {
        _exerciseBlockRepository = exerciseBlockRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IList<ExerciseBlock>>> IndexExerciseBlock()
    {
        return Ok(await _exerciseBlockRepository.GetExerciseBlocksAsync());
    }

    [HttpGet("{exerciseBlockId:guid}")]
    public async Task<ActionResult<ExerciseBlock>> GetExerciseBlock(Guid exerciseBlockId)
    {
        var exerciseBlock = await _exerciseBlockRepository.GetExerciseBlockAsync(exerciseBlockId);
        if (exerciseBlock == null)
        {
            return NotFound();
        }

        return Ok(exerciseBlock);
    }

    [HttpPost]
    public async Task<ActionResult<ExerciseBlock>> CreateExerciseBlock(ExerciseBlock exerciseBlock)
    {
        var createdExerciseBlock = await _exerciseBlockRepository.CreateExerciseBlockAsync(exerciseBlock);
        return Created(nameof(exerciseBlock), createdExerciseBlock);
    }

    [HttpPut("{exerciseBlockId:guid}")]
    public async Task<ActionResult<ExerciseBlock>> UpdateExerciseBlock(Guid exerciseBlockId, ExerciseBlock exerciseBlock)
    {
        if (exerciseBlockId != exerciseBlock.Id)
        {
            return BadRequest();
        }

        if (!await _exerciseBlockRepository.ExistsAsync(exerciseBlockId))
        {
            return NotFound();
        }

        var updatedExerciseBlock = await _exerciseBlockRepository.UpdateExerciseBlockAsync(exerciseBlock);
        return Ok(updatedExerciseBlock);
    }

    [HttpDelete("{exerciseBlockId:guid}")]
    public async Task<IActionResult> DeleteExerciseBlock(Guid exerciseBlockId)
    {
        await _exerciseBlockRepository.DeleteExerciseBlockAsync(exerciseBlockId);
        return Ok();
    }
}