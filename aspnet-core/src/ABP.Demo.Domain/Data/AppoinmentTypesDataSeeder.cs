using BookingSystem.Appointments;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace BookingSystem.Data
{
    public class AppoinmentTypesDataSeeder : IDataSeedContributor
    {
        private readonly IRepository<AppointmentType, int> _appoinmentTypeRepository;

        public AppoinmentTypesDataSeeder(IRepository<AppointmentType, int> appoinmentTypeRepository)
        {
            _appoinmentTypeRepository = appoinmentTypeRepository;
        }

        public Task SeedAsync(DataSeedContext context)
        {
            var appointmentTypes = new List<AppointmentType>
            {
                new AppointmentType
                {
                    TypeName = "Consultation"
                },
                new AppointmentType
                {
                    TypeName = "Follow-up"
                },
                new AppointmentType
                {
                    TypeName = "Surgery"
                },
                new AppointmentType
                {
                    TypeName = "Therapy Session"
                },
                new AppointmentType
                {
                    TypeName = "Health Check-up"
                }
            };

            return _appoinmentTypeRepository.InsertManyAsync(appointmentTypes);

        }
    }
}
