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
using NpgsqlTypes;

namespace DBLibrary
{
    public partial class ActiveIssuance : Form
    {
        public ActiveIssuance()
        {
            InitializeComponent();
        }
        public NpgsqlConnection myconn;
        public NpgsqlCommand mycomm;
        public string connect = "Server=localhost;Port=5432;Database = partners;User Id = postgres; Password = 123456;";

        DB db = new DB();

        private void button2_Click(object sender, EventArgs e)
        {
            //string script = " SELECT issuance_id, client_name, client_surname, book_name, issuance_firstdate, issuance_secdate FROM issuance AS i JOIN client AS c ON i.client_id = c.client_id JOIN book AS b ON i.book_id = b.book_id WHERE c.client_id = @user_id";
            DB db = new DB();

            DataTable table = new DataTable();

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();

            LogIn login = (LogIn)Application.OpenForms["LogIn"];
            int IdUser = login.getIdUser();

            NpgsqlCommand command = new NpgsqlCommand("SELECT client_name, client_surname, book_name, issuance_firstdate, issuance_secdate FROM issuance AS i JOIN client AS c ON i.client_id = c.client_id JOIN book AS b ON i.book_id = b.book_id WHERE c.client_id = @user_id", db.GetConnection());
            
            command.Parameters.Add("@user_id", NpgsqlDbType.Integer).Value = IdUser;


            adapter.SelectCommand = command;
            adapter.Fill(table);

            dgv2.DataSource = table;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form StudentsLibrary = new StudentsLibrary();
            StudentsLibrary.Show();
            this.Hide();
        }
    }
}
