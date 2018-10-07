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
        public DBUtil() { }

        private SqlConnection openConnection
        {
            get
            {
                var con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Personkartotek;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True");
                con.Open();
                return con;
            }
        }

        //CRUD for Personer

        public void AddPerson(ref Person pp)
        {
            string insertStringParam =
                @"INSERT INTO [Person] (Fornavn, Mellemnavn, Efternavn, AdresseID, Type)
                                                OUTPUT INSERTED.PersonID
                                                VALUES (@Fornavn, @Mellemnavn, @Efternavn,  @AdresseID, @Type)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, openConnection))
            {
                cmd.Parameters.AddWithValue("@Fornavn", pp.Fornavn);
                cmd.Parameters.AddWithValue("@Mellemnavn", pp.Mellemnavn);
                cmd.Parameters.AddWithValue("@Efternavn", pp.Efternavn);
                cmd.Parameters.AddWithValue("@AdresseID", pp.AdresseID);
                cmd.Parameters.AddWithValue("@Type", pp.Type);
                pp.PersonID = (long)cmd.ExecuteScalar();
            }
        }

        public void UpdatePerson(ref Person pp)
        {
            string insertStringParam =
                @"UPDATE Person SET Fornavn = @Fornavn, Mellemnavn = @Mellemnavn, Efternavn = @Efternavn, AdresseID = @AdresseID, Type = @Type WHERE PersonID = @PersonID";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, openConnection))
            {
                cmd.Parameters.AddWithValue("@Fornavn", pp.Fornavn);
                cmd.Parameters.AddWithValue("@Mellemnavn", pp.Mellemnavn);
                cmd.Parameters.AddWithValue("@Efternavn", pp.Efternavn);
                cmd.Parameters.AddWithValue("@AdresseID", pp.AdresseID);
                cmd.Parameters.AddWithValue("@Type", pp.Type);
                cmd.ExecuteNonQuery();
            }
        }

        public void GetPersonByID(ref Person pp)
        {
            string sqlcmd = @"SELECT [Fornavn], [Mellemnavn], [Efternavn], [Type] FROM Person WHERE ([PersonID] = @PersonID)";
            using (var cmd = new SqlCommand(sqlcmd, openConnection))
            {
                cmd.Parameters.AddWithValue("@PersonID", pp.PersonID);

                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    pp.PersonID = (long)rdr["PersonID"];
                }
            }
        }

        public void DeletePerson(ref Person pp)
        {
            string deleteString = @"DELETE FROM Person WHERE (PersonID = @PersonID)";
            using (SqlCommand cmd = new SqlCommand(deleteString, openConnection))
            {
                cmd.Parameters.AddWithValue("@PersonID", pp.PersonID);
                var id = (long)cmd.ExecuteNonQuery();
                pp = null;
            }
        }

        //CRD for Byer - Føler ikke at det giver mening at opdatere by

        public void AddBy(ref Byy bb)
        {
            string insertStringParam =
                @"INSERT INTO [Byy] (Bynavn, Postnummer, Land)
                                    OUTPUT INSERTED.ByID
                                    VALUES (@Bynavn, @Postnummer, @Land)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, openConnection))
            {
                cmd.Parameters.AddWithValue("@Bynavn", bb.Bynavn);
                cmd.Parameters.AddWithValue("@Postnummer", bb.Postnummer);
                cmd.Parameters.AddWithValue("@Land", bb.Land);
                bb.ByID = (long)cmd.ExecuteScalar();
            }

        }

        public void GetByByByID(ref Byy bb)
        {
            string sqlcmd = @"SELECT [Bynavn], [Postnummer], [Land] FROM Byy WHERE ([ByID] = @ByID)";
            using (var cmd = new SqlCommand(sqlcmd, openConnection))
            {
                cmd.Parameters.AddWithValue("@ByID", bb.ByID);

                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    bb.ByID = (long)rdr["ByID"];
                }
            }
        }

        public void DeleteBy(ref Byy bb)
        {
            string deleteString = @"DELETE FROM Person WHERE (ByID = @BYID)";
            using (SqlCommand cmd = new SqlCommand(deleteString, openConnection))
            {
                cmd.Parameters.AddWithValue("@ByID", bb.ByID);
                var id = (long)cmd.ExecuteNonQuery();
                bb = null;
            }
        }

        //CRUD for Adresser

        public void AddAdresse(ref Adresse aa)
        {
            string insertStringParam =
                @"INSERT INTO [Adresse] (Vej, Husnummer, ByID)
                                                OUTPUT INSERTED.AdresseID
                                                VALUES (@Vej, @Husnummer, @ByID)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, openConnection))
            {
                cmd.Parameters.AddWithValue("@Vej", aa.Vej);
                cmd.Parameters.AddWithValue("@Husnummer", aa.Husnummer);
                cmd.Parameters.AddWithValue("@ByID", aa.ByID);
                aa.AdresseID = (long)cmd.ExecuteScalar();
            }
        }

        public void UpdateAdresse(ref Adresse aa)
        {
            string insertStringParam =
                @"UPDATE Adresse SET Vej = @Vej, Husnummer = @Husnummer, ByID = @ByID WHERE AdresseID = @AdresseID";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, openConnection))
            {
                cmd.Parameters.AddWithValue("@Vej", aa.Vej);
                cmd.Parameters.AddWithValue("@Husnummer", aa.Husnummer);
                cmd.Parameters.AddWithValue("@ByID", aa.ByID);
                cmd.Parameters.AddWithValue("@AdresseID", aa.AdresseID);
                cmd.ExecuteNonQuery();
            }
        }

        public void GetAdresseByID(ref Adresse aa)
        {
            string sqlcmd = @"SELECT [Vej], [Husnummer], [ByID] FROM Adresse WHERE ([AdresseID] = @AdresseID)";
            using (var cmd = new SqlCommand(sqlcmd, openConnection))
            {
                cmd.Parameters.AddWithValue("@AdresseID", aa.AdresseID);

                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    aa.AdresseID = (long)rdr["AdresseID"];
                }
            }
        }

        public void DeleteAdresse(ref Adresse aa)
        {
            string deleteString = @"DELETE FROM Adresse WHERE (AdresseID = @AdresseID)";
            using (SqlCommand cmd = new SqlCommand(deleteString, openConnection))
            {
                cmd.Parameters.AddWithValue("@AdresseID", aa.AdresseID);
                var id = cmd.ExecuteNonQuery();
                aa = null;
            }
        }

        //CRUD for Alternative adresser

        public void AddAA_Adresse(ref AA_Adresse aaa)
        {
            string insertStringParam =
                @"INSERT INTO [AA_Adresse] (PersonID, AdresseID, Type)
                                                OUTPUT INSERTED.PersonID
                                                VALUES (@PersonID, @AdresseID, @Type)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, openConnection))
            {
                cmd.Parameters.AddWithValue("@PersonID", aaa.PersonID);
                cmd.Parameters.AddWithValue("@AdresseID", aaa.AdresseID);
                cmd.Parameters.AddWithValue("@Type", aaa.Type);
                aaa.AA_AdresseID = (long)cmd.ExecuteScalar();
            }
        }

        public void GetAA_AdresseByID(ref AA_Adresse aaa)
        {
            string sqlcmd = @"SELECT [Type], [AdresseID], [PersonID] FROM AA_Adresse WHERE ([AA_AdresseID] = @AA_AdresseID)";
            using (var cmd = new SqlCommand(sqlcmd, openConnection))
            {
                cmd.Parameters.AddWithValue("@AA_AdresseID", aaa.AA_AdresseID);

                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    aaa.AA_AdresseID = (long)rdr["AA_AdresseID"];
                }
            }
        }

        public void UpdateAA_Adresse(ref AA_Adresse aaa)
        {
            string insertStringParam =
                @"UPDATE AA_Adresse SET Type = @Type, AdresseID = @AdresseID, PersonID =  @PersonID WHERE AA_AdresseID = @AA_AdresseID";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, openConnection))
            {
                cmd.Parameters.AddWithValue("@Type", aaa.Type);
                cmd.Parameters.AddWithValue("@AdresseID", aaa.AdresseID);
                cmd.Parameters.AddWithValue("@PersonID", aaa.PersonID);
                cmd.ExecuteNonQuery();
            }

        }

        public void DeleteAA_Adresse(ref AA_Adresse aaa)
        {
            string deleteString = @"DELETE FROM AA_Adresse WHERE (AA_AdresseID = @AA_AdresseID)";
            using (SqlCommand cmd = new SqlCommand(deleteString, openConnection))
            {
                cmd.Parameters.AddWithValue("@AA_AdresseID", aaa.AA_AdresseID);
                var id = cmd.ExecuteNonQuery();
                aaa = null;
            }
        }

        //CRUD for Telefoner

        public void AddTelefon(ref Telefon tt)
        {
            string insertStringParam =
                @"INSERT INTO [Telefon] (Telefonnummer, OperatoerID, PersonID)
                                                OUTPUT INSERTED.TeleID
                                                VALUES (@Telefonnummer, @OperatoerID, @PersonID)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, openConnection))
            {
                cmd.Parameters.AddWithValue("@Telefonnummer", tt.Telefonnummer);
                cmd.Parameters.AddWithValue("@OperatoerID", tt.OperatoerID);
                cmd.Parameters.AddWithValue("@PersonID", tt.PersonID);
                tt.TeleID = (long)cmd.ExecuteScalar();
            }
        }

        public void GetTelefonByID(ref Telefon tt)
        {
            string sqlcmd = @"SELECT [Telefonnummer], [OperatoerID], [PersonID] FROM TeleID WHERE ([TeleID] = @TeleID)";
            using (var cmd = new SqlCommand(sqlcmd, openConnection))
            {
                cmd.Parameters.AddWithValue("@TeleID", tt.TeleID);

                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    tt.TeleID = (long)rdr["TeleID"];
                }
            }
        }

        public void UpdateTelefon(ref Telefon tt)
        {
            string insertStringParam =
                @"UPDATE Telefon SET Telefonnummer = @Telefonnummer, OperatoerID = @OperatoerID, PersonID =  @PersonID WHERE TeleID = @TeleID";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, openConnection))
            {
                cmd.Parameters.AddWithValue("@Telefonnummer", tt.Telefonnummer);
                cmd.Parameters.AddWithValue("@OperatoerID", tt.OperatoerID);
                cmd.Parameters.AddWithValue("@PersonID", tt.PersonID);
                cmd.ExecuteNonQuery();
            }

        }

        public void DeleteTelefon(ref Telefon tt)
        {
            string deleteString = @"DELETE FROM Telefon WHERE (TeleID = @TeleID)";
            using (SqlCommand cmd = new SqlCommand(deleteString, openConnection))
            {
                cmd.Parameters.AddWithValue("@TeleID", tt.TeleID);
                var id = cmd.ExecuteNonQuery();
                tt = null;
            }
        }

        //CRUD FOR Operatoer

        public void AddOperatoer(ref Operatoer oo)
        {
            string insertStringParam =
                @"INSERT INTO [Operatoer] (Navn)
                                   OUTPUT INSERTED.OperatoerID
                                   VALUES (@Navn)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, openConnection))
            {
                cmd.Parameters.AddWithValue("@Navn", oo.OperatoerID);
                oo.OperatoerID = (long)cmd.ExecuteScalar();
            }
        }

        public void GetOperatoerByID(ref Operatoer oo)
        {
            string sqlcmd = @"SELECT [Navn] FROM OperatoerID WHERE ([OperatoerID] = @OperatoerID)";
            using (var cmd = new SqlCommand(sqlcmd, openConnection))
            {
                cmd.Parameters.AddWithValue("@OperatoerID", oo.OperatoerID);

                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    oo.OperatoerID = (long)rdr["OperatoerID"];
                }
            }
        }

        public void UpdateOperatoer(ref Operatoer oo)
        {
            string insertStringParam =
                @"UPDATE Operatoer SET Navn = @Navn WHERE OperatoerID = @OperatoerID";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, openConnection))
            {
                cmd.Parameters.AddWithValue("@Navn", oo.Navn);
                cmd.ExecuteNonQuery();
            }

        }

        public void DeleteOperatoer(ref Operatoer oo)
        {
            string deleteString = @"DELETE FROM Operatoer WHERE (OperatoerID = @OperatoerID)";
            using (SqlCommand cmd = new SqlCommand(deleteString, openConnection))
            {
                cmd.Parameters.AddWithValue("@OperatoerID", oo.OperatoerID);
                var id = cmd.ExecuteNonQuery();
                oo = null;
            }
        }

        //CRUD FOR Noter

        public void AddNoter(ref Noter nn)
        {
            string insertStringParam =
                @"INSERT INTO [Noter] (Note, PersonID)
                                   OUTPUT INSERTED.NoterID
                                   VALUES (@Note, @PersonID)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, openConnection))
            {
                cmd.Parameters.AddWithValue("@Note", nn.Note);
                cmd.Parameters.AddWithValue("@PersonID", nn.PersonID);
                nn.NoterID = (long)cmd.ExecuteScalar();
            }
        }

        public void GetNoterByID(ref Noter nn)
        {
            string sqlcmd = @"SELECT [Note], [PersonID] FROM NoterID WHERE ([NoterID] = @NoterID)";
            using (var cmd = new SqlCommand(sqlcmd, openConnection))
            {
                cmd.Parameters.AddWithValue("@NoterID", nn.NoterID);

                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    nn.NoterID = (long)rdr["NoterID"];
                }
            }
        }

        public void UpdateNoter(ref Noter nn)
        {
            string insertStringParam =
                @"UPDATE Noter SET Note = @Note WHERE NoterID = @NoterID";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, openConnection))
            {
                cmd.Parameters.AddWithValue("@Note", nn.Note);
                cmd.ExecuteNonQuery();
            }

        }

        public void DeleteNoter(ref Noter nn)
        {
            string deleteString = @"DELETE FROM Noter WHERE (NoterID = @NoterID)";
            using (SqlCommand cmd = new SqlCommand(deleteString, openConnection))
            {
                cmd.Parameters.AddWithValue("@NoterID", nn.NoterID);
                var id = cmd.ExecuteNonQuery();
                nn = null;
            }
        }

        //CRUD FOR Email

        public void AddEmailadresse(ref Emailadresse ee)
        {
            string insertStringParam =
                @"INSERT INTO [EmailAdresse] (Email, PersonID)
                                   OUTPUT INSERTED.EmailID
                                   VALUES (@Email, @PersonID)";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, openConnection))
            {
                cmd.Parameters.AddWithValue("@Email", ee.Email);
                cmd.Parameters.AddWithValue("@PersonID", ee.PersonID);
                ee.EmailID = (long)cmd.ExecuteScalar();
            }
        }

        public void GetEmailadresseByID(ref Emailadresse ee)
        {
            string sqlcmd = @"SELECT [Emailadresse] FROM EmailID WHERE ([EmailID] = @EmailID)";
            using (var cmd = new SqlCommand(sqlcmd, openConnection))
            {
                cmd.Parameters.AddWithValue("@EmailID", ee.EmailID);

                SqlDataReader rdr = null;
                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    ee.EmailID = (long)rdr["EmailID"];
                }
            }
        }

        public void UpdateEmailadresse(ref Emailadresse ee)
        {
            string insertStringParam =
                @"UPDATE Emailadresse SET Email = @Email WHERE EmailID = @EmailID";

            using (SqlCommand cmd = new SqlCommand(insertStringParam, openConnection))
            {
                cmd.Parameters.AddWithValue("@Email", ee.Email);
                cmd.ExecuteNonQuery();
            }

        }

        public void DeleteEmailadresse(ref Emailadresse ee)
        {
            string deleteString = @"DELETE FROM EmailAdresse WHERE (EmailID = @EmailID)";
            using (SqlCommand cmd = new SqlCommand(deleteString, openConnection))
            {
                cmd.Parameters.AddWithValue("@EmailID", ee.EmailID);
                var id = cmd.ExecuteNonQuery();
                ee = null;
            }
        }

    }
}
