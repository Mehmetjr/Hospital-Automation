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
using System.Diagnostics;

namespace Hospital_Automation
{
    public partial class Doctor : Form
    {
        public Doctor()
        {

            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-K8VM2MQ;Initial Catalog=Hospital automation;Integrated Security=True");

        private void btnDoctorApply_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("update  Appointment set TreatmentMethod=@p1,Medicines=@p2  where Pesel =@p3", connection);
            command.Parameters.AddWithValue("@p1", txtTreatment.Text);
            command.Parameters.AddWithValue("@p2", txtMedicines.Text);
            command.Parameters.AddWithValue("@p3", txtPatientPesel.Text);
            command.ExecuteNonQuery();
            connection.Close();
            this.appointmentTableAdapter.Fill(this.hospital_automationDataSet11.Appointment);
        }

        private void Doctor_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'hospital_automationDataSet11.Appointment' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.appointmentTableAdapter.Fill(this.hospital_automationDataSet11.Appointment);



        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void btnApprove_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("update Appointment set  Situation=@p1 where Pesel = @p2", connection);
            command.Parameters.AddWithValue("@p1", cbxSituation.Text);
            command.Parameters.AddWithValue("@p2", txtPatientPesel.Text);
            command.ExecuteNonQuery();
            connection.Close();
            this.appointmentTableAdapter.Fill(this.hospital_automationDataSet11.Appointment);
        }





        int choosen;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string pesel, appointment;
            choosen = dataGridView1.SelectedCells[0].RowIndex;
            pesel = dataGridView1.Rows[choosen].Cells[0].Value.ToString();
            appointment = dataGridView1.Rows[choosen].Cells[5].Value.ToString();
            txtPatientPesel.Text = pesel;
            comboBox1.Text = appointment;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("update Appointment set AppointmentTime =@p1 where Pesel =@p2", connection);
            command.Parameters.AddWithValue("@p1", comboBox1.Text);
            command.Parameters.AddWithValue("@p2", txtPatientPesel.Text);

            command.ExecuteNonQuery();
            connection.Close();
            this.appointmentTableAdapter.Fill(this.hospital_automationDataSet11.Appointment);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://twitter.com/dryyorukoglu");
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UC9YPf9TUU4B6VCvvTyJyJ5g");
        }

        private void linklabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.instagram.com/dryavuzyorukoglu/?hl=tr");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            connection.Open();
            SqlCommand command = new SqlCommand("delete from Appointment where Pesel =@p1", connection);
            command.Parameters.AddWithValue("@p1", txtPatientPesel.Text);
            command.ExecuteNonQuery();
            connection.Close();
            this.appointmentTableAdapter.Fill(this.hospital_automationDataSet11.Appointment);






        }

        private void btnDoctorApply_MouseEnter(object sender, EventArgs e)
        {
            btnDoctorApply.BackColor = Color.Bisque;
        }

        private void btnLogout_MouseEnter(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.Bisque;
        }

        private void btnLogout_MouseLeave(object sender, EventArgs e)
        {
            btnLogout.BackColor = Color.AntiqueWhite;
        }

        private void btnApprove_MouseEnter(object sender, EventArgs e)
        {
            btnApprove.BackColor = Color.Bisque;
        }

        private void btnApprove_MouseLeave(object sender, EventArgs e)
        {
            btnApprove.BackColor = Color.AntiqueWhite;
        }
        private void btnDelete_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.Bisque;
        }
        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackColor = Color.AntiqueWhite;
        }

        private void btnUpdate_MouseEnter(object sender, EventArgs e)
        {
            btnUpdate.BackColor = Color.Bisque;
        }

        private void btnUpdate_MouseLeave(object sender, EventArgs e)
        {
            btnUpdate.BackColor = Color.AntiqueWhite;
        }

        private void btnDoctorApply_MouseLeave(object sender, EventArgs e)
        {
            btnDoctorApply.BackColor = Color.AntiqueWhite;
        }
    }
}
