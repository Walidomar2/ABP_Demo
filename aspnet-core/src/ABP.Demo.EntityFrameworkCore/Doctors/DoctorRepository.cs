using ABP.Demo.Appointments;
using ABP.Demo.EntityFrameworkCore;
using BookingSystem.Doctors;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq;
using System;

namespace ABP.Demo.Doctors
{
    public class DoctorRepository : EfCoreRepository<DemoDbContext, Doctor, int>,
                                    IDoctorRepository,
                                    IScopedDependency
    {
        public DoctorRepository(IDbContextProvider<DemoDbContext> dbContextProvider): base(dbContextProvider) 
        {

        }
        public async Task<List<Doctor>> GetAllAsync()
        {
            var dbContext = await GetDbContextAsync();

            return await dbContext.Doctors.ToListAsync();
        }
       
        public async Task<List<(string AppointmentType, int Count)>> GetPopularAppointment(int id)
        {
            var dbContext = await GetDbContextAsync();

            var popularAppointmentTypes = await dbContext.Appointments
                .Where(a => a.DoctorId == id)  
                .GroupBy(a => a.AppointmentType)  
                .Select(group => new 
                {
                    AppointmentType = group.Key.TypeName,  
                    Count = group.Count()
                })
                .OrderByDescending(a => a.Count)
                .ToListAsync();

            return popularAppointmentTypes.Select(a => (a.AppointmentType, a.Count))
                .ToList();
        }
    }
}
