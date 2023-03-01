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
    public partial class DObjednavky : Form
    {
        private Form1 form1;
        public DObjednavky(Form1 form1)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metoda pro vložení dat do databáze
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Pripojeni.GetInstance();
                SqlCommand cmd = new SqlCommand("INSERT INTO dobjednavky VALUES (@id,@id_objednavky,@id_produkty,@mnozstvi,@cena)", Pripojeni.GetInstance());
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@id_objednavky", int.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@id_produkty", int.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@mnozstvi", int.Parse(textBox4.Text));
                cmd.Parameters.AddWithValue("@cena", (textBox5.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data byla vložená");
            }
            catch
            {
                MessageBox.Show("Neco se pokazilo. Zkontrolujte připojení, data a opakování dat(id atd...)");
            }
        }


        /// <summary>
        /// Metoda peo změnu dat podle id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Pripojeni.GetInstance();

                SqlCommand cmd = new SqlCommand("update dobjednavky set id_objednavky=@id_objednavky, id_produkty=@id_produkty, mnozstvi=@mnozstvi, cena=@cena where id =@id", Pripojeni.GetInstance());
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@id_objednavky", int.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@id_produkty", int.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@mnozstvi", int.Parse(textBox4.Text));
                cmd.Parameters.AddWithValue("@cena", (textBox5.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data byla upravená");
            }
            catch
            {
                MessageBox.Show("Neco se pokazilo. Zkontrolujte připojení, data a opakování dat(id atd...)");
            }
        }

        /// <summary>
        /// Metoda pro odstranění dat podle id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                Pripojeni.GetInstance();

                SqlCommand cmd = new SqlCommand("delete from dobjednavky where id =@id", Pripojeni.GetInstance());
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data byla smazaná");
            }
            catch
            {
                MessageBox.Show("Neco se pokazilo. Zkontrolujte připojení, data a opakování dat(id atd...)");
            }
        }


        /// <summary>
        /// Metoda pro vypsání dat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Pripojeni.GetInstance();

                SqlCommand cmd = new SqlCommand("select * from dobjednavky", Pripojeni.GetInstance());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("Neco se pokazilo. Zkontrolujte připojení, data a opakování dat(id atd...)");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void DObjednavky_Load(object sender, EventArgs e)
        {

        }
    }
}
