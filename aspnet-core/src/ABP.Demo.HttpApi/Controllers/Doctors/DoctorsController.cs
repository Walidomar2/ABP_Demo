using Abp.Application.Services;
using ABP.Demo.Doctors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABP.Demo.Controllers.Doctors
{

    [Route("api/doctors")]
    public class DoctorsController : DemoController, IDoctorsAppService
    {
        private readonly IDoctorsAppService _doctorsAppService;

        public DoctorsController(IDoctorsAppService doctorsAppService)
        {
            _doctorsAppService = doctorsAppService;
        }

        [HttpGet]
        public async Task<List<DoctorDto>> GetAllDoctors()
        {
            return await _doctorsAppService.GetAllDoctors();
        }

        [HttpGet]
        [Route("popularappointments/{id:int}")]
        public async Task<List<PopularAppointmentDto>> GetPopularAppointments([FromRoute]  int id)
        {
            return await _doctorsAppService.GetPopularAppointments(id);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<List<DoctorAvailabilityDto>> GetDoctorAvailability([FromRoute] int id)
        {
            return await _doctorsAppService.GetDoctorAvailability(id);
        }
    }
}
