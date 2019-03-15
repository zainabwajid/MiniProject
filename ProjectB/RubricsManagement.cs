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
    public partial class frmRubricsManagement : Form
    {
        SqlConnection con = new SqlConnection("Data Source = (local);Initial Catalog = ProjectB; Integrated Security = True;MultipleActiveResultSets = True");
        int ID = 0;
        public frmRubricsManagement()
        {
            InitializeComponent();
        }

        private void Rubrics_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectBDataSet3.Rubric' table. You can move, or remove it, as needed.
            this.rubricTableAdapter.Fill(this.projectBDataSet3.Rubric);
            // TODO: This line of code loads data into the 'projectBDataSet2.Clo' table. You can move, or remove it, as needed.
            this.cloTableAdapter.Fill(this.projectBDataSet2.Clo);
            btnupdate.Hide();
            btndelete.Hide();

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" && richTextBox1.Text != "" && cmbClo.Text != "")
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Rubric (Id, Details, CloId) values(@id, @details, @cloid)";
                cmd.Parameters.AddWithValue("@id", txtID.Text);
                cmd.Parameters.AddWithValue("@details", richTextBox1.Text);
                cmd.Parameters.AddWithValue("@cloid", cmbClo.Text);

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

        public void ClearTextbox()

        {
            txtID.Text = "";
            richTextBox1.Text = "";


        }
        public void DisplayData()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Rubric";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgvRubrics.DataSource = dt;
            con.Close();
        }

        private void dgvRubrics_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btndelete.Show();
            btnupdate.Show();
            ID = Convert.ToInt32(dgvRubrics.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtID.Text = dgvRubrics.Rows[e.RowIndex].Cells[0].Value.ToString();
            richTextBox1.Text = dgvRubrics.Rows[e.RowIndex].Cells[1].Value.ToString();
            cmbClo.Text = dgvRubrics.Rows[e.RowIndex].Cells[2].Value.ToString();
            btnadd.Hide();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" && richTextBox1.Text != "" && cmbClo.Text != "")
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update  Rubric set Id=@rid, Details=@details, CloId=@cloid where ID=@id";
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@rid", txtID.Text);
                cmd.Parameters.AddWithValue("@details", richTextBox1.Text);
                cmd.Parameters.AddWithValue("@cloid", cmbClo.Text);

                cmd.ExecuteNonQuery();
                con.Close();
                DisplayData();
                ClearTextbox();
                MessageBox.Show("Data Saved Successfully!");
                btnupdate.Hide();
                btndelete.Hide();
                btnadd.Show();
            }
            else
            {

                MessageBox.Show("Enter the valid data in Text box");

            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "" && richTextBox1.Text != "" && cmbClo.Text != "")
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from  Rubric where ID=@id";
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayData();
                ClearTextbox();
                MessageBox.Show("Data Deleted Successfully!");
                btnupdate.Hide();
                btndelete.Hide();
                btnadd.Show();
            }
            else
            {

                MessageBox.Show("Enter the valid data in Text box");
          //    btnadd.Show();

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLabManagement lm = new frmLabManagement();
            this.Hide();
            lm.Show();
        }
    }
}
