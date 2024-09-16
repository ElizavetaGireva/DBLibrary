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
using NpgsqlTypes;

namespace DBLibrary
{
    public partial class LogIn : Form
    {
        bool vis = true;

        public static int IdUser;
        public LogIn()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (vis)
            {
                textBox2.UseSystemPasswordChar = false;
                vis = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                vis = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            String login = textBox1.Text;
            String password = textBox2.Text;

            DB db = new DB();

            DataTable table = new DataTable();

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter ();

            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM client WHERE client_login = @l AND client_pass = @p", db.GetConnection());
            command.Parameters.Add("@l", NpgsqlDbType.Char).Value = login;
            command.Parameters.Add("@p", NpgsqlDbType.Char).Value = password;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                IdUser = (int)table.Rows[0]["client_id"];
                Form StudentsLibrary = new StudentsLibrary();
                StudentsLibrary.Show();
                this.Hide();
            }    
                
            else
                MessageBox.Show("Пользователь не авторизован");

        }
        
        public int getIdUser()
        {
            return IdUser;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }
    }
}
