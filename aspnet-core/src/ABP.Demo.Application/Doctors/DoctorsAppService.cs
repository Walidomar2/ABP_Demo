using BookingSystem.Doctors;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using ABP.Demo.Appointments;

namespace ABP.Demo.Doctors
{
    [RemoteService(false)]
    public class DoctorsAppService : ApplicationService
        , IDoctorsAppService
        , IScopedDependency
    {
        
        private readonly IDoctorRepository _doctorRepository;
        public DoctorsAppService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<List<DoctorDto>> GetAllDoctors()
        {
            var doctorsDomain = await _doctorRepository.GetAllAsync();

            var doctorDtos = new List<DoctorDto>();

            foreach (var doctor in doctorsDomain)
            {
                doctorDtos.Add(new DoctorDto
                {
                    Id = doctor.Id,
                    Name = doctor.Name,
                    Email = doctor.Email,
                    Specialization = doctor.Specialization,
                    PhoneNumber = doctor.PhoneNumber,
                });
            }

            return doctorDtos;
        }

        public async Task<List<PopularAppointmentDto>> GetPopularAppointments(int id)
        {
            var popularAppointmentsDomain = await _doctorRepository.GetPopularAppointment(id);

            var popularAppointmentDtos = new List<PopularAppointmentDto>();

            foreach(var popularAppointment in popularAppointmentsDomain)
            {
                popularAppointmentDtos.Add(new PopularAppointmentDto
                {
                    AppointmentType = popularAppointment.AppointmentType,
                    Count = popularAppointment.Count
                });
            }

            return popularAppointmentDtos;
        }
    }
}
