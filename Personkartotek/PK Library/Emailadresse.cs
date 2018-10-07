using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PK_Library
{
    public class Emailadresse
    {
        public virtual int EmailID { get; set; }
        public virtual int PersonID { get; set; }
        public virtual string Email { get; set; }
    }
}
