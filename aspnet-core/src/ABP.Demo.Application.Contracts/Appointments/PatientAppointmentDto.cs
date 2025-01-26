using BookingSystem.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABP.Demo.Appointments
{
    public class PatientAppointmentDto
    {
        public int AppointmentId { get; set; }
        public DateTime AppoinmentDate { get; set; }
        public string AppointmentStatus { get; set; }
        public int DoctorId { get; set; }
        public int AppoinmentTypeId { get; set; }
    }
}
