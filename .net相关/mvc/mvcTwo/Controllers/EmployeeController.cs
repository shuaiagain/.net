using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcTwo.Models;
using mvcTwo.ViewModels;

using mvcTwo.Filters;

namespace mvcTwo.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Test
        #region Index
        //[Authorize]
        public ActionResult Index()
        {


            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();

            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            List<Employee> employees = empBal.GetEmployees();

            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();

            foreach (Employee emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.HasValue ? emp.Salary.Value : 0;
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

            //employeeListViewModel.UserName = "Admin";
            employeeListViewModel.UserName = User.Identity.Name;

            //footer 页脚
            employeeListViewModel.FooterData = new FooterViewModel();
            employeeListViewModel.FooterData.CompanyName = "StepByStepSchools";//Can be set to dynamic value
            employeeListViewModel.FooterData.Year = DateTime.Now.Year.ToString();

            return View("Index", employeeListViewModel);
        }
        #endregion

        #region AddNew
        public ActionResult AddNew()
        {
            return View("CreateEmployee", new CreateEmployeeViewModel());
        }
        #endregion

        #region SaveEmployee
        public ActionResult SaveEmployee(Employee em, string BtnSubmit)
        {

            switch (BtnSubmit)
            {
                case "Cancel":
                    return RedirectToAction("Index");
                case "SaveEmployee":

                    //if (!ModelState.IsValid) return View("CreateEmployee");
                    if (ModelState.IsValid)
                    {
                        EmployeeBusinessLayer emBO = new EmployeeBusinessLayer();
                        emBO.SaveEmployee(em);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        CreateEmployeeViewModel vm = new CreateEmployeeViewModel();

                        vm.FirstName = em.FirstName;
                        vm.LastName = em.LastName;
                        if (em.Salary.HasValue)
                        {

                            vm.Salary = em.Salary.ToString();
                        }
                        else
                        {
                            vm.Salary = ModelState["Salary"].Value.AttemptedValue;
                        }

                        return View("CreateEmployee", vm);
                    }
            }

            return new EmptyResult();
        }
        #endregion

        #region GetAddNewLink
        [AdminFilter]
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


        #region GetView
        public ActionResult GetView()
        {

            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();

            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            List<Employee> employees = empBal.GetEmployees();

            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();

            foreach (Employee emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.HasValue ? emp.Salary.Value : 0;
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
            //employeeListViewModel.UserName = "Admin";
            return View("MyView", employeeListViewModel);
        }
        #endregion

        #region Test
        public ActionResult Test()
        {

            EmployeeListViewModel emList = new EmployeeListViewModel();

            List<EmployeeViewModel> emViewList = new List<EmployeeViewModel>();
            emViewList.Add(new EmployeeViewModel()
            {
                UserName = "one",
            });

            emViewList.Add(new EmployeeViewModel()
            {
                UserName = "two",
            });

            emList.Employees = emViewList;

            //测试string的扩展功能
            ViewBag.Name = "12  \n \t \r3456".TrimBlank();
            return View(emList);
        }
        #endregion

        #region TestEmpty
        public ActionResult TestEmpty()
        {
            return View();
        }
        #endregion
    }
}