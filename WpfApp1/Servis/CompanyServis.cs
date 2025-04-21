using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IdentityModel.Metadata;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using Microsoft.Data.SqlClient;
using WpfApp1.Kontaks;
using WpfApp1.Models;

namespace WpfApp1.Servis
{
    internal class CompanyServis
    {
        public List<Kontakt> GetAllKontakts()
        {
            string connectionString = "Server=PK452-14;Database=Praktika923MV;Trust Server Certificate=True;Trusted_Connection=True;";
            var Kontakt = new List<Kontakt>();
            string sqlExpression = "SELECT * FROM Kontakt";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var contact = new Kontakt();
                        contact.Id = (int)reader["id"];
                        contact.Name = reader["name"].ToString();
                        contact.Phone = reader["phone"].ToString();
                        contact.Favorite = (bool)reader["favorite"];
                        contact.Groupid = (int)reader["groupid"];
                        Kontakt.Add(contact);
                    }

                }
                reader.Close();
            }

            return Kontakt;
        }
        public bool AddUser(Kontakt kontakt) 
        {
            string connectionString = "Server=PK452-14;Database=Praktika923MV;Trust Server Certificate=True;Trusted_Connection=True;";

            string sqlExpression = $"INSERT INTO Kontakt (name, phone ,favorite, groupid) VALUES ('{kontakt.Name}', '{kontakt.Phone}', {(kontakt.Favorite? 1 : 0)}, {kontakt.Groupid})";

            using (SqlConnection connection = new SqlConnection( connectionString)) 
            {
                connection.Open();
                SqlCommand command = new SqlCommand( sqlExpression, connection);
                int row = command.ExecuteNonQuery();
                return row > 0; 
            }
        }


    }
}
