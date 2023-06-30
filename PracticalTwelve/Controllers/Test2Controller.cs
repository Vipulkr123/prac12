using PracticalTwelve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticalTwelve.Controllers
{
    public class Test2Controller : Controller
    {
        // GET: Test2
        public ActionResult Index()
        {
            List<Test2Employee> test2Employees = Test2EmployeeAccessLayer.GetEmployees();
            return View(test2Employees);
        }
		// GET: Employee/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Employee/Create
		[HttpPost]
		public ActionResult Create(Test2Employee employee)
		{
			try
			{
				bool IsAdded = Test2EmployeeAccessLayer.AddEmployee(employee);
				if (IsAdded)
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

		public ActionResult GetEmployee()
		{
			List<Test2Employee> test2Employees = Test2EmployeeAccessLayer.GetEmployeesBasedOnAge();
			return View(test2Employees);
		}

		public ActionResult GetTotalEmployeeSalary()
		{
			decimal TotalSalary = Test2EmployeeAccessLayer.GetTotalSalary();
			TempData["TotalSalary"] = $"Total Salary : {TotalSalary}";
			return RedirectToAction("Index");
		}

		public ActionResult MiddleNameNullCount()
		{
			int Count = Test2EmployeeAccessLayer.GetMiddleNameNullCount();
			TempData["Count"] = $"Total {Count} Employee without middle name";
			return RedirectToAction("Index");
		}
		public ActionResult InsertEmployee()
		{
			Test2EmployeeAccessLayer.InsertEmployeeData();
			return RedirectToAction("Index");
		}
		public ActionResult DeleteAllEmployee()
		{
			Test2EmployeeAccessLayer.DeleteAllEmployees();
			return RedirectToAction("Index");
		}
	}
}