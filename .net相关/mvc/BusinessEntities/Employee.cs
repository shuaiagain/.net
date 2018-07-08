using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace mvcTwo.Models
{
    public class Employee
    {

        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Enter First Name")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Salary { get; set; }

        public string UserName { get; set; }
    }
}