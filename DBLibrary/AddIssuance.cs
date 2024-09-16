using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlX.XDevAPI.Common;
using Npgsql;
using NpgsqlTypes;

namespace DBLibrary
{
    public partial class AddIssuance : Form
    {
        public AddIssuance()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(textBox3.Text))
                errorProvider1.SetError(textBox3, "Значение поля не может быть пустым.");
            if (string.IsNullOrEmpty(textBox4.Text))
                errorProvider1.SetError(textBox4, "Значение поля не может быть пустым.");
            if (string.IsNullOrEmpty(textBox5.Text))
                errorProvider1.SetError(textBox5, "Значение поля не может быть пустым.");
            if (string.IsNullOrEmpty(textBox6.Text))
                errorProvider1.SetError(textBox6, "Значение поля не может быть пустым.");

            string email = textBox3.Text;
            string date1 = textBox5.Text;
            string book = textBox4.Text;
            string date2 = textBox6.Text;

            DateTime convertedDate1 = DateTime.Parse(date1);
            DateTime convertedDate2 = DateTime.Parse(date2);

            int userId;
            int bookId;

            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database = partners;User Id = postgres; Password = 123456;"))
            {
                conn.Open();
                string script = " SELECT client_id FROM client WHERE client_login = @email";
                NpgsqlCommand command = new NpgsqlCommand(script, conn);
                command.Parameters.AddWithValue("@email", email);
                userId = (int)command.ExecuteScalar();

                if (userId < 0)
                    MessageBox.Show("Пользователь с таким логином не найден");

            }

            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database = partners;User Id = postgres; Password = 123456;"))
            {
                conn.Open();
                string script = " SELECT book_id FROM book WHERE book_name = @name";
                NpgsqlCommand command = new NpgsqlCommand(script, conn);
                command.Parameters.AddWithValue("@name", book);
                bookId = (int)command.ExecuteScalar();

                if (bookId < 0)
                    MessageBox.Show("Такая книга не найдена");

            }
            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database = partners;User Id = postgres; Password = 123456;"))
            {
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand($" INSERT INTO issuance (issuance_id, client_id, book_id, issuance_firstdate, issuance_secdate)  VALUES ((select issuance_id+1 from issuance where issuance_id = (select max(issuance_id) from issuance)), @email, @book, @date1, @date2)", conn);

                comm.Parameters.AddWithValue("@email", userId);
                comm.Parameters.AddWithValue("@book", bookId);
                comm.Parameters.AddWithValue("@date1", convertedDate1);
                comm.Parameters.AddWithValue("@date2", convertedDate2);

                NpgsqlDataReader dr = comm.ExecuteReader();
                MessageBox.Show("Заказ добавлен");

                this.Hide();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


    }
}
