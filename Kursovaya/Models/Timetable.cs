using System;
using System.Collections.Generic;

namespace Kursovaya
{
    public partial class Timetable
    {
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public short? CabinetNumber { get; set; }
        public int? PatientId { get; set; }
        public short? DoctorId { get; set; }
        public int Id { get; set; }

        public Cabinets CabinetNumberNavigation { get; set; }
        public Doctors Doctor { get; set; }
        public Patients Patient { get; set; }
    }
}
