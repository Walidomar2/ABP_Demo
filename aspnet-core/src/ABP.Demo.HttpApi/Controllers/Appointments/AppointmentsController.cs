using ABP.Demo.Appointments;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABP.Demo.Controllers.Appointments
{
    [Route("api/appointments")]
    public class AppointmentsController : DemoController, IAppointmentsAppService
    {

        private readonly IAppointmentsAppService _appointmentsAppService;

        public AppointmentsController(IAppointmentsAppService appointmentsAppService)
        {
            _appointmentsAppService = appointmentsAppService;
        }


        [HttpGet]
        [Route("patientappointments/{id:int}")]
        public async Task<List<PatientAppointmentDto>> GetPatientAppointments(int id)
        {

            return await _appointmentsAppService.GetPatientAppointments(id);
            
        }

        [HttpGet]
        [Route("patientupcomingappointments/{id:int}")]
        public async Task<List<PatientUpcomingAppointmentDto>> GetPatientUpcomingAppointments([FromRoute] int id)
        {
            return await _appointmentsAppService.GetPatientUpcomingAppointments(id);
        }

        [HttpGet]
        [Route("doctorappointmentsrange/{id:int}")]
        public async Task<List<DoctorAppointmentDto>> GetDoctorAppointmentsRange([FromRoute] int id,
          [FromQuery] DateTime startDate,
          [FromQuery] DateTime endDate)
        {
            return await _appointmentsAppService.GetDoctorAppointmentsRange(id, startDate, endDate);
        }


        [HttpGet]
        [Route("doctorappointments/{id:int}")]
        public async Task<List<DoctorAppointmentDto>> GetDoctorAppointments([FromRoute] int id)
        {
           return await _appointmentsAppService.GetDoctorAppointments(id);

;       }

        [HttpGet]
        public async Task<List<AppointmentsCountDto>> GetDoctorAppointmentsCountAndStatus()
        {
           return await _appointmentsAppService.GetDoctorAppointmentsCountAndStatus();
        }

        [HttpPost]
        public async Task<CreateAppointmentDto?> CreateAppointment(CreateAppointmentDto createAppointmentModel)
        {
            return await _appointmentsAppService.CreateAppointment(createAppointmentModel);
        }
    }
}
