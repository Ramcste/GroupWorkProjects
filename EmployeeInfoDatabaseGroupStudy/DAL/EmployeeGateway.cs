using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeInfoDatabaseGroupStudy.Model;

namespace EmployeeInfoDatabaseGroupStudy.DAL
{
    
    class EmployeeGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["EmployeeConnectionString"].ConnectionString;

        public int Save(Employee employee)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "INSERT INTO tbl_EmployeeInfo Values('"+employee.Name+"','"+employee.Email+"','"+employee.Address+"','"+employee.ADesignation.Id+"')";
       
            SqlCommand command=new SqlCommand(query,connection);
            connection.Open();

            int rowsEffected=command.ExecuteNonQuery();
            connection.Close();

            return rowsEffected;
        }

        public int Update(Employee employee)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "UPDATE tbl_EmployeeInfo SET Name='"+employee.Name+"',Email='"+employee.Email+"',Address='"+employee.Address+"',DesignationId='"+employee.ADesignation.Id+"'WHERE Email='"+employee.Email+"'";

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();

            int rowsEffected = command.ExecuteNonQuery();
            connection.Close();

            return rowsEffected;
        }
        public List<Employee> GetAllEmloyee()
        {
            SqlConnection connection=new SqlConnection(connectionString);

            string query = "SELECT * FROM tbl_EmployeeInfo ";
            SqlCommand command=new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<Employee>employeeList=new List<Employee>();
            
            while (reader.Read())
            {
                Employee employee=new Employee();
                employee.Id = int.Parse(reader["Id"].ToString());
                employee.Name = reader["Name"].ToString();
                employee.Email = reader["Email"].ToString();
                employee.Address = reader["Address"].ToString();
                employee.ADesignation.Id =int.Parse(reader["DesignationId"].ToString());
                employeeList.Add(employee);
            }
            reader.Close();
            connection.Close();
            return employeeList;
        }

        public bool IsEmailExist(string email)
        {
            bool isEmailExist = false;
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT Email FROM tbl_EmployeeInfo WHERE Email='"+email+"'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            
            while (reader.Read())
            {
                isEmailExist = true;
                break;

            }
            reader.Close();
            connection.Close();
            return isEmailExist;
        }


           public List<Employee> SearchByName(string name)
        {
            List<Employee> employees = new List<Employee>();

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT Name,Email FROM tbl_EmployeeInfo WHERE Name LIKE '"+name+"%' ORDER BY Name";

            SqlCommand command = new SqlCommand(query,connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            
            while (reader.Read())
            {
                Employee anEmployee=new Employee();
                
                anEmployee.Name = reader["Name"].ToString();
                anEmployee.Email = reader["Email"].ToString();
               
              
                employees.Add(anEmployee);

            }
               reader.Close();
               connection.Close();
            return employees;
        
        }
    }
    
}
