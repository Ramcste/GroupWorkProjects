using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeInfoDatabaseGroupStudy.BLL;
using EmployeeInfoDatabaseGroupStudy.Model;

namespace EmployeeInfoDatabaseGroupStudy
{
    public partial class DesignationUI : Form
    {
        public DesignationUI()
        {
            InitializeComponent();
        }

        DesignationManager designationManager=new DesignationManager();
        Designation aDesignation = new Designation();
        private void saveDesignationButton_Click(object sender, EventArgs e)
        {
            

            aDesignation.Code = codeTextBox.Text;
            aDesignation.Title = titleTextBox.Text;

            MessageBox.Show(designationManager.Save(aDesignation));
            this.Close();
            
        }
        private void GetTextBoxesClear()
        {
            codeTextBox.Text = "";
            titleTextBox.Text = "";
        }

        public  Designation GetLastAddedDesignationThisUI()
        {
            return aDesignation;
        }
    }
}
