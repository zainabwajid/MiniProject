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
    public partial class frmCloManagement : Form
    {
        SqlConnection con = new SqlConnection("Data Source = (local);Initial Catalog = ProjectB; Integrated Security = True;MultipleActiveResultSets = True");
        int ID = 0;
        public frmCloManagement()
        {
            InitializeComponent();
        }

        private void Clo_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectBDataSet1.Clo' table. You can move, or remove it, as needed.
            this.cloTableAdapter.Fill(this.projectBDataSet1.Clo);
            btnupdate.Hide();
            btndelete.Hide();

        }


        /// <summary>
        /// This function is for adding CLOs 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>



        private void btnadd_Click(object sender, EventArgs e)
        {
            if ( txtName.Text != "" )
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Clo (Name, DateCreated, DateUpdated) values(@name, @datecreated, @dateupdated)";
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@datecreated", DateTime.Now);
                cmd.Parameters.AddWithValue("@dateupdated", DateTime.Now);

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
        /// This function is to clear textboxes after CLOs data is added
        /// </summary>



        public void ClearTextbox()

        {
            txtName.Text = "";
            
        }


        /// <summary>
        /// This function is for displaying data in dataGridView
        /// </summary>


        public void DisplayData()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Clo";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dgvClo.DataSource = dt;
            con.Close();
        }

        /// <summary>
        /// This function is for displaying data in textboxes for updation or deletion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>



        private void dgvClo_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnupdate.Show();
            btndelete.Show();
            ID = Convert.ToInt32(dgvClo.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtName.Text = dgvClo.Rows[e.RowIndex].Cells[1].Value.ToString();
            btnadd.Hide();
        }



        /// <summary>
        /// This function is for updating CLOs data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update  Clo set Name=@name, DateUpdated=@dateupdated where ID=@id";
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
               // cmd.Parameters.AddWithValue("@datecreated", DateTime.Now);
                cmd.Parameters.AddWithValue("@dateupdated", DateTime.Now);

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


        /// <summary>
        /// This function is for deleting CLOs data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void btndelete_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from  Rubric where CloId=@cid";
                cmd.Parameters.AddWithValue("@cid", ID);
                cmd.ExecuteNonQuery();
                cmd.CommandText = "delete from  Clo where ID=@id";
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
           //   btnadd.Show();

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
    }
}
