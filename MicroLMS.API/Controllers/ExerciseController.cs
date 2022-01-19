using MicroLMS.Domain;
using MicroLMS.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroLMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExerciseController : ControllerBase
{
    private readonly IExerciseRepository _exerciseRepository;

    public ExerciseController(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IList<Exercise>>> IndexExercise()
    {
        return Ok(await _exerciseRepository.GetExercisesAsync());
    }

    [HttpGet("{exerciseId:guid}")]
    public async Task<ActionResult<Exercise>> GetExercise(Guid exerciseId)
    {
        var exercise = await _exerciseRepository.GetExerciseAsync(exerciseId);
        if (exercise == null)
        {
            return NotFound();
        }

        return Ok(exercise);
    }

    [HttpPost]
    public async Task<ActionResult<Exercise>> CreateExercise(Exercise exercise)
    {
        var createdExercise = await _exerciseRepository.CreateExerciseAsync(exercise);
        return Created(nameof(exercise), createdExercise);
    }

    [HttpPut("{exerciseId:guid}")]
    public async Task<ActionResult<Exercise>> UpdateExercise(Guid exerciseId, Exercise exercise)
    {
        if (exerciseId != exercise.Id)
        {
            return BadRequest();
        }

        if (!await _exerciseRepository.ExistsAsync(exerciseId))
        {
            return NotFound();
        }

        var updatedExercise = await _exerciseRepository.UpdateExerciseAsync(exercise);
        return Ok(updatedExercise);
    }

    [HttpDelete("{exerciseId:guid}")]
    public async Task<IActionResult> DeleteExercise(Guid exerciseId)
    {
        await _exerciseRepository.DeleteExerciseAsync(exerciseId);
        return Ok();
    }
}