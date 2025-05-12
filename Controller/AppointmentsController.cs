using Microsoft.AspNetCore.Mvc;
using WebApplication3.DoctorAppointmentsAPI.DTOs;
using WebApplication3.DoctorAppointmentsAPI.Services;

namespace WebApplication3.DoctorAppointmentsAPI.Controller;

[ApiController]
[Route("api/appointments")]
public class AppointmentsController : ControllerBase
{
    private readonly IAppointmentService _service;
    public AppointmentsController(IAppointmentService service) => _service = service;

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAppointment(int id)
    {
        var result = await _service.GetAppointmentByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAppointment(AppointmentRequestDto dto)
    {
        var error = await _service.AddAppointmentAsync(dto);
        if (error != null)
            return BadRequest(new { error });
        return CreatedAtAction(nameof(GetAppointment), new { id = dto.AppointmentId }, dto);
    }
}