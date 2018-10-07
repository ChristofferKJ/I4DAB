using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PK_Library
{
    public class Adresse
    {
        public  virtual int AdresseID { get; set; }
        public virtual int PersonID { get; set; }
        public virtual string Vej { get; set; }
        public virtual string By { get; set; }
        public virtual string Husnummer { get; set; }
        public virtual string Postnummer { get; set; }
    }
}
