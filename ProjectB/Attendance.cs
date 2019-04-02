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
    public partial class frmAttendance : Form
    {
        SqlConnection con = new SqlConnection("Data Source = (local);Initial Catalog = ProjectB; Integrated Security = True;MultipleActiveResultSets = True");

        public frmAttendance()
        {
            InitializeComponent();
            AutoFillComboBox();

        }

        private void Attendance_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectBDataSet5.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.projectBDataSet5.Student);

        }

        /// <summary>
        /// This function automatically fills comboBox with Category/Status value from Lookup table
        /// </summary>

        public void AutoFillComboBox()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Name from Lookup where Category='ATTENDANCE_STATUS'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cmbStatus.DisplayMember = "Name";
            cmbStatus.DataSource = dt;
            con.Close();
        }




        /// <summary>
        /// This function is to retrieve LookupID against status value 'Present' || 'Absent' || 'Leave' || 'Late'
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>




        public int ValueOfStatus(string s)
        {
            if (cmbStatus.Text == "Present")
            {

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select LookupId from Lookup where Name='Present'";
                cmd.ExecuteNonQuery();
                return (int)cmd.ExecuteScalar();


            }
            else if (cmbStatus.Text == "Absent")
            {

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select LookupId from Lookup where Name='Absent'";
                cmd.ExecuteNonQuery();
                return (int)cmd.ExecuteScalar();
            }
            else if (cmbStatus.Text == "Leave")
            {

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select LookupId from Lookup where Name='Leave'";
                cmd.ExecuteNonQuery();
                return (int)cmd.ExecuteScalar();
            }
            else
            {

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select LookupId from Lookup where Name='Late'";
                cmd.ExecuteNonQuery();
                return (int)cmd.ExecuteScalar();
            }

        }

        /// <summary>
        /// This function saves Attendance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnSave_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            SqlCommand cmd1 = con.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            SqlCommand cmd2 = con.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd.CommandText = "Insert into ClassAttendance (AttendanceDate) values(@attendanceDate)";
            cmd.Parameters.AddWithValue("@attendanceDate", dateTimePicker1.Value.ToString("mm/dd/yyyy"));
            cmd.CommandText = "Insert into StudentAttendance (AttendanceId, StudentId, AttendanceStatus) values(@attendanceId, @studentId, @attendanceStatus)";
            cmd2.CommandText = "Select Id from Student where RegistrationNumber = '" + cmbRegistrationNumber.Text + "'";
            cmd1.CommandText = "select Id from ClassAttendance where AttendanceDate = '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "'";
            cmd.Parameters.AddWithValue("@attendanceId", (int)cmd1.ExecuteScalar());
            cmd.Parameters.AddWithValue("@studentId", (int)cmd2.ExecuteScalar());
            cmd.Parameters.AddWithValue("@attendanceStatus", ValueOfStatus(cmbStatus.Text));
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Attendance Saved");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLabManagement lm = new frmLabManagement();
            this.Hide();
            lm.Show();
        }
    }
}
