namespace WebApplication3.DoctorAppointmentsAPI.DTOs;

public class AppointmentResponseDto
{
    public DateTime Date { get; set; }
    public PatientDto Patient { get; set; }
    public DoctorDto Doctor { get; set; }
    public List<ServiceDto> AppointmentServices { get; set; }
}
