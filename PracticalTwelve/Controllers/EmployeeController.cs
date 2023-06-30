using PracticalTwelve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticalTwelve.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> employees = EmployeeAccessLayer.GetEmployees();

            return View(employees);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                bool IsAdded = EmployeeAccessLayer.AddEmployee(employee);
                if(IsAdded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
					return View();
				}
            }
            catch
            {
                return View();
            }
        }

        public ActionResult UpdateFName()
        {
            EmployeeAccessLayer.UpdateFirstEmployeeName();
            return RedirectToAction("Index");
        }
		public ActionResult UpdateMName()
		{
			EmployeeAccessLayer.UpdateMiddleEmployeeName();
			return RedirectToAction("Index");
		}
		public ActionResult Delete()
		{
			EmployeeAccessLayer.DeleteEmployee();
			return RedirectToAction("Index");
		}
		public ActionResult DeleteAllEmployee()
		{
			EmployeeAccessLayer.DeleteAllEmployee();
			return RedirectToAction("Index");
		}
		public ActionResult InsertEmployee()
		{
			EmployeeAccessLayer.InsertEmployeeData();
			return RedirectToAction("Index");
		}

	}
}
