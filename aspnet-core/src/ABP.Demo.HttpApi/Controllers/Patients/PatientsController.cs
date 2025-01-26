using Abp.Application.Services;
using ABP.Demo.Patients;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABP.Demo.Controllers.Patients
{
    [Route("api/patients")]
    public class PatientsController : DemoController, IPatientsAppService
    {
        private readonly IPatientsAppService _patientAppService;

        public PatientsController(IPatientsAppService patientAppService)
        {
            _patientAppService = patientAppService;
        }

        [HttpGet]
        public async Task<List<PatientDto>> GetAllPatients()
        {
            return await _patientAppService.GetAllPatients();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<PatientDto?> GetPatientById([FromRoute] int id)
        {
            return await _patientAppService.GetPatientById(id);
        }

    }

}
