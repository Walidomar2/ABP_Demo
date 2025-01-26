using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;
using ABP.Demo.Appointments;

namespace ABP.Demo.Patients
{
    public class Patient: Entity<int>, IMultiTenant
    {
        [Required]
        public string FullName { get; set; }
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public Guid? TenantId { get; set; }
    }
}
