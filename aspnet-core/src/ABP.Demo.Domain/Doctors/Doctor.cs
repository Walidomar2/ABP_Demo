using ABP.Demo.Appointments;
using BookingSystem.Appointments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace BookingSystem.Doctors
{
    public class Doctor : Entity<int>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Specialization { get; set; }
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public virtual ICollection<DoctorAvailability> DoctorAvailabilities { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
