using BookingSystem.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABP.Demo.Appointments
{
    public interface IAppointmentTypesRepository
    {
        Task<List<AppointmentType>> GetAllAsync();
    }
}
