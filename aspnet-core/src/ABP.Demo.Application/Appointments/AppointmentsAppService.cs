using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using System;

namespace ABP.Demo.Appointments
{
    [RemoteService(false)]
    public class AppointmentsAppService : ApplicationService,
        IAppointmentsAppService,
        IScopedDependency
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentsAppService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<List<PatientAppointmentDto>> GetPatientAppointments(int patientId)
        {
            var appointmentsDomain = await _appointmentRepository.GetAppointmentsByPatientId(patientId);

            var appointmentDtos = new List<PatientAppointmentDto>();

            foreach (var appointment in appointmentsDomain)
            {
                appointmentDtos.Add(new PatientAppointmentDto
                {
                    AppointmentId = appointment.Id,
                    AppoinmentDate = appointment.AppointmentDate,
                    AppointmentStatus = appointment.AppointmentStatus.ToString(),
                    DoctorId = appointment.DoctorId,
                    AppoinmentTypeId = appointment.AppointmentTypeId
                });
            }

            return appointmentDtos;
        }

        public async Task<List<DoctorAppointmentDto>> GetDoctorAppointmentsRange(int id, DateTime startDate, DateTime endDate)
        {
            var appointmentsDomain = await _appointmentRepository.GetAppointmentsRangeByDoctorId(id, startDate, endDate);

            var appointmentDtos = new List<DoctorAppointmentDto>();

            foreach (var appointment in appointmentsDomain)
            {
                appointmentDtos.Add(new DoctorAppointmentDto
                {
                    AppoinmentId = appointment.Id,
                    AppoinmentDate = appointment.AppointmentDate,
                    AppointmentStatus = appointment.AppointmentStatus.ToString(),
                    PatientTenantId = appointment.Patient.TenantId,
                    PatientId = appointment.Patient.Id,
                    AppoinmentTypeId = appointment.AppointmentTypeId
                });
            }

            return appointmentDtos;
        }

        public async Task<List<DoctorAppointmentDto>> GetDoctorAppointments(int doctorId)
        {
            var appointmentsDomain = await _appointmentRepository.GetAppointmentsByDoctorId(doctorId);

            var appointmentDtos = new List<DoctorAppointmentDto>();

            foreach (var appointment in appointmentsDomain)
            {
                appointmentDtos.Add(new DoctorAppointmentDto
                {
                    AppoinmentId = appointment.Id,
                    AppoinmentDate = appointment.AppointmentDate,
                    AppointmentStatus = appointment.AppointmentStatus.ToString(),
                    PatientTenantId = appointment.Patient.TenantId,
                    PatientId = appointment.Patient.Id,
                    AppoinmentTypeId = appointment.AppointmentTypeId
                });
            }

            return appointmentDtos;
        }

        public async Task<List<PatientUpcomingAppointmentDto>> GetPatientUpcomingAppointments(int patientId)
        {
            var appointmentsDomain = await _appointmentRepository.GetUpcomingAppointmentsByPatientId(patientId);

            var appointmentDtos = new List<PatientUpcomingAppointmentDto>();

            foreach (var appointment in appointmentsDomain)
            {
                appointmentDtos.Add(new PatientUpcomingAppointmentDto
                {
                    AppointmentId = appointment.Id,
                    AppoinmentDate = appointment.AppointmentDate,
                    AppointmentStatus = appointment.AppointmentStatus.ToString(),
                    DoctorName = appointment.Doctor.Name,
                    AppointmentType = appointment.AppointmentType.TypeName,
                    PatientName = appointment.Patient.FullName
                });
            }

            return appointmentDtos;
        }

        public async Task<List<AppointmentsCountDto>> GetDoctorAppointmentsCountAndStatus()
        {
            var appointmentsGroups = await _appointmentRepository.GetAppointmentCountsByDoctorAndStatusAsync();

            var appointmentsGroupDtos = new List<AppointmentsCountDto>();   
            
            foreach(var group in appointmentsGroups)
            {
                appointmentsGroupDtos.Add(new AppointmentsCountDto
                {
                    DoctorName = group.DoctorName,
                    AppointmentStatus = group.AppointmentStatus.ToString(),
                    AppointmentCount = group.AppointmentCount   
                });
            }

            return appointmentsGroupDtos;
        }

        public async Task<CreateAppointmentDto?> CreateAppointment(CreateAppointmentDto createAppointmentModel)
        {
            if (createAppointmentModel is null)
            {
                return null;
            }

            var appointmentModelDomain = new Appointment
            {
                AppointmentDate = createAppointmentModel.AppointmentDate,
                AppointmentStatus = AppointmentStatus.Scheduled,
                AppointmentTypeId = createAppointmentModel.AppointmentTypeId,
                PatientId = createAppointmentModel.PatientId,
                DoctorId = createAppointmentModel.DoctorId,
            };

            await _appointmentRepository.CreateAppointmentAsync(appointmentModelDomain);

            return createAppointmentModel;
        }
    }
}
