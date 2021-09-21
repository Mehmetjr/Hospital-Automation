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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-K8VM2MQ;Initial Catalog=Hospital automation;Integrated Security=True");
        private void Admin_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'hospital_automationDataSet1.Admins' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.adminsTableAdapter.Fill(this.hospital_automationDataSet1.Admins);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("update Admins set Name =@p1 , Surname = @p2 , Password = @p3 , Policlinic = @p4, Department = @p5 where Pesel =@p6", connection);
            command.Parameters.AddWithValue("@p1", txtName.Text);
            command.Parameters.AddWithValue("@p2", txtSurname.Text);
            command.Parameters.AddWithValue("@p3", txtPassword.Text);
            command.Parameters.AddWithValue("@p4", comboBox1.Text);
            command.Parameters.AddWithValue("@p5", textBox1.Text);
            command.Parameters.AddWithValue("@p6", txtPesel.Text);
            command.ExecuteNonQuery();
            connection.Close();
            this.adminsTableAdapter.Fill(this.hospital_automationDataSet1.Admins);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddUser a = new AddUser();
            a.ShowDialog();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("delete from Admins where Pesel =@p1", connection);
            command.Parameters.AddWithValue("@p1", txtPesel.Text);
            command.ExecuteNonQuery();
            connection.Close();
            this.adminsTableAdapter.Fill(this.hospital_automationDataSet1.Admins);
        }
        int choosen;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name, surname, pesel, password, policlinic,department;
            choosen = dataGridView1.SelectedCells[0].RowIndex;
            pesel = dataGridView1.Rows[choosen].Cells[0].Value.ToString();
            name = dataGridView1.Rows[choosen].Cells[1].Value.ToString();
            surname = dataGridView1.Rows[choosen].Cells[2].Value.ToString();
            password = dataGridView1.Rows[choosen].Cells[3].Value.ToString();
            policlinic = dataGridView1.Rows[choosen].Cells[5].Value.ToString();
            department = dataGridView1.Rows[choosen].Cells[4].Value.ToString();
            txtPesel.Text = pesel;
            txtName.Text = name;
            txtSurname.Text = surname;
            txtPassword.Text = password;
            textBox1.Text = department;
            comboBox1.Text = policlinic;
            

        }

        private void btnAdd_MouseEnter(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.Bisque;
        }

        private void btnAdd_MouseLeave(object sender, EventArgs e)
        {
            btnAdd.BackColor = Color.AntiqueWhite;
        }

        private void btnOut_MouseEnter(object sender, EventArgs e)
        {
            btnOut.BackColor = Color.Bisque;
        }

        private void btnOut_MouseLeave(object sender, EventArgs e)
        {
            btnOut.BackColor = Color.AntiqueWhite;
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
    }
}
