using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using EmployeeInfoDatabaseGroupStudy.DAL;
using EmployeeInfoDatabaseGroupStudy.Model;

namespace EmployeeInfoDatabaseGroupStudy.BLL
{
    class EmployeeManager
    {
        EmployeeGateway gateway=new EmployeeGateway();

        public List<Employee> GetAllEmployees()
        {
            return gateway.GetAllEmloyee();
        }

        public List<Employee> SearchByName(string SearchByNameText)
        {
            return gateway.SearchByName(SearchByNameText);

        }

        public string Save(Employee employee)
        {
            if (employee.Name==String.Empty)
            {
                return "Please enter the employee name.";
            }

            else if(employee.Email==string.Empty)
            {
                return "Please enter the Email name.";
            }

            else if (gateway.IsEmailExist(employee.Email))
            {
                return "Sorry! Your email name already exist.";
            }
            else if (employee.Address == string.Empty)
            {
                return "Please enter the Address name.";
            }

            else
            {
                if (gateway.Save(employee)>0)
                {
                    return "Insert successfully.";
                }
                else
                {
                    return "Saved Failed!";
                }
            }
        }

        public string Update(Employee employee)
        {

            if (employee.Name == String.Empty)
            {
                return "Please enter the employee name.";
            }

            else if (employee.Email == string.Empty)
            {
                return "Please enter the Email name.";
            }


            else if (employee.Address == string.Empty)
            {
                return "Please enter the Address name.";
            }

            else
            {
                if (gateway.Update(employee) > 0)
                {
                    return "Updated Succesfully.";
                    
                }
                else
                {
                    return "Update Failed.";
                }
            }
        }
    }
}
