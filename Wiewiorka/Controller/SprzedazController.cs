using System;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mime;
using System.Windows.Forms;
using Wiewiorka.Model;

namespace Wiewiorka.Controller
{
    public class SprzedazController
    {
        public Sprzedaz GetDataFromForm(TextBox _tbprodukt, TextBox _tbIlosc, TextBox _cenaJednostkowa,
            DateTimePicker _dtSprzedaz, ComboBox _cbpracownik)
        {
            Sprzedaz nowaSprzedaz = new Sprzedaz
            {
                productId = Convert.ToInt32(_tbprodukt.Text),
                ilosc = Convert.ToInt32(_tbIlosc),
                cena = Double.Parse(_cenaJednostkowa.Text),
                data = _dtSprzedaz.Value.Date.ToString("yyy-MM-dd"),
                pracownikId = Convert.ToInt32(_cbpracownik)
            };
            return nowaSprzedaz;
        }

        public bool DodajSprzedaz(Sprzedaz sprzedaz, int sklepId)
        {
            try
            {
                Connect connect = new Connect();
                var connection = connect.ConnectToDatabase();

                using (var command = new SqlCommand())
                {
                    string zapytanie = "INSERT INTO Sprzedaz VALUES (@productId, @ilosc, @cena, @data, @pracownikId, @sklepId);";

                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    command.CommandText = zapytanie;

                    command.Parameters.AddWithValue("@productId", sprzedaz.productId);
                    command.Parameters.AddWithValue("@ilosc", sprzedaz.ilosc);
                    command.Parameters.AddWithValue("@cena", sprzedaz.cena);
                    command.Parameters.AddWithValue("@data", sprzedaz.data);
                    command.Parameters.AddWithValue("@pracownikId", sprzedaz.pracownikId);
                    command.Parameters.AddWithValue("@sklepid", sklepId);

                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
    }
}