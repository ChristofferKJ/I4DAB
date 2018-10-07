using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PK_Library
{
    public class Noter
    {
        public virtual int NoterID { get; set; }
        public virtual string Note { get; set; }
        public virtual int PersonID { get; set; }


    }
}
