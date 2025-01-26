using BookingSystem.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABP.Demo.Appointments
{
    public interface IAppointmentRepository
    {
        Task<List<Appointment>> GetAppointmentsByPatientId(int id);
        Task<List<Appointment>> GetUpcomingAppointmentsByPatientId(int id);
        Task<List<Appointment>> GetAppointmentsByDoctorId(int id);
        Task<List<Appointment>> GetAppointmentsRangeByDoctorId(int id, DateTime startDate, DateTime endDate);
        Task<List<(string DoctorName, AppointmentStatus AppointmentStatus, int AppointmentCount)>> GetAppointmentCountsByDoctorAndStatusAsync();
    }
}
