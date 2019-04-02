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
using System.Text.RegularExpressions;

namespace ProjectB
{
    public partial class frmStudentManagement : Form
    {
        /// <summary>
        /// SQL Connection
        /// </summary>
        /// 


        SqlConnection con = new SqlConnection("Data Source = (local);Initial Catalog = ProjectB; Integrated Security = True;MultipleActiveResultSets = True");
        int ID = 0;
        public frmStudentManagement()
        {
            InitializeComponent();
        }

        
        /// <summary>
        /// This function executes when the Student form is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Form1_Load(object sender, EventArgs e)
        {
            btnupdate.Hide();
            btndelete.Hide();
            AutoFillComboBox();
            DisplayData();
        }


        /// <summary>
        /// This function is for adding Student data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidData() && txtFirstName.Text != "" && txtLastName.Text != "" && txtContact.Text != "" && txtContact.Text != "" && txtEmail.Text != "" && txtRegisteration.Text != "" && cmbStatus.Text != "")
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Student (FirstName, LastName, Contact, Email, RegistrationNumber, Status) values(@firstname, @lastname, @contact, @email, @registrationnumber, @status)";
                cmd.Parameters.AddWithValue("@firstname", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@lastname", txtLastName.Text);
                cmd.Parameters.AddWithValue("@contact", txtContact.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@registrationnumber", txtRegisteration.Text);
                cmd.Parameters.AddWithValue("@status", ValueOfStatus(cmbStatus.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayData();
                ClearTextbox();
                MessageBox.Show("Data Saved Successfully!");
            }
            else
            {

                MessageBox.Show("Enter the valid data in Text box");
            }


        }

        /// <summary>
        /// This function is to clear textboxes after Student's data is added
        /// </summary>

        public void ClearTextbox()

        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtContact.Text = "";
            txtContact.Text = "";
            txtEmail.Text = "";
            txtRegisteration.Text = "";
            cmbStatus.Text = "";
        }


        /// <summary>
        /// This function is for displaying data in dataGridView
        /// </summary>
  
        public void DisplayData()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from student";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgvStudent.DataSource = dt;
            con.Close();
        }

        /// <summary>
        /// This function is for displaying data in textboxes for updation or deletion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>



        private void dgvStudent_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btndelete.Show();
            btnupdate.Show();
            ID = Convert.ToInt32(dgvStudent.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtFirstName.Text = dgvStudent.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtLastName.Text = dgvStudent.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtContact.Text = dgvStudent.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtEmail.Text = dgvStudent.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtRegisteration.Text = dgvStudent.Rows[e.RowIndex].Cells[5].Value.ToString();
            cmbStatus.Text = dgvStudent.Rows[e.RowIndex].Cells[6].Value.ToString();
            btnadd.Hide();
        }


