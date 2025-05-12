namespace WebApplication3.DoctorAppointmentsAPI.DTOs;

public class AppointmentRequestDto
{
    public int AppointmentId { get; set; }
    public int PatientId { get; set; }
    public string Pwz { get; set; }
    public List<ServiceDto> Services { get; set; }
}