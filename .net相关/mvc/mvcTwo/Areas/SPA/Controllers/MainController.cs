using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using mvcTwo.ViewModels.SPA;
using OldViewModel = mvcTwo.ViewModels;
using mvcTwo.Models;

namespace mvcTwo.Areas.SPA.Controllers
{
    public class MainController : Controller
    {


        #region Index
        public ActionResult Index()
        {
            MainViewModel v = new MainViewModel();
            v.UserName = User.Identity.Name;
            v.FooterData = new OldViewModel.FooterViewModel();
            v.FooterData.CompanyName = "StepByStepSchools";//Can be set to dynamic value
            v.FooterData.Year = DateTime.Now.Year.ToString();

            return View("Index", v);
        }
        #endregion

        #region EmployeeList
        public ActionResult EmployeeList()
        {
            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();
            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            List<Employee> employees = empBal.GetEmployees();

            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();

            foreach (Employee emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.Value.ToString("C");
                if (emp.Salary > 15000)
                {
                    empViewModel.SalaryColor = "yellow";
                }
                else
                {
                    empViewModel.SalaryColor = "green";
                }
                empViewModels.Add(empViewModel);
            }
            employeeListViewModel.Employees = empViewModels;
            return View("EmployeeList", employeeListViewModel);
        }

        #endregion

        #region GetAddNewLink
        public ActionResult GetAddNewLink()
        {
            if (Convert.ToBoolean(Session["IsAdmin"]))
            {
                return PartialView("AddNewLink");
            }
            else
            {
                return new EmptyResult();
            }
        }
        #endregion

        #region AddNew
        public ActionResult AddNew()
        {
            CreateEmployeeViewModel ev = new CreateEmployeeViewModel();

            return PartialView("CreateEmployee", ev);
        } 
        #endregion

        #region SaveEmployee
        public ActionResult SaveEmployee(Employee emp)
        {
            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            empBal.SaveEmployee(emp);

            EmployeeViewModel empViewModel = new EmployeeViewModel();
            empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
            empViewModel.Salary = emp.Salary.Value.ToString("C");
            if (emp.Salary > 15000)
            {
                empViewModel.SalaryColor = "yellow";
            }
            else
            {
                empViewModel.SalaryColor = "green";
            }

            return Json(empViewModel);
        } 
        #endregion
    }
}