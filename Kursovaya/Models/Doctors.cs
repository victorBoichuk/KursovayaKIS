using System;
using System.Collections.Generic;

namespace Kursovaya
{
    public partial class Doctors
    {
        public Doctors()
        {
            Timetable = new HashSet<Timetable>();
        }

        public short DoctorId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public short? SpecialtyId { get; set; }

        public Specialties Specialty { get; set; }
        public ICollection<Timetable> Timetable { get; set; }
    }
}
