﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectB
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
              Application.Run(new frmLabManagement());
            // Application.Run(new frmStudentManagement());
            //Application.Run(new frmCloManagement());
            //Application.Run(new frmRubricsManagement());
            // Application.Run(new frmAssessments());
            // Application.Run(new frmAttendance());
            //   Application.Run(new frmRubricLevel());

        }
    }
}
