using BookingSystem.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace ABP.Demo.Data
{
    public class DoctorAvailabilityDataSeeder : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<DoctorAvailability, int> _doctorAvailabilityRepository;

        public DoctorAvailabilityDataSeeder(IRepository<DoctorAvailability, int> doctorAvailabilityRepository)
        {
            _doctorAvailabilityRepository = doctorAvailabilityRepository;
        }

        public Task SeedAsync(DataSeedContext context)
        {
            var doctorAvailabilities = new List<DoctorAvailability>
            {
                new DoctorAvailability
                {
                    DoctorId = 1,
                    StartTime = new DateTime(2025, 01, 01, 9, 0, 0),
                    EndTime = new DateTime(2025, 01, 01, 12, 0, 0),
                    Day = DaysOfWeek.Monday
                },
                new DoctorAvailability
                {
                    DoctorId = 1,
                    StartTime = new DateTime(2025, 01, 02, 14, 0, 0),
                    EndTime = new DateTime(2025, 01, 02, 17, 0, 0),
                    Day = DaysOfWeek.Tuesday
                },

                new DoctorAvailability
                {
                    DoctorId = 2,
                    StartTime = new DateTime(2025, 01, 03, 9, 0, 0),
                    EndTime = new DateTime(2025, 01, 03, 12, 0, 0),
                    Day = DaysOfWeek.Wednesday
                },

                new DoctorAvailability
                {
                    DoctorId = 3,
                    StartTime = new DateTime(2025, 01, 04, 14, 0, 0),
                    EndTime = new DateTime(2025, 01, 04, 17, 0, 0),
                    Day = DaysOfWeek.Thursday
                },
                new DoctorAvailability
                {
                    DoctorId = 3,
                    StartTime = new DateTime(2025, 01, 05, 9, 0, 0),
                    EndTime = new DateTime(2025, 01, 05, 12, 0, 0),
                    Day = DaysOfWeek.Friday
                },

                new DoctorAvailability
                {
                    DoctorId = 4,
                    StartTime = new DateTime(2025, 01, 06, 9, 0, 0),
                    EndTime = new DateTime(2025, 01, 06, 12, 0, 0),
                    Day = DaysOfWeek.Monday
                },
                new DoctorAvailability
                {
                    DoctorId = 4,
                    StartTime = new DateTime(2025, 01, 07, 14, 0, 0),
                    EndTime = new DateTime(2025, 01, 07, 17, 0, 0),
                    Day = DaysOfWeek.Tuesday
                },
                new DoctorAvailability
                {
                    DoctorId = 4,
                    StartTime = new DateTime(2025, 01, 08, 9, 0, 0),
                    EndTime = new DateTime(2025, 01, 08, 12, 0, 0),
                    Day = DaysOfWeek.Wednesday
                },

                new DoctorAvailability
                {
                    DoctorId = 5,
                    StartTime = new DateTime(2025, 01, 09, 14, 0, 0),
                    EndTime = new DateTime(2025, 01, 09, 17, 0, 0),
                    Day = DaysOfWeek.Thursday
                },
                new DoctorAvailability
                {
                    DoctorId = 5,
                    StartTime = new DateTime(2025, 01, 10, 9, 0, 0),
                    EndTime = new DateTime(2025, 01, 10, 12, 0, 0),
                    Day = DaysOfWeek.Friday
                },

                new DoctorAvailability
                {
                    DoctorId = 6,
                    StartTime = new DateTime(2025, 01, 11, 9, 0, 0),
                    EndTime = new DateTime(2025, 01, 11, 12, 0, 0),
                    Day = DaysOfWeek.Monday
                },

                new DoctorAvailability
                {
                    DoctorId = 7,
                    StartTime = new DateTime(2025, 01, 12, 14, 0, 0),
                    EndTime = new DateTime(2025, 01, 12, 17, 0, 0),
                    Day = DaysOfWeek.Tuesday
                },
                new DoctorAvailability
                {
                    DoctorId = 7,
                    StartTime = new DateTime(2025, 01, 13, 9, 0, 0),
                    EndTime = new DateTime(2025, 01, 13, 12, 0, 0),
                    Day = DaysOfWeek.Wednesday
                },

                new DoctorAvailability
                {
                    DoctorId = 8,
                    StartTime = new DateTime(2025, 01, 14, 9, 0, 0),
                    EndTime = new DateTime(2025, 01, 14, 12, 0, 0),
                    Day = DaysOfWeek.Thursday
                },

                new DoctorAvailability
                {
                    DoctorId = 9,
                    StartTime = new DateTime(2025, 01, 15, 14, 0, 0),
                    EndTime = new DateTime(2025, 01, 15, 17, 0, 0),
                    Day = DaysOfWeek.Friday
                }
            };


            return _doctorAvailabilityRepository.InsertManyAsync(doctorAvailabilities);

        }
    }
}
