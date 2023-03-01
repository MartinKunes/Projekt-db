using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPVProjekt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metoda pro propojení forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Zakaznik frm = new Zakaznik(this);
            frm.Show();
        }

        /// <summary>
        /// Metoda pro propojení forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Produkty frm = new Produkty(this);
            frm.Show();
        }

        /// <summary>
        /// Metoda pro propojení forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            Objednavky frm = new Objednavky(this);
            frm.Show();
        }

        /// <summary>
        /// Metoda pro propojení forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            DObjednavky frm = new DObjednavky(this);
            frm.Show();
        }

        /// <summary>
        /// Metoda pro propojení forms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            Vyrobce frm = new Vyrobce(this);
            frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
