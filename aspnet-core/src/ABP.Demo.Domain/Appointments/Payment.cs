using ABP.Demo.Appointments;
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace BookingSystem.Appointments
{
    public class Payment : FullAuditedEntity<int>
    {
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public PaymentMethod PaymentMethod { get; set; }
        [Required]
        public PaymentStatus PaymentStatus { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        public int AppointmentId { get; set; }
        public virtual Appointment Appointment { get; set; }
    }
}
