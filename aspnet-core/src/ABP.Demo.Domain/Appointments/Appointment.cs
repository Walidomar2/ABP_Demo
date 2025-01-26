using ABP.Demo.Patients;
using System.ComponentModel.DataAnnotations;
using System;
using Volo.Abp.Domain.Entities;
using BookingSystem.Appointments;
using BookingSystem.Doctors;

namespace ABP.Demo.Appointments
{
    public class Appointment: AggregateRoot<int>
    {
        [Required]
        public DateTime AppointmentDate { get; set; }
        [Required]
        public AppointmentStatus AppointmentStatus { get; set; }
        public int AppointmentTypeId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual AppointmentType AppointmentType { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
