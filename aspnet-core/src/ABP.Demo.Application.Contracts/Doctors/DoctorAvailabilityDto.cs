using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABP.Demo.Doctors
{
    public class DoctorAvailabilityDto
    {
        public string DoctorName { get; set; }
        public string Day { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
