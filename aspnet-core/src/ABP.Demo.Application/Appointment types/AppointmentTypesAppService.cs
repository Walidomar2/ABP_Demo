using Abp.Application.Services;
using ABP.Demo.Appointment_Types;
using ABP.Demo.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ABP.Demo.Appointment_types
{
    [RemoteService(false)]
    public class AppointmentTypesAppService : ApplicationService,
        IAppointmentTypesAppService,
        IScopedDependency
    {
        private readonly IAppointmentTypesRepository _appointmentTypesRepository;

        public AppointmentTypesAppService(IAppointmentTypesRepository appointmentTypesRepository)
        {
            _appointmentTypesRepository = appointmentTypesRepository;
        }
        public async Task<List<AppointmentTypeDto>> GetAllAppointmentTypes()
        {
            var appointTypesDomain = await _appointmentTypesRepository.GetAllAsync();

            var appointmentTypeDtos = new List<AppointmentTypeDto>();

            foreach(var appointmentType in appointTypesDomain)
            {
                appointmentTypeDtos.Add(new AppointmentTypeDto
                {
                    Id = appointmentType.Id,
                    AppointmentType = appointmentType.TypeName
                });  
            }

            return appointmentTypeDtos;
        }
    }
}
