using BookingSystem.Doctors;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace BookingSystem.Data
{
    public class DoctorsDataSeeder : IDataSeedContributor
    {
        private readonly IRepository<Doctor, int> _doctorRepository;

        public DoctorsDataSeeder(IRepository<Doctor, int> doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public Task SeedAsync(DataSeedContext context)
        {
            var doctors = new List<Doctor>
            {
                new Doctor
                {
                    Name = "Dr. Sarah Johnson",
                    Specialization = "Cardiologist",
                    Email = "sarah.johnson@hospital.com",
                    PhoneNumber = "123-456-7890"
                },
                new Doctor
                {

                    Name = "Dr. James Wilson",
                    Specialization = "Dermatologist",
                    Email = "james.wilson@hospital.com",
                    PhoneNumber = "987-654-3210"
                },
                new Doctor
                {

                    Name = "Dr. Emily Brown",
                    Specialization = "Pediatrician",
                    Email = "emily.brown@hospital.com",
                    PhoneNumber = "555-123-4567"
                },
                new Doctor
                {
                    Name = "Dr. Michael Davis",
                    Specialization = "Neurologist",
                    Email = "michael.davis@hospital.com",
                    PhoneNumber = "444-987-6543"
                },
                new Doctor
                {
                    Name = "Dr. Olivia Martinez",
                    Specialization = "Orthopedic Surgeon",
                    Email = "olivia.martinez@hospital.com",
                    PhoneNumber = "222-333-4444"
                },
                new Doctor
                {
                    Name = "Dr. Daniel Harris",
                    Specialization = "Psychiatrist",
                    Email = "daniel.harris@hospital.com",
                    PhoneNumber = "333-555-7777"
                },
                new Doctor
                {
                    Name = "Dr. Sophia Taylor",
                    Specialization = "General Practitioner",
                    Email = "sophia.taylor@hospital.com",
                    PhoneNumber = "666-777-8888"
                },
                new Doctor
                {
                    Name = "Dr. Christopher Thomas",
                    Specialization = "Oncologist",
                    Email = "christopher.thomas@hospital.com",
                    PhoneNumber = "999-111-2222"
                },
                new Doctor
                {
                    Name = "Dr. Emma Jackson",
                    Specialization = "Gynecologist",
                    Email = "emma.jackson@hospital.com",
                    PhoneNumber = "555-888-9999"
                },
                new Doctor
                {
                    Name = "Dr. William Clark",
                    Specialization = "Pulmonologist",
                    Email = "william.clark@hospital.com",
                    PhoneNumber = "123-321-4567"
                }
            };

            return _doctorRepository.InsertManyAsync(doctors);
        }
    }
}
