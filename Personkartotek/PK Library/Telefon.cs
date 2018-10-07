using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PK_Library
{
    public class Telefon
    {
        public Telefon(string _Telefonnummer, Operatoer _Operatoer)
        {
            Telefonnummer = _Telefonnummer;
            OperatoerID = _Operatoer.OperatoerID;
        }

        public virtual long TeleID { get; set; }
        public virtual long OperatoerID { get; set; }
        public virtual long PersonID { get; set; }
        public virtual string Telefonnummer { get; set; }
    }

}
