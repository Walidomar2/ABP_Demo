using Abp.Application.Services;
using ABP.Demo.Appointments;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ABP.Demo.Patients
{
    [RemoteService(false)]
    public class PatientsAppService : ApplicationService,
        IPatientsAppService,
        IScopedDependency
    {
        private readonly IPatientRepository _patientRepository;

        public PatientsAppService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<List<PatientDto>> GetAllPatients()
        {
            var patientsDomain = await _patientRepository.GetAllPatientsAsync();

            var patientsDto = new List<PatientDto>();

            foreach(var patient in patientsDomain)
            {
                patientsDto.Add(new PatientDto
                {
                    Id = patient.Id,
                    FullName = patient.FullName,
                    Email = patient.Email,
                    PhoneNumber = patient.PhoneNumber,
                });
            }

            return patientsDto; 
        }

        public async Task<PatientDto?> GetPatientById(int id)
        {
            var patientDomain = await _patientRepository.GetPatientByIdAsync(id);

            if(patientDomain is null)
            {
                return null;
            }

            var patientDto = new PatientDto
            {
                Id= id,
                FullName = patientDomain.FullName,
                Email = patientDomain.Email,
                PhoneNumber = patientDomain.PhoneNumber,
            };

            return patientDto;  
        }
    }
}
