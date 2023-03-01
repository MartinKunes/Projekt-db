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
    public partial class Vyrobce : Form
    {
        private Form1 form1;
        public Vyrobce(Form1 form1)
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Metoda pro přidání výrobce do databáze
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                Pripojeni.GetInstance();
                SqlCommand cmd = new SqlCommand("INSERT INTO vyrobce VALUES (@id,@id_produkty,@nazev,@adresa,@telefon,@email)", Pripojeni.GetInstance());
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@id_produkty", int.Parse(textBox6.Text));
                cmd.Parameters.AddWithValue("@nazev", textBox2.Text);
                cmd.Parameters.AddWithValue("@adresa", (textBox3.Text));
                cmd.Parameters.AddWithValue("@telefon", int.Parse(textBox4.Text));
                cmd.Parameters.AddWithValue("@email", (textBox5.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data byla vložena");
            }
            catch
            {
                MessageBox.Show("Neco se pokazilo. Zkontrolujte připojení, data a opakování dat(id atd...)");
            }
        }
        
        /// <summary>
        /// Metoda pro upravení dat výrobce v databázi podle id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Pripojeni.GetInstance();

                SqlCommand cmd = new SqlCommand("update vyrobce set id_produkty=@id_produkty nazev=@nazev, adresa=@adresa, telefon=@telefon , email=@email where id =@id", Pripojeni.GetInstance());

                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@id_produkty", int.Parse(textBox6.Text));
                cmd.Parameters.AddWithValue("@nazev", textBox2.Text);
                cmd.Parameters.AddWithValue("@adresa", (textBox3.Text));
                cmd.Parameters.AddWithValue("@telefon", int.Parse(textBox4.Text));
                cmd.Parameters.AddWithValue("@email", (textBox5.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data byla změněna");
            }
            catch
            {
                MessageBox.Show("Neco se pokazilo. Zkontrolujte připojení, data a opakování dat(id atd...)");
            }
        }

        /// <summary>
        /// Metoda pro smazání výrobce z databáze podle id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                Pripojeni.GetInstance();

                SqlCommand cmd = new SqlCommand("delete from vyrobce where id =@id", Pripojeni.GetInstance());
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data s vybraným ID byla smazána");
            }
            catch
            {
                MessageBox.Show("Neco se pokazilo. Zkontrolujte připojení, data a opakování dat(id atd...)");
            }
        }

        /// <summary>
        /// Metoda pro zobrazení dat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Pripojeni.GetInstance();

                SqlCommand cmd = new SqlCommand("select * from vyrobce", Pripojeni.GetInstance());
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
     

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Vyrobce_Load(object sender, EventArgs e)
        {

        }
    }
}