        /// <summary>
        /// This function is for updating Student's data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidData() && txtFirstName.Text != "" && txtLastName.Text != "" && txtContact.Text != "" && txtContact.Text != "" && txtEmail.Text != "" && txtRegisteration.Text != "" && cmbStatus.Text != "")
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update student set FirstName=@firstname, LastName=@lastname, Contact=@contact, Email=@email, RegistrationNumber=@registrationnumber, Status=@status where ID=@id";
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@firstname", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@lastname", txtLastName.Text);
                cmd.Parameters.AddWithValue("@contact", txtContact.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@registrationnumber", txtRegisteration.Text);
                cmd.Parameters.AddWithValue("@status", ValueOfStatus(cmbStatus.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayData();
                ClearTextbox();
                MessageBox.Show("Data Updated Successfully!");
                btnupdate.Hide();
                btndelete.Hide();
                btnadd.Show();
            }
            else
            {

                MessageBox.Show("Enter the valid data in Text box");
            }


        }


        /// <summary>
        /// This function is for deleting Student's data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void button3_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text != "" && txtLastName.Text != "" && txtContact.Text != "" && txtContact.Text != "" && txtEmail.Text != "" && txtRegisteration.Text != "" && cmbStatus.Text != "")
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from student where ID=@id";
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayData();
                ClearTextbox();
                MessageBox.Show("Data Deleted Successfully!");
                btnadd.Show();
                btndelete.Hide();
                btnupdate.Hide();
            }
            else
            {

                MessageBox.Show("Enter the valid data in Text box");
            }
        }


        /// <summary>
        /// This function automatically fills comboBox with Category/Status value from Lookup table
        /// </summary>

        public void AutoFillComboBox()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Name from Lookup where Category = 'STUDENT_STATUS'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cmbStatus.DisplayMember = "Name";
            cmbStatus.DataSource = dt;
            con.Close();

        }



        /// <summary>
        /// This function is to retrieve LookupID against status value 'Active' or 'InActive
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>



        public int ValueOfStatus(string v)
        {
            if (cmbStatus.Text == "Active")
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " select LookupId from Lookup where Name = 'Active'";
                cmd.ExecuteNonQuery();
                return (int)cmd.ExecuteScalar();

            }

            else
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " select LookupId from Lookup where Name = 'InActive'";
                cmd.ExecuteNonQuery();
                return (int)cmd.ExecuteScalar();

            }
        }





        /// <summary>
        /// This is validation function for FirstName
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>





        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtFirstName.Text, @"^[A-Z][a-zA-Z]*$"))
            {
                errorProvider1.Clear();

            }
            else
            {
                errorProvider1.SetError(txtFirstName, "Only use alphabets & Use first letter Capital");
                return;
            }

        }

        /// <summary>
        /// This is validation function for LastName 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>



        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtLastName.Text, @"^[A-Z][a-zA-Z]*$"))
            {
                errorProvider2.Clear();

            }
            else
            {
                errorProvider2.SetError(txtLastName, "Only use alphabets & Use first letter Capital");
                return;
            }

        }



        /// <summary>
        /// This is validation function for Contact
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>



        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtContact.Text, @"^(\+)?([9]{1}[2]{1})?-? ?(\()?([0]{1})?[1-9]{2,4}(\))?-? ??(\()?[1-9]{4,7}(\))?$"))
            {
                errorProvider4.Clear();

            }
            else
            {
                errorProvider4.SetError(txtContact, "Enter Valid phone Number. Use that Format +92 321 7469854 | 923217469857 | 041 2680226");
                return;
            }
        }


        /// <summary>
        /// This is validation function for Email
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
         



        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            string pattren = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                             @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                             @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            if (Regex.IsMatch(txtEmail.Text, pattren))
            {
                errorProvider3.Clear();
            }
            else
            {
                errorProvider3.SetError(this.txtEmail, "Enter the Email address in correct format");
                return;
            }
        }



        /// <summary>
        /// This is validation function for Registeration Number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>



        private void txtRegisteration_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtRegisteration.Text, @"^(\d{4}-[A-Z|a-z]{2}-\d{1,4})?$"))
            {
                errorProvider5.Clear();

            }
            else
            {
                errorProvider5.SetError(txtRegisteration, "Enter Valid Registration Number. Use that Format 2016-CS-176");
                return;

            }
        }


        /// <summary>
        /// This function checks foreach errorProvider if the data is valid or not
        /// </summary>
        /// <returns>bool</returns>

        public bool ValidData()
        {
            foreach (Control c in this.Controls)
            {
                if (errorProvider1.GetError(c).Length > 0)
                {
                    return false;
                }
                else if (errorProvider2.GetError(c).Length > 0)
                {
                    return false;
                }
                else if (errorProvider3.GetError(c).Length > 0)
                {
                    return false;
                }
                else if (errorProvider4.GetError(c).Length > 0)
                {
                    return false;
                }
                else if (errorProvider5.GetError(c).Length > 0)
                {
                    return false;
                }

            }

            return true;
        }


        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLabManagement lm = new frmLabManagement();
            this.Hide();
            lm.Show();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }



    }
}
