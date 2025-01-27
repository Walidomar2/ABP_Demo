using ABP.Demo.Appointment_Types;
using ABP.Demo.Appointments;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABP.Demo.Controllers.Appointments
{
    [Route("api/appointmenttypes")]
    public class AppointmentTypesController : DemoController, IAppointmentTypesAppService
    {

        private readonly IAppointmentTypesAppService _appointmentTypesAppService;

        public AppointmentTypesController(IAppointmentTypesAppService appointmentTypesAppService)
        {
            _appointmentTypesAppService = appointmentTypesAppService;
        }

        [HttpGet]
        public async Task<List<AppointmentTypeDto>> GetAllAppointmentTypes()
        {
            return await _appointmentTypesAppService.GetAllAppointmentTypes();
        }
    }
}
