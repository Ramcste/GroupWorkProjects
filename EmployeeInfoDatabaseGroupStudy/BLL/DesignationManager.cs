using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EmployeeInfoDatabaseGroupStudy.DAL;
using EmployeeInfoDatabaseGroupStudy.Model;

namespace EmployeeInfoDatabaseGroupStudy.BLL
{
    class DesignationManager
    {
        DesignationGateway gateway = new DesignationGateway();
        public string Save(Designation aDesignation)
        {
            if (aDesignation.Code == string.Empty)
            {
                return "Designation Code is missing";
            }

            else if (aDesignation.Title == string.Empty)
            {
                return " Designation Title is missing";
            }

            else if (gateway.IsDesignationCode(aDesignation.Code))
            {
                return "This Code Already Exists, Try Again!!";
            }


            else if (gateway.IsDesignationTitle(aDesignation.Title))
            {
                return "This Title Already Exists, Try Again!!";

            }



            else
            {

                int value = gateway.Save(aDesignation);

                if (value > 0)
                {

                    return "Saved successfully";
                }

                else
                {
                    return "Saved Failed.";
                }

            }
        }

        public List<Designation> GetAllDesignations()
        {

            return gateway.GetDesignation();
        } 
    }
}
