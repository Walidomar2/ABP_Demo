using ABP.Demo.Appointments;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using System;

namespace ABP.Demo.Appointments
{
    public interface IAppointmentsAppService : IApplicationService
    {
        Task<CreateAppointmentDto?> CreateAppointment(CreateAppointmentDto createAppointmentModel);
        Task<List<PatientAppointmentDto>> GetPatientAppointments(int patientId);
        Task<List<PatientUpcomingAppointmentDto>> GetPatientUpcomingAppointments(int patientId);
        Task<List<DoctorAppointmentDto>> GetDoctorAppointments(int doctorId);
        Task<List<DoctorAppointmentDto>> GetDoctorAppointmentsRange(int id, DateTime startDate, DateTime endDate);
        Task<List<AppointmentsCountDto>> GetDoctorAppointmentsCountAndStatus();
       
    }
}
