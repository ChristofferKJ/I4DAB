using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PK_Library
{
    public class Person
    {
        public Person(string _Fornavn, string _Mellemnavn, string _Efternavn, string _Type, Adresse _Adresse)
        {
            Fornavn = _Fornavn;
            Mellemnavn = _Mellemnavn;
            Efternavn = _Efternavn;
            Type = _Type;
            AdresseID = _Adresse.AdresseID;

            AA_Adresser = new List<AA_Adresse>();
            mangeNoter = new List<Noter>();
            Emailadresser = new List<Emailadresse>();
            Telefoner = new List<Telefon>(); 
        }

        public virtual long PersonID { get; set; }
        public virtual string Fornavn { get; set; }
        public virtual string Mellemnavn { get; set; }
        public virtual string Efternavn { get; set; }
        public virtual string Type { get; set; }
        public virtual long AdresseID { get; set; }
        public virtual ICollection<AA_Adresse> AA_Adresser { get; set; }
        public virtual ICollection<Noter> mangeNoter { get; set; }
        public virtual ICollection<Emailadresse> Emailadresser { get; set; }
        public virtual ICollection<Telefon> Telefoner { get; set; }



    }
}
