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

            Byy _by = new Byy("Vladivostock", "90099", "Russkiy");
            utilities.GetByByByID(ref _by);
            utilities.AddBy(ref _by);

            Adresse _adresse = new Adresse("Okeanskiy Prospekt", "333B", _by);
            utilities.GetAdresseByID(ref _adresse);
            utilities.AddAdresse(ref _adresse);


            Person _person = new Person("Cyka Blyat","Idi","Nahui","Gopnik",_adresse);
            utilities.GetPersonByID(ref _person);
            utilities.AddPerson(ref _person);

     

        }
    }
}
