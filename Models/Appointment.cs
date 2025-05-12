namespace WebApplication3.DoctorAppointmentsAPI.Models;

public class Appointment
{
    public int AppointmentId { get; set; }
    public DateTime Date { get; set; }

    public int PatientId { get; set; }
    public Patient Patient { get; set; }

    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }

    public ICollection<AppointmentService> AppointmentServices { get; set; }
}