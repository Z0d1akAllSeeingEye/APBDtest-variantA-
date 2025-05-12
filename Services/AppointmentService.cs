using Microsoft.EntityFrameworkCore;
using WebApplication3.DoctorAppointmentsAPI.Data;
using WebApplication3.DoctorAppointmentsAPI.DTOs;
using WebApplication3.DoctorAppointmentsAPI.Models;

namespace WebApplication3.DoctorAppointmentsAPI.Services;

  public class AppointmentService : IAppointmentService
    {
        private readonly AppDbContext _context;
        public AppointmentService(AppDbContext context) => _context = context;

        public async Task<AppointmentResponseDto?> GetAppointmentByIdAsync(int id)
        {
            var appointment = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Include(a => a.AppointmentServices)
                    .ThenInclude(asv => asv.Service)
                .FirstOrDefaultAsync(a => a.AppointmentId == id);

            if (appointment == null) return null;

            return new AppointmentResponseDto
            {
                Date = appointment.Date,
                Patient = new PatientDto
                {
                    FirstName = appointment.Patient.FirstName,
                    LastName = appointment.Patient.LastName,
                    DateOfBirth = appointment.Patient.DateOfBirth
                },
                Doctor = new DoctorDto
                {
                    DoctorId = appointment.DoctorId,
                    Pwz = appointment.Doctor.Pwz
                },
                AppointmentServices = appointment.AppointmentServices.Select(s => new ServiceDto
                {
                    Name = s.Service.Name,
                    ServiceFee = s.Service.ServiceFee
                }).ToList()
            };
        }

        public async Task<string?> AddAppointmentAsync(AppointmentRequestDto dto)
        {
            if (await _context.Appointments.AnyAsync(a => a.AppointmentId == dto.AppointmentId))
                return "Appointment already exists.";

            var patient = await _context.Patients.FindAsync(dto.PatientId);
            if (patient == null) return "Invalid patient ID.";

            var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Pwz == dto.Pwz);
            if (doctor == null) return "Invalid doctor PWZ.";

            var serviceEntities = new List<Service>();
            foreach (var svc in dto.Services)
            {
                var existing = await _context.Services.FirstOrDefaultAsync(s => s.Name == svc.Name);
                if (existing == null) return $"Service not found: {svc.Name}";
                serviceEntities.Add(existing);
            }

            var newAppointment = new Appointment
            {
                AppointmentId = dto.AppointmentId,
                Date = DateTime.Now,
                PatientId = dto.PatientId,
                DoctorId = doctor.DoctorId,
                AppointmentServices = serviceEntities.Select(s => new Models.AppointmentService
                {
                    ServiceId = s.ServiceId,
                    AppointmentId = dto.AppointmentId
                }).ToList()
            };

            _context.Appointments.Add(newAppointment);
            await _context.SaveChangesAsync();
            return null;
        }
    }