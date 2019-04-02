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

namespace ProjectB
{
    public partial class frmAssessments : Form
    {
        SqlConnection con = new SqlConnection("Data Source = (local);Initial Catalog = ProjectB; Integrated Security = True;MultipleActiveResultSets = True");
        int id = 0;
        public frmAssessments()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// This function is for adding an Assessment data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if( txtTitle.Text != "" && txtTotalMarks.Text != "" && txtTotalWeightage.Text != "" )
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select count(Title) from Assessment where Title = @title";
                cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                int records = (int)cmd.ExecuteScalar();
                if (records == 0)
                {
                    cmd.CommandText = "insert into Assessment(Title, DateCreated, TotalMarks, TotalWeightage) values(@title, @dateCreated, @totalMarks, @totalWeightage) ";
                    // cmd.Parameters.AddWithValue("@title", txttitle.Text);
                    cmd.Parameters.AddWithValue("@dateCreated", DateTime.Now);
                    cmd.Parameters.AddWithValue("@totalMarks", txtTotalMarks.Text);
                    cmd.Parameters.AddWithValue("@totalWeightage", txtTotalWeightage.Text);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    DisplayData();
                    MessageBox.Show("Data Inserted Successfully");
                    ClearTextBox();
                }
                else
                {
                    MessageBox.Show("Data Already Exist!");
                    con.Close();

                }

            }
            else
            {
                MessageBox.Show("Please Enter name of Assessment!");
            }
        }

        /// <summary>
        /// This function is to clear textboxes after Student's data is added
        /// </summary>

        private void ClearTextBox()
        {
            txtTitle.Text = "";
            txtTotalMarks.Text = "";
            txtTotalWeightage.Text = "";

        }

        /// <summary>
        /// This function is for displaying data in dataGridView
        /// </summary>

        public void DisplayData()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Assessment";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgvAssessment.DataSource = dt;

            con.Close();
        }

        /// <summary>
        /// This function executes when the Assessments form is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void frmAssessments_Load(object sender, EventArgs e)
        {
            btnUpdate.Hide();
            btnDelete.Hide();
            // TODO: This line of code loads data into the 'projectBDataSet4.Assessment' table. You can move, or remove it, as needed.
            this.assessmentTableAdapter.Fill(this.projectBDataSet4.Assessment);

        }

        /// <summary>
        /// This function is for displaying data in textboxes for updation or deletion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void dgvassessment_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnUpdate.Show();
            btnDelete.Show();
            txtTitle.Text = dgvAssessment.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTotalMarks.Text = dgvAssessment.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtTotalWeightage.Text = dgvAssessment.Rows[e.RowIndex].Cells[3].Value.ToString();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Id from Assessment where Title ='" + txtTitle.Text + "' ";
            cmd.ExecuteNonQuery();
            id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            btnAdd.Hide();
        }

        /// <summary>
        /// This function is for updating Assessment's data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text != "" && txtTotalMarks.Text != "" && txtTotalWeightage.Text != "")
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
               // cmd.CommandText = "SELECT COUNT(Title) FROM Assessment WHERE Title = @title";
                cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                //int records = (int)cmd.ExecuteScalar();
                //if (records == 1)
                //{
                    cmd.CommandText = "update Assessment set Title = @title, TotalMarks = @totalMarks, TotalWeightage = @totalWeightage where Id=@id ";
                    cmd.Parameters.AddWithValue("@id", id);
                    //cmd.CommandText = "update Assessment set Title = @title, TotalMarks = @totalmarks, TotalWeightage = @totalweightage where Id=@id ";
                    //cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@totalMarks", txtTotalMarks.Text);
                    cmd.Parameters.AddWithValue("@totalWeightage", txtTotalWeightage.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    DisplayData();
                    MessageBox.Show("Data Updated Successfully");
                    ClearTextBox();
                    btnAdd.Show();
                    btnUpdate.Hide();
                    btnDelete.Hide();
               // }

              //  else
              //{
              //      MessageBox.Show("Record Already Exist!");
              //     con.Close();

                //}
            }
                
            
            else
            {
                MessageBox.Show("Select Data to Update");
            }
        }


        /// <summary>
        /// This function is for deleting Assessments's data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text != "" && txtTotalMarks.Text != "" && txtTotalWeightage.Text != "")
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Assessment where Id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayData();
                MessageBox.Show("Data Deleted Successfully!");
                ClearTextBox();
                btnAdd.Show();
                btnUpdate.Hide();
                btnDelete.Hide();
            }
            else
            {
                MessageBox.Show("Select data to Delete");
                btnAdd.Show();
            }
        }


        /// <summary>
        /// This function is to go to main page via linklabel 'Home'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLabManagement lm = new frmLabManagement();
            this.Hide();
            lm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
