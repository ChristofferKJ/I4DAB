using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PK_Library;


namespace Infrastructure
{
    public class DBUtil
    {
        private PK_Library.Person myPerson; 
        public DBUtil()
        {
            myPerson = new Person() {PersonID = 0, Navn="", Type=""};
        }

        private SqlConnection openConnection
        {
            get
            {
                var con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Personkartotek;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True");
                con.Open();
                return con; 
            }
        }

        public void AddPerson(ref Person pp)
        {
            string insertStringParam =
                @"INSERT INTO [Person] (Navn, Type) OUTPUT INSERTED.PersonID VALUES (@Navn, @Type)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, openConnection))
            {
                cmd.Parameters.AddWithValue("@Navn", pp.Navn);
                cmd.Parameters.AddWithValue("@Type", pp.Type);
                pp.PersonID = (int) cmd.ExecuteScalar();
            }
        }

        public void GetPersonByID(ref Person pp)
        {
            string sqlcmd = @"SELECT [Navn], [Type] FROM Person WHERE ([PersonID] = @PersonID)";
            using (var cmd = new SqlCommand(sqlcmd, openConnection))
            {
                cmd.Parameters.AddWithValue("@PersonID", pp.PersonID);
                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    myPerson.PersonID = pp.PersonID;
                    myPerson.Navn = (string)rdr["Navn"];
                    myPerson.Type = (string) rdr["Type"];
                    pp = myPerson;
                }
            }
        }

        public void DeletePerson(ref Person pp)
        {
            string deleteString = @"DELETE FROM Person WHERE (PersonID = @PersonID)";
            using (SqlCommand cmd = new SqlCommand(deleteString, openConnection))
            {
                cmd.Parameters.AddWithValue("@PersonID", pp.PersonID);
                var id = (int) cmd.ExecuteNonQuery();
                pp = null;  
            }
        }


    }
}
