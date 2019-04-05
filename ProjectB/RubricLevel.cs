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
    public partial class frmRubricLevel : Form
    {
        SqlConnection con = new SqlConnection("Data Source = (local);Initial Catalog = ProjectB; Integrated Security = True;MultipleActiveResultSets = True");
        int Id = 0;

        public frmRubricLevel()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLabManagement lm = new frmLabManagement();
            this.Hide();
            lm.Show();
        }

        /// <summary>
        /// This function executes when RubricLevel form is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void frmRubricLevel_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectBDataSet7.RubricLevel' table. You can move, or remove it, as needed.
            this.rubricLevelTableAdapter.Fill(this.projectBDataSet7.RubricLevel);
            // TODO: This line of code loads data into the 'projectBDataSet6.Rubric' table. You can move, or remove it, as needed.
            this.rubricTableAdapter.Fill(this.projectBDataSet6.Rubric);

            btnUpdate.Hide();
            btnDelete.Hide();
            DisplayData();

        }

        /// <summary>
        /// This function is for adding RubricLevel data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnAdd_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into RubricLevel (RubricId, Details, MeasurementLevel) values(@RubricId, @Details, @MeasurementLevel)";
            cmd.Parameters.AddWithValue("@RubricId", cmbRubricId.Text);
            cmd.Parameters.AddWithValue("@Details", richTextBox1.Text);
            cmd.Parameters.AddWithValue("@MeasurementLevel", txtMeasurementLevel.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            DisplayData();
            ClearTextbox();
            MessageBox.Show("Data Saved Successfully!");
        }

        /// <summary>
        /// This function is to clear textboxes after RubricLevel data is added
        /// </summary>
        public void ClearTextbox()

        {
            txtMeasurementLevel.Text = "";
            richTextBox1.Text = "";
            cmbRubricId.Text = "";
        }

        /// <summary>
        /// This function is for displaying data in dataGridView
        /// </summary>

        public void DisplayData()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from RubricLevel";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgvRubricLevel.DataSource = dt;
            con.Close();
        }

        /// <summary>
        /// This function is for displaying data in textboxes for updation or deletion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void dgvRubricLevel_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnDelete.Show();
            btnUpdate.Show();
            Id = Convert.ToInt32(dgvRubricLevel.Rows[e.RowIndex].Cells[0].Value.ToString());
            cmbRubricId.Text = dgvRubricLevel.Rows[e.RowIndex].Cells[0].Value.ToString();
            richTextBox1.Text = dgvRubricLevel.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtMeasurementLevel.Text = dgvRubricLevel.Rows[e.RowIndex].Cells[2].Value.ToString();
            btnAdd.Hide();

        }

        /// <summary>
        /// This function is for updating RubricLevel data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if ( cmbRubricId.Text != "" && txtMeasurementLevel.Text != "" && richTextBox1.Text != "" )
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update RubricLevel set RubricId=@rubricId, Details=@details, MeasurementLevel=@measurementLevel where Id=@id";
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.Parameters.AddWithValue("@rubricId", cmbRubricId.Text);
                cmd.Parameters.AddWithValue("@details", richTextBox1.Text);
                cmd.Parameters.AddWithValue("@measurementLevel", txtMeasurementLevel.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayData();
                ClearTextbox();
                MessageBox.Show("Data Updated Successfully!");
                btnUpdate.Hide();
                btnDelete.Hide();
                btnAdd.Show();
            }
            else
            {

                MessageBox.Show("Enter the valid data in Text box");
            }



        
        }


        /// <summary>
        /// This function is for deleting RubricLevel data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cmbRubricId.Text != "" && txtMeasurementLevel.Text != "" && richTextBox1.Text != "")
            {

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from RubricLevel where Id=@id";
                cmd.Parameters.AddWithValue("@id", Id);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayData();
                ClearTextbox();
                MessageBox.Show("Data Deleted Successfully!");
                btnAdd.Show();
                btnDelete.Hide();
                btnUpdate.Hide();
            }
            else
            {
                MessageBox.Show("Enter the valid data in Text box");
            }
        }
    }
}
