using ABP.Demo.Appointments;
using BookingSystem.Doctors;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ABP.Demo.Doctors
{
    public interface IDoctorRepository
    {
        Task<List<Doctor>> GetAllAsync();
        Task<List<(string AppointmentType, int Count)>> GetPopularAppointment(int id); 
    }
}
