using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wiewiorka.View;

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
    }
}
