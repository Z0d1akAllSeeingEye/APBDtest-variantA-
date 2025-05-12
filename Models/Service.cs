namespace WebApplication3.DoctorAppointmentsAPI.Models;

public class Service
{
    public int ServiceId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal ServiceFee { get; set; }

    public ICollection<AppointmentService> AppointmentServices { get; set; }
}