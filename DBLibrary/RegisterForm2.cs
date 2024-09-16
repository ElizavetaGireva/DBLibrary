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
    public partial class RegisterForm2 : Form
    {
        public RegisterForm2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            NpgsqlCommand command = new NpgsqlCommand("INSERT INTO client (client_id, client_name, client_surname, client_pantronymic, client_group, client_login, client_pass) VALUES ((select client_id+1 from client where client_id = (select max(client_id) from client)), @name, @surname, @pat, @gr, @login, @pass)", db.GetConnection());

            command.Parameters.Add("@name", NpgsqlDbType.Char).Value = textBox1.Text;
            command.Parameters.Add("@surname", NpgsqlDbType.Char).Value = textBox2.Text;
            command.Parameters.Add("@pat", NpgsqlDbType.Char).Value = textBox4.Text;
            command.Parameters.Add("@gr", NpgsqlDbType.Char).Value = textBox3.Text;
            command.Parameters.Add("@login", NpgsqlDbType.Char).Value = textBox6.Text;
            command.Parameters.Add("@pass", NpgsqlDbType.Char).Value = textBox5.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт успешно создан");
                Form Form1 = new Form1();
                Form1.Show();
                this.Hide();
            }

            else
                MessageBox.Show("Аккаунт не был создан");

            db.closeConnection();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }
    }
}
