using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PK_Library
{
    public class Operatoer
    {
        public Operatoer(string _Navn)
        {
            Navn = _Navn;
            Telefoner = new List<Telefon>(); 
        }
        public virtual ICollection<Telefon> Telefoner {get;set;}
        public virtual long OperatoerID { get; set; }
        public virtual string Navn { get; set; }
    }
}
 