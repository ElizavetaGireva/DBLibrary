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
    public partial class Information : Form
    {
        public int id;
        public Information(int id)
        {
            InitializeComponent();
            this.id = id;   
        }
        

        private void Information_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Port=5432;Database = partners;User Id = postgres; Password = 123456;";
            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                string script = $"SELECT book_name, author_surname, publisher_name FROM book JOIN author ON book.author_id = author.author_id JOIN publisher ON book.publisher_id = publisher.publisher_id WHERE book_id = {id}";


                using (NpgsqlCommand com = new NpgsqlCommand(script, con))
                {
                    using (NpgsqlDataReader read = com.ExecuteReader())
                    {
                        if (read.Read())
                        {
                            name.Text = read.GetValue(0).ToString();
                            author.Text = read.GetValue(1).ToString();
                            publisher.Text = read.GetValue(2).ToString();
                        }
                    }
                }
            }
               
            

            
        }
    }
}
