using ABP.Demo.Appointments;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;

namespace BookingSystem.Appointments
{
    public class AppointmentType : Entity<int>
    {
        [Required]
        public string TypeName { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
