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
    public partial class EmployeeInfoUI : Form
    {
        public EmployeeInfoUI()
        {
            InitializeComponent();
            LoadAllDesignation();
        }

        DesignationManager designationManager = new DesignationManager();

        private EmployeeManager employeeManager = new EmployeeManager();

        private Designation aDesignation = new Designation();

        private int employeeId;

        private void addDesignatioButton_Click(object sender, EventArgs e)
        {
            DesignationUI designationUi = new DesignationUI();
            designationUi.Show();
            LoadAllDesignation();
            Designation lastAddedDesignation = designationUi.GetLastAddedDesignationThisUI();

            if (lastAddedDesignation != null)
            {
                designationComboBox.Text = lastAddedDesignation.Title;
            }

        }

        public void LoadAllDesignation()
        {
            designationComboBox.DataSource = designationManager.GetAllDesignations();
            designationComboBox.DisplayMember = "Title";
            designationComboBox.ValueMember = "Id";
        }

        private void saveEmployeeButton_Click(object sender, EventArgs e)
        {
            Employee employee=new Employee();
            employee.Name = nameTextBox.Text;
            employee.Email = emailTextBox.Text;
            employee.Address = addressTextBox.Text;
            employee.ADesignation = (Designation) designationComboBox.SelectedItem;

            if (saveEmployeeButton.Text != @"Update")
            {
                MessageBox.Show(employeeManager.Save(employee));

               
            }

            else
            {
                    MessageBox.Show(employeeManager.Update(employee));
          
                }
           
        }

        public void FillListBox(Employee employee)
        {
            nameTextBox.Text = employee.Name;
            emailTextBox.Text = employee.Email;
            addressTextBox.Text = employee.Address;
            designationComboBox.SelectedValue = employee.ADesignation.Id;

        }

        public void GetSelectedEmployee(Employee employee)
        {
            saveEmployeeButton.Text = @"Update";
            FillListBox(employee);
            employeeId=employee.Id;
        }

    }
}
