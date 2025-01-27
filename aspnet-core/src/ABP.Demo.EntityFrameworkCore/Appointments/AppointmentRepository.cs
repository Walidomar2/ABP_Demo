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
    public class AppointmentRepository : EfCoreRepository<DemoDbContext, Appointment, int>,
        IAppointmentRepository,
        IScopedDependency

    {
        public AppointmentRepository(IDbContextProvider<DemoDbContext> dbContextProvider) : base(dbContextProvider)
        {
            
        }

        public async Task<List<Appointment>> GetAppointmentsByPatientId(int id)
        {
            var dbContext = await GetDbContextAsync();

            var appointments = await dbContext.Appointments
                     .Where(a => a.Patient.Id == id)
                     .ToListAsync();

            return appointments;
        }

        public async Task<List<Appointment>> GetUpcomingAppointmentsByPatientId(int id)
        {
            var dbContext = await GetDbContextAsync();

            var appointments = await dbContext.Appointments
                    .Where(appointment => appointment.Patient.Id == id && appointment.AppointmentDate > DateTime.Now)
                    .Include(a => a.Patient)
                    .Include(a => a.Doctor)
                    .Include(a => a.AppointmentType)
                    .ToListAsync();

            return appointments;
        }

        public async Task<List<Appointment>> GetAppointmentsByDoctorId(int id)
        {
            var dbContext = await GetDbContextAsync();

            var appointments = await dbContext.Appointments
                .Where(a => a.DoctorId == id)
                .Include(a => a.Patient)
                .ToListAsync();

            return appointments;
        }

        public async Task<List<Appointment>> GetAppointmentsRangeByDoctorId(int id, DateTime startDate, DateTime endDate)
        {
            var dbContext = await GetDbContextAsync();

            var appointments = await dbContext.Appointments
                .Where(a => a.DoctorId == id && a.AppointmentDate >= startDate && a.AppointmentDate <= endDate)
                .Include(a => a.Patient)
                .ToListAsync();

            return appointments;
        }

        public async Task<List<(string DoctorName, AppointmentStatus AppointmentStatus, int AppointmentCount)>> GetAppointmentCountsByDoctorAndStatusAsync()
        {
            var dbContext = await GetDbContextAsync();

            var groupedAppointments = await dbContext.Appointments
                .Include(a => a.Doctor) 
                .GroupBy(a => new { a.Doctor.Name, a.AppointmentStatus })
                .Select(group => new 
                {
                    DoctorName = group.Key.Name,
                    AppointmentStatus = group.Key.AppointmentStatus,
                    AppointmentCount = group.Count()
                })
                .ToListAsync();

            return groupedAppointments.Select(a => (a.DoctorName, a.AppointmentStatus, a.AppointmentCount))
                .ToList();
        }

        public async Task<Appointment?> CreateAppointmentAsync(Appointment appointment)
        {
            if (appointment is null)
            {
                return null;
            }

            var dbContext = await GetDbContextAsync();

            await dbContext.Appointments.AddAsync(appointment);
            await dbContext.SaveChangesAsync();
            return appointment;
        }
    }
}
