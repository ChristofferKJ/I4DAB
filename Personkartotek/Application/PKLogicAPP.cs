using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using PK_Library;

namespace ApplicationLogic
{
    public class PKLogicAPP
    {
        public void TheAPP()
        {
            DBUtil utilities = new DBUtil();
            Person HansZimmer = new Person() { Navn = "Hans Zimmer", Type = "Kastestjerne", PersonID = 1};
            Person LarsHjortshoj = new Person() {Navn = "Lars Hjortshoj", Type = "Stripper", PersonID = 2};

            utilities.AddPerson(ref HansZimmer);
            utilities.AddPerson(ref LarsHjortshoj);

            utilities.GetPersonByID(ref HansZimmer);
            utilities.GetPersonByID(ref LarsHjortshoj);

        }
    }
}
