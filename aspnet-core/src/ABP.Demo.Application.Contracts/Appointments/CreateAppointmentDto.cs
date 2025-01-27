using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABP.Demo.Appointments
{
    public class CreateAppointmentDto
    {
        [Required]
        public DateTime AppointmentDate { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public int AppointmentTypeId { get; set; }
    }
}
