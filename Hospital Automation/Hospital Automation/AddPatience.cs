using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hospital_Automation
{
    public partial class AddPatience : Form
    {
        public AddPatience()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-K8VM2MQ;Initial Catalog=Hospital automation;Integrated Security=True");

        private void btnSave_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("insert into SPatient (Name, Surname ,Pesel, BirthOfDate, Phone, Mail, Gender, Address) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", connection);
            command.Parameters.AddWithValue("@p1", txtName.Text);
            command.Parameters.AddWithValue("@p2", txtSurname.Text);
            command.Parameters.AddWithValue("@p3", txtPesel.Text);
            command.Parameters.AddWithValue("@p4", mskDate.Text);
            command.Parameters.AddWithValue("@p5", txtPhone.Text);
            command.Parameters.AddWithValue("@p6", txtMail.Text);
            command.Parameters.AddWithValue("@p7", cbxGender.Text);
            command.Parameters.AddWithValue("@p8", txtAddress.Text);

            command.ExecuteNonQuery();
            connection.Close();
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_MouseEnter(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.Bisque;
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.AntiqueWhite;
        }
    }
}
