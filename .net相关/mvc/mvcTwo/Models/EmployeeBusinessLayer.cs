using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcTwo.Models
{
    using mvcTwo.DataAccessLayer;
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {

            SalesERPDAL salesBO = new SalesERPDAL();
            return salesBO.Employees.ToList();
        }


        public Employee SaveEmployee(Employee e)
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.Employees.Add(e);
            salesDal.SaveChanges();
            return e;
        }

        public bool IsValidUser(UserDetails u)
        {
            if (u.UserName == "Admin" && u.Password == "Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public UserStatus GetUserValidity(UserDetails u)
        {
            if (u.UserName == "Admin" && u.Password == "Admin")
            {
                return UserStatus.AuthenticatedAdmin;
            }
            else if (u.UserName == "Sukesh" && u.Password == "Sukesh")
            {
                return UserStatus.AuthentucatedUser;
            }
            else
            {
                return UserStatus.NonAuthenticatedUser;
            }
        }

        public void UploadEmployees(List<Employee> employees)
        {
            SalesERPDAL saleBo = new SalesERPDAL();
            saleBo.Employees.AddRange(employees);

            saleBo.SaveChanges();
        }
    }
}