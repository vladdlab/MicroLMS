using MicroLMS.Domain;
using MicroLMS.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroLMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExerciseVariantController : ControllerBase
{
    private readonly IExerciseVariantRepository _exerciseVariantRepository;

    public ExerciseVariantController(IExerciseVariantRepository exerciseVariantRepository)
    {
        _exerciseVariantRepository = exerciseVariantRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IList<ExerciseVariant>>> IndexExerciseVariant()
    {
        return Ok(await _exerciseVariantRepository.GetExerciseVariantsAsync());
    }

    [HttpGet("{exerciseVariantId:guid}")]
    public async Task<ActionResult<ExerciseVariant>> GetExerciseVariant(Guid exerciseVariantId)
    {
        var exerciseVariant = await _exerciseVariantRepository.GetExerciseVariantAsync(exerciseVariantId);
        if (exerciseVariant == null)
        {
            return NotFound();
        }

        return Ok(exerciseVariant);
    }

    [HttpPost]
    public async Task<ActionResult<ExerciseVariant>> CreateExerciseVariant(ExerciseVariant exerciseVariant)
    {
        var createdExerciseVariant = await _exerciseVariantRepository.CreateExerciseVariantAsync(exerciseVariant);
        return Created(nameof(exerciseVariant), createdExerciseVariant);
    }

    [HttpPut("{exerciseVariantId:guid}")]
    public async Task<ActionResult<ExerciseVariant>> UpdateExerciseVariant(Guid exerciseVariantId,
        ExerciseVariant exerciseVariant)
    {
        if (exerciseVariantId != exerciseVariant.Id)
        {
            return BadRequest();
        }

        if (!await _exerciseVariantRepository.ExistsAsync(exerciseVariantId))
        {
            return NotFound();
        }

        var updatedExerciseVariant = await _exerciseVariantRepository.UpdateExerciseVariantAsync(exerciseVariant);
        return Ok(updatedExerciseVariant);
    }

    [HttpDelete("{exerciseVariantId:guid}")]
    public async Task<IActionResult> DeleteExerciseVariant(Guid exerciseVariantId)
    {
        await _exerciseVariantRepository.DeleteExerciseVariantAsync(exerciseVariantId);
        return Ok();
    }
}