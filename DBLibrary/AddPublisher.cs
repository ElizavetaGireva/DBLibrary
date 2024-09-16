using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace DBLibrary
{
    public partial class AddPublisher : Form
    {
        public AddPublisher()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
                errorProvider1.SetError(textBox3, "Значение поля не может быть пустым.");
            if (string.IsNullOrEmpty(textBox4.Text))
                errorProvider1.SetError(textBox4, "Значение поля не может быть пустым.");
            if (string.IsNullOrEmpty(textBox5.Text))
                errorProvider1.SetError(textBox5, "Значение поля не может быть пустым.");
            if (string.IsNullOrEmpty(textBox6.Text))
                errorProvider1.SetError(textBox6, "Значение поля не может быть пустым.");
            if (string.IsNullOrEmpty(textBox1.Text))
                errorProvider1.SetError(textBox1, "Значение поля не может быть пустым.");

            string name = textBox3.Text;
            string adress = textBox4.Text;
            string phone = textBox5.Text;
            string year = textBox6.Text;
            string email = textBox1.Text;


            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database = partners;User Id = postgres; Password = 123456;"))
            {
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand($" INSERT INTO publisher (publisher_id, publisher_name, publisher_adress, publisher_phone, publisher_year, publisher_email)  VALUES ((select publisher_id+1 from publisher where publisher_id = (select max(publisher_id) from publisher)), @name, @adress, @phone, @year, @email)", conn);

                comm.Parameters.AddWithValue("@name", name);
                comm.Parameters.AddWithValue("@adress", adress);
                comm.Parameters.AddWithValue("@phone", phone);
                comm.Parameters.AddWithValue("@year", year);
                comm.Parameters.AddWithValue("@email", email);

                NpgsqlDataReader dr = comm.ExecuteReader();
                MessageBox.Show("Издательство добавлено");

                this.Hide();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
