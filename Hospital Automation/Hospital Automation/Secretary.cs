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
    public partial class Secretary : Form
    {
        public Secretary()
        {
            InitializeComponent();
        }

        private void Secretary_Load(object sender, EventArgs e)
        {
            
            // TODO: Bu kod satırı 'hospital_automationDataSet9.Appointment' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.appointmentTableAdapter.Fill(this.hospital_automationDataSet9.Appointment);
            // TODO: Bu kod satırı 'hospital_automationDataSet8.SPatient' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.sPatientTableAdapter.Fill(this.hospital_automationDataSet8.SPatient);
        
          
          

        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-K8VM2MQ;Initial Catalog=Hospital automation;Integrated Security=True");

        private void btnDeleteApp_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("delete from Appointment where Pesel =@p1",connection);
            command.Parameters.AddWithValue("@p1", txtPessel1.Text);
            command.ExecuteNonQuery();
            connection.Close();
            this.appointmentTableAdapter.Fill(this.hospital_automationDataSet9.Appointment);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            connection.Open();
            SqlCommand command = new SqlCommand("delete from SPatient where Pesel =@p1", connection);
            command.Parameters.AddWithValue("@p1", txtPesel.Text);
            command.ExecuteNonQuery();
            connection.Close();
            this.sPatientTableAdapter.Fill(this.hospital_automationDataSet8.SPatient);
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            Payment p = new Payment();
            p.ShowDialog();
        }

        private void btnTakeApp_Click(object sender, EventArgs e)
        {
            TakeAppointment t = new TakeAppointment();
            t.ShowDialog();
        }

        private void btnAddPatience_Click(object sender, EventArgs e)
        {
            AddPatience a = new AddPatience();
                a.ShowDialog();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int choosen;
            string name,surname, address, pesel, phone, gender,mail;
            choosen = dataGridView1.SelectedCells[0].RowIndex;
            pesel = dataGridView1.Rows[choosen].Cells[0].Value.ToString();
            name = dataGridView1.Rows[choosen].Cells[1].Value.ToString();
            address = dataGridView1.Rows[choosen].Cells[3].Value.ToString();
            surname = dataGridView1.Rows[choosen].Cells[2].Value.ToString();
            phone = dataGridView1.Rows[choosen].Cells[6].Value.ToString();
            gender = dataGridView1.Rows[choosen].Cells[4].Value.ToString();
            
            mail = dataGridView1.Rows[choosen].Cells[5].Value.ToString();
            txtPesel.Text = pesel;
            txtName.Text = name;
            txtAddress.Text = address;
            txtPhone.Text = phone;
            cbxGender.Text = gender;
            txtSurname.Text = surname;
            
            txtMail.Text = mail;
            

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {




            connection.Open();
            SqlCommand command = new SqlCommand("update SPatient set Name =@p1 , Surname = @p2 , Gender = @p3 , Phone = @p4, Mail = @p5, Address = @p6 where Pesel =@p7", connection);
            command.Parameters.AddWithValue("@p1", txtName.Text);
            command.Parameters.AddWithValue("@p2", txtSurname.Text);
            command.Parameters.AddWithValue("@p3", cbxGender.Text);
            command.Parameters.AddWithValue("@p4", txtPhone.Text);
            command.Parameters.AddWithValue("@p5", txtMail.Text);
            command.Parameters.AddWithValue("@p6", txtAddress.Text);
            command.Parameters.AddWithValue("@p7", txtPesel.Text);
            command.ExecuteNonQuery();
            connection.Close();
            this.sPatientTableAdapter.Fill(this.hospital_automationDataSet8.SPatient);





        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("update Appointment set  Policlinic = @p1 , DoctorName = @p2 , Date = @p3, AppointmentTime = @p4 where Pesel =@p5", connection);
            command.Parameters.AddWithValue("@p1", comboBox3.Text);
            command.Parameters.AddWithValue("@p2", comboBox1.Text);
            command.Parameters.AddWithValue("@p3", mskdate.Text);
            command.Parameters.AddWithValue("@p4", cbxAppoint.Text);
            command.Parameters.AddWithValue("@p5", txtPessel1.Text);
            command.ExecuteNonQuery();
            connection.Close();
            this.appointmentTableAdapter.Fill(this.hospital_automationDataSet9.Appointment);

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int choosen1;
            string pesel, policlinic, doc, date, app;
            choosen1 = dataGridView2.SelectedCells[0].RowIndex;
            pesel = dataGridView2.Rows[choosen1].Cells[0].Value.ToString();
            policlinic = dataGridView2.Rows[choosen1].Cells[1].Value.ToString();
            doc = dataGridView2.Rows[choosen1].Cells[2].Value.ToString();
            date = dataGridView2.Rows[choosen1].Cells[7].Value.ToString();
            app = dataGridView2.Rows[choosen1].Cells[6].Value.ToString();
            
            txtPessel1.Text = pesel;
            comboBox3.Text = policlinic;
            comboBox1.Text = doc;
            mskdate.Text = date;
            cbxAppoint.Text = app;
            
        }

        private void btnUpdate_MouseEnter(object sender, EventArgs e)
        {
            btnUpdate.BackColor = Color.Bisque;
        }

        private void btnUpdate_MouseLeave(object sender, EventArgs e)
        {
            btnUpdate.BackColor = Color.AntiqueWhite;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.Bisque;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.AntiqueWhite;
        }
    }
}
