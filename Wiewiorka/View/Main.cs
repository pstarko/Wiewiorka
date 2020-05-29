using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wiewiorka.Controller;
using Wiewiorka.Model;
using Wiewiorka.View;
using Magazyn = Wiewiorka.View.Magazyn;
using Sklep = Wiewiorka.View.Sklep;

namespace Wiewiorka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void sklepyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sklep s = new Sklep();
            s.Show();
        }

        private void magazynToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Magazyn m = new Magazyn();
            m.Show();
        }

        private void produktyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Produkty p = new Produkty();
            p.Show();
        }

        private void przyjęcieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Przyjecie p = new Przyjecie();
            p.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataFromDatabase df = new DataFromDatabase();

            foreach (var item in df.Sklepy())
            {
                cbWybierzSklep.Items.Add(item);
            }


            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dtSprzedaz.Value.Date.ToString("yyy-MM-dd"));
            DataFromDatabase dt = new DataFromDatabase();
            int idAktualnegoSklepu = dt.SklepAktualny(cbWybierzSklep);

            SprzedazController sc = new SprzedazController();
            Sprzedaz NowaSprzedaz = sc.GetDataFromForm(tbProdukt, tbIlosc, tbCenaJednostkowa, dtSprzedaz, cbPracownik);
            sc.DodajSprzedaz(NowaSprzedaz, idAktualnegoSklepu);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
