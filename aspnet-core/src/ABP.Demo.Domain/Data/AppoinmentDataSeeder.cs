using ABP.Demo.Appointments;
using BookingSystem.Appointments;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace BookingSystem.Data
{
    public class AppoinmentDataSeeder : IDataSeedContributor
    {

        private readonly IRepository<Appointment, int> _appointmentsRepository;

        public AppoinmentDataSeeder(IRepository<Appointment, int> appointmentsRepository)
        {
            _appointmentsRepository = appointmentsRepository;
        }

        public Task SeedAsync(DataSeedContext context)
        {
            var appointments = new List<Appointment>
            {
                new Appointment
                {
                    AppointmentDate = new DateTime(2025, 1, 22, 10, 0, 0),
                    AppointmentStatus = AppointmentStatus.Scheduled,
                    AppointmentTypeId = 1,
                    DoctorId = 1,
                    PatientId = 2
                },
                new Appointment
                {
                    AppointmentDate = new DateTime(2025, 1, 23, 14, 30, 0),
                    AppointmentStatus = AppointmentStatus.Completed,
                    AppointmentTypeId = 2,
                    DoctorId = 4,
                    PatientId = 4
                },
                new Appointment
                {
                    AppointmentDate = new DateTime(2025, 1, 24, 9, 0, 0),
                    AppointmentStatus = AppointmentStatus.Cancelled,
                    AppointmentTypeId = 1,
                    DoctorId = 2,
                    PatientId = 1
                },
                new Appointment
                {
                    AppointmentDate = new DateTime(2025, 1, 25, 11, 0, 0),
                    AppointmentStatus = AppointmentStatus.Scheduled,
                    AppointmentTypeId = 2,
                    DoctorId = 4,
                    PatientId = 5
                },
                new Appointment
                {
                    AppointmentDate = new DateTime(2025, 1, 26, 15, 0, 0),
                    AppointmentStatus = AppointmentStatus.Scheduled,
                    AppointmentTypeId = 2,
                    DoctorId = 5,
                    PatientId = 3
                }
            };

            return _appointmentsRepository.InsertManyAsync(appointments);
        }
    }
}
