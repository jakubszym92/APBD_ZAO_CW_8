using System;
using System.Collections.Generic;

namespace APBD_ZAO_CW_8.Models
{
    public class Patient
    {
        public Patient()
        {
            Prescriptions = new HashSet<Prescription>();
        }


        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }


        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
