using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace Infrastructure
{
    public class DBUtil
    {
        private PK_Library.Person myPerson; 
        public DBUtil()
        {
            myPerson = new PK_Library.Person() {PersonID = 0, Navn="", Type=""};
        }

        private SqlConnection openConnection
        {
            get
            {
                var con = new SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Personkartotek;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True");
                con.Open();
                return con; 
            }
        }





    }
}
