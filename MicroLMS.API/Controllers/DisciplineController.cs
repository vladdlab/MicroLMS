using MicroLMS.Domain;
using MicroLMS.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroLMS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DisciplineController : ControllerBase
{
    private readonly IDisciplineRepository _disciplineRepository;

    public DisciplineController(IDisciplineRepository disciplineRepository)
    {
        _disciplineRepository = disciplineRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IList<Discipline>>> IndexDiscipline()
    {
        return Ok(await _disciplineRepository.GetDisciplinesAsync());
    }

    [HttpGet("{disciplineId:guid}")]
    public async Task<ActionResult<Discipline>> GetDiscipline(Guid disciplineId)
    {
        var discipline = await _disciplineRepository.GetDisciplineAsync(disciplineId);
        if (discipline == null)
        {
            return NotFound();
        }

        return Ok(discipline);
    }

    [HttpPost]
    public async Task<ActionResult<Discipline>> CreateDiscipline(Discipline discipline)
    {
        var createdDiscipline = await _disciplineRepository.CreateDisciplineAsync(discipline);
        return Created(nameof(discipline), createdDiscipline);
    }

    [HttpPut("{disciplineId:guid}")]
    public async Task<ActionResult<Discipline>> UpdateDiscipline(Guid disciplineId, Discipline discipline)
    {
        if (disciplineId != discipline.Id)
        {
            return BadRequest();
        }

        if (!await _disciplineRepository.ExistsAsync(disciplineId))
        {
            return NotFound();
        }

        var updatedDiscipline = await _disciplineRepository.UpdateDisciplineAsync(discipline);
        return Ok(updatedDiscipline);
    }

    [HttpDelete("{disciplineId:guid}")]
    public async Task<IActionResult> DeleteDiscipline(Guid disciplineId)
    {
        await _disciplineRepository.DeleteDisciplineAsync(disciplineId);
        return Ok();
    }
}