using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PK_Library
{
    public class Adresse
    {
        public Adresse(string _Vej, string _Husnummer, Byy _By)
        {
            Vej = _Vej;
            Husnummer = _Husnummer;
            ByID = _By.ByID;
            PersonerPaaAdressen = new List<Person>();
        }

        public virtual long ByID { get; set; }
        public virtual long AdresseID { get; set; }
        public virtual ICollection<Person> PersonerPaaAdressen { get; set; }
        public virtual string Vej { get; set; }
        public virtual Byy Byy { get; set; }
        public virtual string Husnummer { get; set; }
    }
}
