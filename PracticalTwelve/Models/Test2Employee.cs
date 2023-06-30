using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PracticalTwelve.Models
{
	public class Test2Employee
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		[DisplayName("Date of Birth")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime DOB { get; set; }
		public string MobileNumber { get; set; }
		public string Address { get; set; }
		public decimal Salary { get; set; }
	}
}