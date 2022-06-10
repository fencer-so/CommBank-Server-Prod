using Microsoft.AspNetCore.Mvc;
using CommBank.Services;
using CommBank.Models;

namespace CommBank.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicationController : ControllerBase
{
    private readonly ApplicationsService _applicationsService;

    public ApplicationController(ApplicationsService applicationsService) =>
        _applicationsService = applicationsService;

    [HttpGet]
    public async Task<List<Application>> Get() =>
        await _applicationsService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Application>> Get(string id)
    {
        var application = await _applicationsService.GetAsync(id);

        if (application is null)
        {
            return NotFound();
        }

        return application;
    }


    [HttpPost]
    public async Task<IActionResult> Post(Application newApplication)
    {
        await _applicationsService.CreateAsync(newApplication);

        return CreatedAtAction(nameof(Get), new { id = newApplication.Id }, newApplication);
    }
}