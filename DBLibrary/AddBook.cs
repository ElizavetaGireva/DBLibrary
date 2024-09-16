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
    public partial class AddBook : Form
    {
        public AddBook()
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
            if (string.IsNullOrEmpty(textBox1.Text))
                errorProvider1.SetError(textBox1, "Значение поля не может быть пустым.");

            string author = textBox3.Text;
            string publisher = textBox4.Text;
            string book = textBox5.Text;
            string year = textBox6.Text;
            int cell = int.Parse(textBox1.Text);

            int authorId;
            int publisherId;

            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database = partners;User Id = postgres; Password = 123456;"))
            {
                conn.Open();
                string script = " SELECT author_id FROM author WHERE author_surname = @author";
                NpgsqlCommand command = new NpgsqlCommand(script, conn);
                command.Parameters.AddWithValue("@author", author);
                authorId = (int)command.ExecuteScalar();

                if (authorId < 0)
                    MessageBox.Show("Автор не найден");
            }

            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database = partners;User Id = postgres; Password = 123456;"))
            {
                conn.Open();
                string script = " SELECT publisher_id FROM publisher WHERE publisher_name = @name";
                NpgsqlCommand command = new NpgsqlCommand(script, conn);
                command.Parameters.AddWithValue("@name", publisher);
                publisherId = (int)command.ExecuteScalar();

                if (publisherId < 0)
                    MessageBox.Show("Изадательство");

            }
            using (NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database = partners;User Id = postgres; Password = 123456;"))
            {
                conn.Open();
                NpgsqlCommand comm = new NpgsqlCommand($" INSERT INTO book (book_id, author_id, publisher_id, book_name, book_year, cell_id)  VALUES ((select book_id+1 from book where book_id = (select max(book_id) from book)), @author, @publisher, @name, @year, @cell)", conn);

                comm.Parameters.AddWithValue("@author", authorId);
                comm.Parameters.AddWithValue("@publisher", publisherId);
                comm.Parameters.AddWithValue("@name", book);
                comm.Parameters.AddWithValue("@year", year);
                comm.Parameters.AddWithValue("@cell", cell);

                NpgsqlDataReader dr = comm.ExecuteReader();
                MessageBox.Show("Книга добавлена");

                this.Hide();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
