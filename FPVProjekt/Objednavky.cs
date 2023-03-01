using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPVProjekt
{
    public partial class Objednavky : Form
    {
        private Form1 form1;
        public Objednavky(Form1 form1)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metoda pro přidání objednávky do databáze
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Pripojeni.GetInstance();
                SqlCommand cmd = new SqlCommand("INSERT INTO objednavky VALUES (@id,@id_zakaznik,@datum,@celkcena, @zpracovano)", Pripojeni.GetInstance());
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@id_zakaznik", int.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@datum", DateTime.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@celkcena", (textBox4.Text));
                cmd.Parameters.AddWithValue("@zpracovano", (textBox5.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data byla vložena");
            }
            catch
            {
                MessageBox.Show("Neco se pokazilo. Zkontrolujte připojení, data a opakování dat(id atd...)");
            }
        }


        /// <summary>
        /// Metoda pro změnu dat podle id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Pripojeni.GetInstance();

                SqlCommand cmd = new SqlCommand("update objednavky set id_zakaznik=@id_zakaznik, datum=@datum, celkcena=@celkcena, zpracovano=@zpracovano where id =@id", Pripojeni.GetInstance());

                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@id_zakaznik", int.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@datum", DateTime.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@celkcena", (textBox4.Text));
                cmd.Parameters.AddWithValue("@zpracovano", (textBox5.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("data byla upravena");
            }
            catch
            {
                MessageBox.Show("Neco se pokazilo. Zkontrolujte připojení, data a opakování dat(id atd...)");
            }
        }

        /// <summary>
        /// Metoda pro smazání dat podle id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                Pripojeni.GetInstance();
                SqlCommand cmd = new SqlCommand("delete from objednavky where id =@id", Pripojeni.GetInstance());
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data byla smazána");
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

                SqlCommand cmd = new SqlCommand("select * from objednavky", Pripojeni.GetInstance());
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
                                                                                    
        private void Objednavky_Load(object sender, EventArgs e)
        {

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
