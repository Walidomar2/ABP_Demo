
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABP.Demo.Appointments
{
    public class PatientUpcomingAppointmentDto
    {
        public int AppointmentId { get; set; }
        public DateTime AppoinmentDate { get; set; }
        public string AppointmentStatus { get; set; }
        public string DoctorName { get; set; }
        public string AppointmentType { get; set; }
        public string PatientName { get; set; }
    }
}
