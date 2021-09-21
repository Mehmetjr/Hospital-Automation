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
    public partial class TakeAppointment : Form
    {
        public TakeAppointment()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-K8VM2MQ;Initial Catalog=Hospital automation;Integrated Security=True");
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("insert into Appointment (Pesel ,DoctorName,Policlinic, Date,AppointmentTime) values (@p1,@p2,@p3,@p4,@p5)", connection);
            command.Parameters.AddWithValue("@p1", txtPesel.Text);
            command.Parameters.AddWithValue("@p2", cbxDoc.Text);
            command.Parameters.AddWithValue("@p3", comboBox1.Text);
            command.Parameters.AddWithValue("@p4", mskdate.Text);
            command.Parameters.AddWithValue("@p5", cbxAppoint.Text);
            command.ExecuteNonQuery();
            connection.Close();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
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

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.Bisque;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.AntiqueWhite;
        }
    }
}
