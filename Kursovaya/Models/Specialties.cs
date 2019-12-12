using System;
using System.Collections.Generic;

namespace Kursovaya
{
    public partial class Specialties
    {
        public Specialties()
        {
            Doctors = new HashSet<Doctors>();
        }

        public short SpecialtyId { get; set; }
        public string Name { get; set; }

        public ICollection<Doctors> Doctors { get; set; }
    }
}
