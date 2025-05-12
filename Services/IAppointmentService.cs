using WebApplication3.DoctorAppointmentsAPI.DTOs;

namespace WebApplication3.DoctorAppointmentsAPI.Services;

public interface IAppointmentService
{
    Task<AppointmentResponseDto?> GetAppointmentByIdAsync(int id);
    Task<string?> AddAppointmentAsync(AppointmentRequestDto dto);
}