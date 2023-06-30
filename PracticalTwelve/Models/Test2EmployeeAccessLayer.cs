using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PracticalTwelve.Models
{
	public static class Test2EmployeeAccessLayer
	{
		private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["EmployeeDbEntities"].ConnectionString;

		public static List<Test2Employee> GetEmployees()
		{
			List<Test2Employee> employees = new List<Test2Employee>();
			using (SqlConnection conn = new SqlConnection(_connectionString))
			{
				string Query = "SELECT Id, FirstName, MiddleName, LastName, DOB, MobileNumber, Address, Salary FROM [PracThirteen].[dbo].[TestTwoEmployee]";
				SqlCommand cmd = new SqlCommand(Query, conn);
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					Test2Employee emp = new Test2Employee();
					emp.Id = Convert.ToInt32(reader.GetValue(0).ToString());
					emp.FirstName = reader.GetValue(1).ToString();
					emp.MiddleName = reader.GetValue(2).ToString();
					emp.LastName = reader.GetValue(3).ToString();
					emp.DOB = Convert.ToDateTime(reader.GetValue(4).ToString());
					emp.MobileNumber = reader.GetValue(5).ToString();
					emp.Address = reader.GetValue(6).ToString();
					emp.Salary = Convert.ToDecimal(reader.GetValue(7).ToString());
					employees.Add(emp);
				}
				return employees;
			}
		}

		public static bool AddEmployee(Test2Employee employee)
		{
			if (employee == null)
			{
				return false;
			}
			else
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					try
					{
						connection.Open();
						string AddStudent = $"INSERT INTO [PracThirteen].[dbo].[TestTwoEmployee] (FirstName, MiddleName, LastName, DOB, MobileNumber, Address, Salary) VALUES ('{employee.FirstName}', '{employee.MiddleName}', '{employee.LastName}', '{employee.DOB}', '{employee.MobileNumber}','{employee.Address}',{employee.Salary})";
						SqlCommand sqlCommand = new SqlCommand(AddStudent, connection);
						int RowAffected = sqlCommand.ExecuteNonQuery();
						if (RowAffected > 0)
						{
							return true;
						}
						else
						{
							return false;
						}
					}
					catch (Exception ex)
					{
						connection.Close();
						return false;
					}
				}
			}
		}

		public static List<Test2Employee> GetEmployeesBasedOnAge()
		{
			List<Test2Employee> employees = new List<Test2Employee>();
			using (SqlConnection conn = new SqlConnection(_connectionString))
			{
				string Query = "SELECT Id, FirstName, MiddleName, LastName, DOB, MobileNumber, Address, Salary FROM [PracThirteen].[dbo].[TestTwoEmployee] WHERE DOB > '01-01-2000'";
				SqlCommand cmd = new SqlCommand(Query, conn);
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					Test2Employee emp = new Test2Employee();
					emp.Id = Convert.ToInt32(reader.GetValue(0).ToString());
					emp.FirstName = reader.GetValue(1).ToString();
					emp.MiddleName = reader.GetValue(2).ToString();
					emp.LastName = reader.GetValue(3).ToString();
					emp.DOB = Convert.ToDateTime(reader.GetValue(4).ToString());
					emp.MobileNumber = reader.GetValue(5).ToString();
					emp.Address = reader.GetValue(6).ToString();
					emp.Salary = Convert.ToDecimal(reader.GetValue(7).ToString());
					employees.Add(emp);
				}
				return employees;
			}
		}

		public static decimal GetTotalSalary()
		{
			decimal total = 0;
			using (SqlConnection conn = new SqlConnection(_connectionString))
			{
				string query = "SELECT SUM(Salary) FROM [PracThirteen].[dbo].[TestTwoEmployee]";
				SqlCommand command = new SqlCommand(query, conn);
				conn.Open ();
				object result = command.ExecuteScalar();

				if (result != DBNull.Value)
				{
					total = Convert.ToDecimal(result);
				}
				return total;
			}
		}

		public static int GetMiddleNameNullCount()
		{
			int count = 0;
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				string query = "SELECT COUNT(*) FROM [PracThirteen].[dbo].[TestTwoEmployee] WHERE MiddleName IS NULL";
				SqlCommand command = new SqlCommand(query, connection);

				count = (int)command.ExecuteScalar();
				return count;
			}
		}
		public static void InsertEmployeeData()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				try
				{
					connection.Open();
					string updateQuery = "INSERT INTO [PracThirteen].[dbo].[TestTwoEmployee] (FirstName, MiddleName, LastName, DOB, MobileNumber, Address, Salary) VALUES  ('Vipul', 'Kumar', 'Upadhyay', '1999-07-07', '1234567890', 'Ahmedabad, Gujarat', 85000), ('Bhavin', 'Kumar', 'Kareliya', '2000-05-10', '9876543210', 'Rajkot, Gujarat', 25000),  ('Jil', 'Kumar', 'Patel', '1999-09-07', '5555555555', 'Anand, Gujarat',75000), ('Test1', NULL, 'test', '2001-09-15', '5555555555', 'Anand, Gujarat',65000), ('Test2', NULL, 'testing', '2002-07-15', '5555555555', 'Anand, Gujarat',25000)";
					SqlCommand command = new SqlCommand(updateQuery, connection);

					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					connection.Close();
				}
			}
		}
		public static void DeleteAllEmployees()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				try
				{
					connection.Open();
					string updateQuery = "TRUNCATE TABLE [PracThirteen].[dbo].[TestTwoEmployee]";
					SqlCommand command = new SqlCommand(updateQuery, connection);

					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					connection.Close();
				}
			}
		}
	}
}