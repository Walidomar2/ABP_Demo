
using Abp.Application.Services;
using ABP.Demo.Appointments;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABP.Demo.Appointment_Types
{
    public interface IAppointmentTypesAppService : IApplicationService
    {
        Task<List<AppointmentTypeDto>> GetAllAppointmentTypes();
    }
}
