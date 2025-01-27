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

namespace ABP.Demo.Appointments
{
    public class AppointmentTypesRepository : EfCoreRepository<DemoDbContext, AppointmentType, int>,
        IAppointmentTypesRepository,
        IScopedDependency
    {


        public AppointmentTypesRepository(IDbContextProvider<DemoDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }


        public async Task<List<AppointmentType>> GetAllAsync()
        {
            var dbContext = await GetDbContextAsync();

            return await dbContext.AppointmentTypes.ToListAsync();
        }


    }
}
