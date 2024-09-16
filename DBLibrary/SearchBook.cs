using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace DBLibrary
{
    public partial class SearchBook : Form
    {
        public SearchBook()
        {
            InitializeComponent();
        }

        public NpgsqlConnection myconn;
        public NpgsqlCommand mycomm;
        public string connect = "Server=localhost;Port=5432;Database = partners;User Id = postgres; Password = 123456;";

        DB db = new DB();

        private void button2_Click(object sender, EventArgs e)
        {
            string script = "SELECT author_surname, publisher_name, book_name, book_year FROM book JOIN author ON book.author_id = author.author_id JOIN publisher ON book.publisher_id = publisher.publisher_id WHERE book_name LIKE '%" + richTextBox1.Text + "%'";
            DataTable table = new DataTable();
            db.openConnection();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(script, connect);

            adapter.Fill(table);
            dgv2.DataSource = table;
            db.closeConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form StudentsLibrary = new StudentsLibrary();
            StudentsLibrary.Show();
            this.Hide();
        }
    }
}
