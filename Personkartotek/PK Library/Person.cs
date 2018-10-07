using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PK_Library
{
    public class Person
    {
        public virtual int PersonID { get; set; }
        public virtual string Navn { get; set; }
        public virtual string Type { get; set; }

    }
}
