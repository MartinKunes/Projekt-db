
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPVProjekt
{
    public partial class Zakaznik : Form
    {
        private Form1 form1;

        public Zakaznik(Form1 form1)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metoda pro přidání zákazníka do databáze
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Pripojeni.GetInstance();
                SqlCommand cmd = new SqlCommand("INSERT INTO zakaznik VALUES (@id,@jmeno,@prijmeni,@email)", Pripojeni.GetInstance());
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@jmeno", textBox2.Text);
                cmd.Parameters.AddWithValue("@prijmeni", (textBox3.Text));
                cmd.Parameters.AddWithValue("@email", (textBox4.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data byla vložena");
            }
            catch
            {
                MessageBox.Show("Neco se pokazilo. Zkontrolujte připojení, data a opakování dat(id atd...)");
            }
        }

        /// <summary>
        /// Metoda pro upraveni dat podle id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Pripojeni.GetInstance();

                SqlCommand cmd = new SqlCommand("update zakaznik set jmeno=@jmeno, prijmeni=@prijmeni, email=@email where id =@id", Pripojeni.GetInstance());

                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@jmeno", textBox2.Text);
                cmd.Parameters.AddWithValue("@prijmeni", (textBox3.Text));
                cmd.Parameters.AddWithValue("@email", (textBox4.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data byla změněna");
            }
            catch
            {
                MessageBox.Show("Neco se pokazilo. Zkontrolujte připojení, data a opakování dat(id atd...)");
            }
        }
        /// <summary>
        /// Metoda pro smazání zákazníka z databáze podle id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Pripojeni.GetInstance();
                SqlCommand cmd = new SqlCommand("delete from zakaznik where id =@id", Pripojeni.GetInstance());
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
        /// Metoda pro vypsání zákazníka
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Pripojeni.GetInstance();

                SqlCommand cmd = new SqlCommand("select * from zakaznik", Pripojeni.GetInstance());
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
        /// <summary>
        /// Metoda pro vložení dat ze souboru
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Pripojeni.GetInstance();
                StreamReader reader = new StreamReader("zakaznik.csv");

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');

                    SqlCommand cmd = new SqlCommand("INSERT INTO zakaznik VALUES (@id,@jmeno,@prijmeni,@email)", Pripojeni.GetInstance());
                    cmd.Parameters.AddWithValue("@id", int.Parse(values[0]));
                    cmd.Parameters.AddWithValue("@jmeno", (values[1]));
                    cmd.Parameters.AddWithValue("@prijmeni", (values[2]));
                    cmd.Parameters.AddWithValue("@email", (values[3]));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data se úspěšně uložila ze souboru csv");
                }
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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Zakaznik_Load(object sender, EventArgs e)
        {

            
        }
        

    }
}