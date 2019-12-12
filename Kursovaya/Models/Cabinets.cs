using System;
using System.Collections.Generic;

namespace Kursovaya
{
    public partial class Cabinets
    {
        public Cabinets()
        {
            Timetable = new HashSet<Timetable>();
        }

        public short CabinetNumber { get; set; }
        public short SeatsCount { get; set; }
        public short Floor { get; set; }

        public ICollection<Timetable> Timetable { get; set; }
    }
}
