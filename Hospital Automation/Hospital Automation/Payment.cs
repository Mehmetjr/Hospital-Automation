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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-K8VM2MQ;Initial Catalog=Hospital automation;Integrated Security=True");

        private void btnPay_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("insert into Payment (CreditCardNo,CVC,Payment,PatientPesel) values (@p1,@p2,@p3,@p4)", connection);
            command.Parameters.AddWithValue("@p1", txtCard.Text);
            command.Parameters.AddWithValue("@p2", txtcvc.Text);
            command.Parameters.AddWithValue("@p3", cbxMethod.Text);
            command.Parameters.AddWithValue("@p4", TxtPesel.Text);
            command.ExecuteNonQuery();
            connection.Close();

            this.Close();
        }

        private void btnPay_MouseEnter(object sender, EventArgs e)
        {
            btnPay.BackColor = Color.Bisque;
        }

        private void btnPay_MouseLeave(object sender, EventArgs e)
        {
            btnPay.BackColor = Color.AntiqueWhite;
        }
    }
}
