using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PK_Library
{
    public class Telefon
    {
        public virtual int TeleID { get; set; }
        public virtual int OperatoerID { get; set; }
        public virtual int PersonID { get; set; }
        public virtual string Telefonnummer { get; set; }
    }

}
