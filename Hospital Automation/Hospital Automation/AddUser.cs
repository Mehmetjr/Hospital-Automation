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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-K8VM2MQ;Initial Catalog=Hospital automation;Integrated Security=True");

        private void btnSave_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("insert into Admins (Name, Surname ,Pesel, Password, Department, URL, Phone, Mail, Gender, Policlinic, Instagram, Youtube, Twitter) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13)" , connection);
            command.Parameters.AddWithValue("@p1", txtName.Text);
            command.Parameters.AddWithValue("@p2", txtSurname.Text);
            command.Parameters.AddWithValue("@p3", txtPesel.Text);
            command.Parameters.AddWithValue("@p4", txtPass.Text);
            command.Parameters.AddWithValue("@p5", cbxDepartment.Text);
            command.Parameters.AddWithValue("@p6", txtImg.Text);
            command.Parameters.AddWithValue("@p7", mskPhone.Text);
            command.Parameters.AddWithValue("@p8", txtmail.Text);
            command.Parameters.AddWithValue("@p9", cbxGender.Text);
            command.Parameters.AddWithValue("@p10", cbxpoliclinic.Text);
            command.Parameters.AddWithValue("@p11", txtIns.Text);
            command.Parameters.AddWithValue("@p12", txtYoutube.Text);
            command.Parameters.AddWithValue("@p13", TxtTt.Text);
            command.ExecuteNonQuery();
            connection.Close();
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
//Data Source=DESKTOP-K8VM2MQ;Initial Catalog="Hospital automation";Integrated Security=True