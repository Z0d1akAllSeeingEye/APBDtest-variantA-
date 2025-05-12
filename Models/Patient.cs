namespace WebApplication3.DoctorAppointmentsAPI.Models;

public class Patient
{
    public int PatientId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }

    public ICollection<Appointment> Appointments { get; set; }
}
