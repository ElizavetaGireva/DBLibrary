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
    public partial class StudentsLibrary : Form
    {
        public StudentsLibrary()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form ActiveIssuance = new ActiveIssuance();
            ActiveIssuance.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form StudentsIssuance = new StudentsIssuance();
            StudentsIssuance.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form SearchBook = new SearchBook();
            SearchBook.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }

        public int id;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            id = 2;
            Form Information = new Information(id);
            Information.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            id = 4;
            Form Information = new Information(id);
            Information.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            id = 11;
            Form Information = new Information(id);
            Information.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            id = 8;
            Form Information = new Information(id);
            Information.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            id = 10;
            Form Information = new Information(id);
            Information.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            id = 9;
            Form Information = new Information(id);
            Information.Show();
        }
    }
}
