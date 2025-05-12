namespace WebApplication3.DoctorAppointmentsAPI.Models;
public class Doctor
{
    public int DoctorId { get; set; }
    public string Pwz { get; set; } = string.Empty;

    public ICollection<Appointment> Appointments { get; set; }
}