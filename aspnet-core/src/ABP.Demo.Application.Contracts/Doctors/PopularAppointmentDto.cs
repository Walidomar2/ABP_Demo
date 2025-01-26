using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABP.Demo.Doctors
{
    public class PopularAppointmentDto
    {
        public string AppointmentType { get; set; }
        public int Count { get; set; }
    }
}
