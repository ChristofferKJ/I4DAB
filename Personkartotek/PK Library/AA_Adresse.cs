using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PK_Library
{
    public class AA_Adresse
    {
        public AA_Adresse(Person _person, Adresse _adresse, string _type)
        {
            Type = _type;
            AdresseID = _adresse.AdresseID;
            PersonID = _person.PersonID;
        }
        public virtual long AA_AdresseID { get; set; }
        public virtual long PersonID { get; set; }
        public virtual long AdresseID { get; set; }
        public virtual string Type { get; set; }
    }
}
