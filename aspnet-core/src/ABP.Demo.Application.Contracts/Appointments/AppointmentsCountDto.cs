using BookingSystem.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABP.Demo.Appointments
{
    public class AppointmentsCountDto
    {
        public string DoctorName { get; set; }
        public string AppointmentStatus { get; set; }
        public int AppointmentCount { get; set; }
    }
}
