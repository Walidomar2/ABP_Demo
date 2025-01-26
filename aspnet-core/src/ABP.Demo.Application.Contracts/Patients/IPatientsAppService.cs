using Abp.Application.Services;
using ABP.Demo.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABP.Demo.Patients
{
    public interface IPatientsAppService : IApplicationService
    {
        Task<List<PatientDto>> GetAllPatients();
        Task<PatientDto?> GetPatientById(int id);
    }
}
