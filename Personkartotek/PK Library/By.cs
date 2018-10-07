using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PK_Library
{
    public class Byy
    {
        public Byy(string _navn, string _postnummer, string _land)
        {
            Bynavn = _navn;
            Postnummer = _postnummer;
            Land = _land; 
        }

        public virtual long ByID { get; set; }
        public virtual string Postnummer { get; set; }
        public virtual string Land { get; set; }
        public virtual string Bynavn { get; set; }

    }
}
