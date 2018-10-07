using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PK_Library
{
    public class Emailadresse
    {
        public Emailadresse(string _Email)
        {
            Email = _Email;
        }

        public virtual long EmailID { get; set; }
        public virtual long PersonID { get; set; }
        public virtual string Email { get; set; }
    }
}
