using ABP.Demo.Doctors;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using ABP.Demo.Appointments;

namespace BookingSystem.Doctors
{
    public interface IDoctorsAppService : IApplicationService
    {
        Task<List<DoctorDto>> GetAllDoctors();
        Task<List<PopularAppointmentDto>> GetPopularAppointments(int id);
        Task<List<DoctorAvailabilityDto>> GetDoctorAvailability(int id);  
    }
}
