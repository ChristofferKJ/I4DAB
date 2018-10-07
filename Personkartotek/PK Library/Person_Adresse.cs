using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PK_Library
{
    public class Person_Adresse
    {
        public virtual int PersonID { get; set; }
        public virtual int AdresseID { get; set; }
        public virtual string Type { get; set; }

    }
}
