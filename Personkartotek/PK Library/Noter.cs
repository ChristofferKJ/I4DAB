using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PK_Library
{
    public class Noter
    {
        public Noter(string _Note)
        {
            Note = _Note; 
        }

        public virtual long NoterID { get; set; }
        public virtual string Note { get; set; }
        public virtual long PersonID { get; set; }
    }
}
