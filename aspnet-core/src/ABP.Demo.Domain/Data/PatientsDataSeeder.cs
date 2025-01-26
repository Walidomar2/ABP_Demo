using ABP.Demo.Patients;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace BookingSystem.Data
{
    internal class PatientsDataSeeder : IDataSeedContributor
    {

        private readonly IRepository<Patient, int> _patientRepository;

        public PatientsDataSeeder(IRepository<Patient, int> patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public Task SeedAsync(DataSeedContext context)
        {
            var patients = new List<Patient>
            {
                new Patient
                {
                    FullName = "John Doe",
                    Email = "john.doe@example.com",
                    PhoneNumber = "123-456-7890"
                },
                new Patient
                {
                    FullName = "Jane Smith",
                    Email = "jane.smith@example.com",
                    PhoneNumber = "987-654-3210"
                },
                new Patient
                {
                    FullName = "Michael Johnson",
                    Email = "michael.johnson@example.com",
                    PhoneNumber = "555-123-4567"
                },
                new Patient
                {
                    FullName = "Emily Davis",
                    Email = "emily.davis@example.com",
                    PhoneNumber = "444-987-6543"
                },
                new Patient
                {
                    FullName = "David Wilson",
                    Email = "david.wilson@example.com",
                    PhoneNumber = "222-333-4444"
                }
            };

            return _patientRepository.InsertManyAsync(patients);

        }

    }
}
