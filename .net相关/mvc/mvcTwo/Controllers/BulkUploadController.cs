using mvcTwo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;
using mvcTwo.ViewModels;
using mvcTwo.Filters;
using System.Threading.Tasks;
using System.Threading;

namespace mvcTwo.Controllers
{
    //public class BulkUploadController : Controller
    public class BulkUploadController : AsyncController
    {

        [HeaderFooterFilter]
        public ActionResult Index()
        {
            return View(new FileUploadViewModel());
        }

        #region Upload

        [HandleError]
        public async Task<ActionResult> Upload(FileUploadViewModel model)
        {

            int t2 = Thread.CurrentThread.ManagedThreadId;
            List<Employee> employees = await Task.Factory.StartNew<List<Employee>>(() => GetEmployees(model));

            int t3 = Thread.CurrentThread.ManagedThreadId;
            EmployeeBusinessLayer emBL = new EmployeeBusinessLayer();

            emBL.UploadEmployees(employees);

            return RedirectToAction("Index", "Employee");
        }
        #endregion


        #region Upload
        //public ActionResult Upload(FileUploadViewModel model)
        //{

        //    List<Employee> employees = GetEmployees(model);
        //    EmployeeBusinessLayer emBo = new EmployeeBusinessLayer();

        //    emBo.UploadEmployees(employees);

        //    return RedirectToAction("Index", "Employee");
        //}
        #endregion

        #region GetEmployees
        public List<Employee> GetEmployees(FileUploadViewModel model)
        {

            List<Employee> employees = new List<Employee>();

            StreamReader csvReader = new StreamReader(model.fileUpload.InputStream);
            csvReader.ReadLine();

            while (!csvReader.EndOfStream)
            {

                var line = csvReader.ReadLine();
                var values = line.Split(',');
                Employee em = new Employee();
                em.FirstName = values[0];
                em.LastName = values[1];
                em.Salary = int.Parse(values[2]);

                employees.Add(em);
            }

            return employees;
        }
        #endregion

    }
}