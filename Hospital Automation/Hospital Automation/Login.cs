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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public static string test;
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-K8VM2MQ;Initial Catalog=Hospital automation;Integrated Security=True");
        SqlCommand command = new SqlCommand();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            command.Connection = connection;

            command.CommandText = "Select * From Admins where Pesel='" + txtPesel.Text + "' and Password='" + txtPassword.Text + "'";
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                if (String.Equals(cbxDepart.Text,"Admin"))
                {

                    this.Hide();
                    Admin a = new Admin();
                    a.ShowDialog();
                }
                if (String.Equals(cbxDepart.Text, "Doctor"))
                {
                    this.Hide();
                    Doctor d = new Doctor();
                    test = txtPesel.Text;
                    d.ShowDialog();
                }
                if (String.Equals(cbxDepart.Text, "Secretary"))
                {
                    this.Hide();
                    Secretary s = new Secretary();
                    s.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Check your information", "Info");
            }
            connection.Close();
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.Bisque;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.AntiqueWhite;
        }
    }
}
