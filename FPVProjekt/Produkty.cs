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
    public partial class Produkty : Form
    {
        private Form1 form1;
        public Produkty(Form1 form1)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metoda na vkládání dat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Pripojeni.GetInstance();
                SqlCommand cmd = new SqlCommand("INSERT INTO produkty VALUES (@id,@nazev,@kategorie,@popis, @cena)", Pripojeni.GetInstance());
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@nazev", textBox2.Text);
                cmd.Parameters.AddWithValue("@kategorie", (textBox3.Text));
                cmd.Parameters.AddWithValue("@popis", (textBox4.Text));
                cmd.Parameters.AddWithValue("@cena", (textBox5.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data byla vložena");
            }
            catch
            {
                MessageBox.Show("Neco se pokazilo. Zkontrolujte připojení, data a opakování dat(id atd...)");
            }
        }

        /// <summary>
        ///Metoda na změnu dat podle id 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Pripojeni.GetInstance();

                SqlCommand cmd = new SqlCommand("update produkty set nazev=@nazev, kategorie=@kategorie, popis=@popis, cena=@cena where id =@id", Pripojeni.GetInstance());

                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@nazev", textBox2.Text);
                cmd.Parameters.AddWithValue("@kategorie", (textBox3.Text));
                cmd.Parameters.AddWithValue("@popis", (textBox4.Text));
                cmd.Parameters.AddWithValue("@cena", (textBox5.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data byla upravena");
            }
            catch
            {
                MessageBox.Show("Neco se pokazilo. Zkontrolujte připojení, data a opakování dat(id atd...)");
            }
        }
         
        /// <summary>
        /// Metoda na smazaní dat podle id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                Pripojeni.GetInstance();

                SqlCommand cmd = new SqlCommand("delete from produkty where id =@id", Pripojeni.GetInstance());
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
        /// Metoda na vypsání dat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Pripojeni.GetInstance();

                SqlCommand cmd = new SqlCommand("select * from produkty", Pripojeni.GetInstance());
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
                //    MessageBox.Show("Připojeno");
                StreamReader reader = new StreamReader("produkty.csv");

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();


                    string[] values = line.Split(',');

                    SqlCommand cmd = new SqlCommand("INSERT INTO produkty VALUES (@id,@nazev,@kategorie,@popis, @cena)", Pripojeni.GetInstance());
                    //   cmd.Parameters.AddWithValue("@id", int.Parse(values[0]));
                    cmd.Parameters.AddWithValue("@id", int.Parse(values[0]));
                    cmd.Parameters.AddWithValue("@nazev", (values[1]));
                    cmd.Parameters.AddWithValue("@kategorie", (values[2]));
                    cmd.Parameters.AddWithValue("@popis", (values[3]));
                    cmd.Parameters.AddWithValue("@cena", (values[4]));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data ze souboru byla vložena");
                }
            }
            catch
            {
                MessageBox.Show("Neco se pokazilo. Zkontrolujte připojení, data a opakování dat(id atd...)");
            }
        }
        
        
        private void Produkty_Load(object sender, EventArgs e)
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

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

    
    }
    }
    

