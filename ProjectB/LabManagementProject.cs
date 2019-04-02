using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectB
{
    public partial class frmLabManagement : Form
    {
        public frmLabManagement()
        {
            InitializeComponent();
        }


        /// <summary>
        /// This function is to go to StudentManagement form via linklabel 'Manage Students'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmStudentManagement sm = new frmStudentManagement();
            this.Hide();
            sm.Show();
        }

        /// <summary>
        /// This function is to go to CloManagement form via linklabel 'Manage CLOs'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCloManagement cm = new frmCloManagement();
            this.Hide();
            cm.Show();
        }

        /// <summary>
        /// This function is to go to CloManagement form via linklabel 'Manage Rubrics'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRubricsManagement rm = new frmRubricsManagement();
            this.Hide();
            rm.Show();

        }




        /// <summary>
        /// This function is to go to Assessments form via linklabel 'Manage Assessments'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAssessments a = new frmAssessments();
            this.Hide();
            a.Show();

        }

        /// <summary>
        /// This function is to go to RubricLevel form via linklabel 'Manage Rubric Levels'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRubricLevel rl = new frmRubricLevel();
            this.Hide();
            rl.Show();

        }

        /// <summary>
        /// This function is to go to Evaluation form via linklabel 'Mark Evaluation'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmEvaluation ev = new frmEvaluation();
            this.Hide();
            ev.Show();

        }

        private void frmLabManagement_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAttendance a = new frmAttendance();
            this.Hide();
            a.Show();
        }
    }
}
