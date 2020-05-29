using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using Wiewiorka.Model;

namespace Wiewiorka.Controller
{
    public class DataFromDatabase
    {
        public List<string> Sklepy()
        {
            List<string> sklepy = new List<string>();
            Connect c = new Connect();
            var connection = c.ConnectToDatabase();

            SqlCommand command = new SqlCommand("select NazwaSklepu from Sklep", connection);

            using (SqlDataReader sr = command.ExecuteReader())
            {
                while (sr.Read())
                {
                    sklepy.Add(sr["NazwaSklepu"].ToString());
                }

            }

            return sklepy;
        }

        public int SklepAktualny(ComboBox comboBox)
        {
            int idSklepu = 0;
            Connect c = new Connect();
            var connection = c.ConnectToDatabase();

            SqlCommand command = new SqlCommand("select idSklepu from Sklep where NazwaSklepu = '" + comboBox.Text + "'", connection);

            using (SqlDataReader sr = command.ExecuteReader())
            {
                while (sr.Read())
                {
                    idSklepu = Convert.ToInt32(sr["idSklepu"]);
                }

            }
            return idSklepu;

        }
    }
}