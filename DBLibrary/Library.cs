using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Npgsql;
using NpgsqlTypes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DBLibrary
{
    public partial class Library : Form
    {
        public Library()
        {
            InitializeComponent();
        }

        public NpgsqlConnection myconn;
        public NpgsqlCommand mycomm;
        public string connect = "Server=localhost;Port=5432;Database = partners;User Id = postgres; Password = 123456;";

        DB db = new DB();

        private void label3_Click(object sender, EventArgs e)
        {
            Form AddIssuance = new AddIssuance();
            AddIssuance.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string script = " SELECT issuance_id, client_name, client_surname, book_name, issuance_firstdate, issuance_secdate FROM issuance AS i JOIN client AS c ON i.client_id = c.client_id JOIN book AS b ON i.book_id = b.book_id";
            DataTable table = new DataTable();
            db.openConnection();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(script, connect);

            adapter.Fill(table);
            dgv.DataSource = table;
            db.closeConnection();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            string script = "SELECT issuance_id, client_name, client_surname, book_name, issuance_firstdate, issuance_secdate FROM issuance AS i JOIN client AS c ON i.client_id = c.client_id JOIN book AS b ON i.book_id = b.book_id WHERE i.issuance_secdate < '2024-04-15';";
            DataTable table = new DataTable();
            db.openConnection();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(script, connect);

            adapter.Fill(table);
            dgv.DataSource = table;
            db.closeConnection();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            string script = "SELECT book_id, author_surname, publisher_name, book_name, book_year, cell_number FROM book JOIN author ON book.author_id = author.author_id JOIN publisher ON book.publisher_id = publisher.publisher_id JOIN cell ON book.cell_id = cell.cell_id WHERE book_name LIKE '%" + richTextBox1.Text + "%'";
            DataTable table = new DataTable();
            db.openConnection();
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(script, connect);

            adapter.Fill(table);
            dgv.DataSource = table;
            db.closeConnection();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form AddPublisher = new AddPublisher();
            AddPublisher.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form AddBook = new AddBook();
            AddBook.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            int rowIndex = dgv.CurrentCell.RowIndex;
            dgv.Rows.RemoveAt(rowIndex);
        }
    }
}
