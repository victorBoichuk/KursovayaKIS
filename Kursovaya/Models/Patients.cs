using System;
using System.Collections.Generic;

namespace Kursovaya
{
    public partial class Patients
    {
        public Patients()
        {
            Timetable = new HashSet<Timetable>();
        }

        public int PatientId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string PassportNumber { get; set; }
        public string InsuranceNumber { get; set; }

        public ICollection<Timetable> Timetable { get; set; }
    }
}
