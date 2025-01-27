using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABP.Demo.Appointments
{
    public class DoctorAppointmentDto
    {
        public int AppoinmentId { get; set; }
        public DateTime AppoinmentDate { get; set; }
        public string AppointmentStatus { get; set; }
        public Guid? PatientTenantId { get; set; }
        public int PatientId { get; set; }
        public int AppoinmentTypeId { get; set; }
    }
}
