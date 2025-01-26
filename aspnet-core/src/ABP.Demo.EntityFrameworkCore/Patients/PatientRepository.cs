using ABP.Demo.Appointments;
using ABP.Demo.EntityFrameworkCore;
using BookingSystem.Appointments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.TenantManagement;

namespace ABP.Demo.Patients
{
    public class PatientRepository : EfCoreRepository<DemoDbContext, Patient, int>,
        IPatientRepository,
        IScopedDependency
    {
        public PatientRepository(IDbContextProvider<DemoDbContext> dbContextProvider) : base(dbContextProvider)
        {
            
        }

        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            var dbContext = await GetDbContextAsync();

            return await dbContext.Patients.ToListAsync();

        }

        public async Task<Patient?> GetPatientByIdAsync(int id)
        {
            var dbContext = await GetDbContextAsync();

            return await dbContext.Patients.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
