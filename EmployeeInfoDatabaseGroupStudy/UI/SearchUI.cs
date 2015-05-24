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
    public partial class SearchByNameUI : Form
    {

        EmployeeManager manager=new EmployeeManager();
        public SearchByNameUI()
        {
            InitializeComponent();
        }

        private void SearchByNameUI_Load(object sender, EventArgs e)
        {
            LoadAllEmployeeListView(manager.GetAllEmployees());
        }

        public void LoadAllEmployeeListView(List<Employee> employees)
        {
            int serial = 1;
            resultListView.Items.Clear();
            foreach (var employee in employees)
            {
                
                ListViewItem item = new ListViewItem(serial.ToString());
                item.Tag = (Employee) employee;
                item.SubItems.Add(employee.Name);
                item.SubItems.Add(employee.Email);
                resultListView.Items.Add(item);
                serial++;

            }
            
        }

        private void SearchByNameButton_Click(object sender, EventArgs e)
        {
            List<Employee> employees = new List<Employee>();
            string SearchByNameText = SearchByNameTextBox.Text;
            employees = manager.SearchByName(SearchByNameText);
            LoadAllEmployeeListView(employees);
        }

      

        private void resultListView_DoubleClick(object sender, EventArgs e)
        {
            Employee selectedEmployee = GetSelectedEmployee();

            EmployeeInfoUI employeeInfoUi=new EmployeeInfoUI();
            employeeInfoUi.GetSelectedEmployee(selectedEmployee);
            employeeInfoUi.Show();
            this.Close();

        }

        public Employee GetSelectedEmployee()
        {
            int index = resultListView.SelectedIndices[0];
            ListViewItem item = resultListView.Items[index];
            return (Employee) item.Tag;
        }
       
    }
}
