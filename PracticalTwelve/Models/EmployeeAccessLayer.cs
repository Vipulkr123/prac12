using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace PracticalTwelve.Models
{
	public static class EmployeeAccessLayer
	{
		private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["EmployeeDbEntities"].ConnectionString;
		public static List<Employee> GetEmployees()
		{
			List<Employee> employees = new List<Employee>();
			using (SqlConnection conn = new SqlConnection(_connectionString))
			{
				string Query = "SELECT Id, FirstName, MiddleName, LastName, DOB, MobileNumber, Address FROM [PracThirteen].[dbo].[Employee]";
				SqlCommand cmd = new SqlCommand(Query, conn);
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					Employee emp = new Employee();
					emp.Id = Convert.ToInt32(reader.GetValue(0).ToString());
					emp.FirstName = reader.GetValue(1).ToString();
					emp.MiddleName = reader.GetValue(2).ToString();
					emp.LastName = reader.GetValue(3).ToString();
					emp.DOB = Convert.ToDateTime(reader.GetValue(4).ToString());
					emp.MobileNumber = reader.GetValue(5).ToString();
					emp.Address = reader.GetValue(6).ToString();
					employees.Add(emp);
				}
				return employees;
			}
		}

		public static bool AddEmployee(Employee employee)
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
						string AddStudent = $"INSERT INTO [PracThirteen].[dbo].[Employee] (FirstName, MiddleName, LastName, DOB, MobileNumber, Address) VALUES ('{employee.FirstName}', '{employee.MiddleName}', '{employee.LastName}', '{employee.DOB}', '{employee.MobileNumber}','{employee.Address}')";
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

		public static void UpdateFirstEmployeeName()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				try
				{
					connection.Open();
					string updateQuery = "UPDATE [PracThirteen].[dbo].[Employee] SET FirstName = @FirstName WHERE Id = (SELECT MIN(Id) FROM [PracThirteen].[dbo].[Employee])";
					SqlCommand command = new SqlCommand(updateQuery, connection);
					command.Parameters.AddWithValue("@FirstName", "SQLPerson");

					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					connection.Close();
				}
			}
		}
		public static void UpdateMiddleEmployeeName()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				try
				{
					connection.Open();
					string updateQuery = "UPDATE [PracThirteen].[dbo].[Employee] SET MiddleName = @MiddleName";
					SqlCommand command = new SqlCommand(updateQuery, connection);
					command.Parameters.AddWithValue("@MiddleName", "I");

					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					connection.Close();
				}
			}
		}
		public static void DeleteEmployee()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				try
				{
					connection.Open();
					string updateQuery = "DELETE FROM [PracThirteen].[dbo].[Employee] WHERE Id < 2";
					SqlCommand command = new SqlCommand(updateQuery, connection);

					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					connection.Close();
				}
			}
		}

		public static void DeleteAllEmployee()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				try
				{
					connection.Open();
					string updateQuery = "TRUNCATE TABLE [PracThirteen].[dbo].[Employee]";
					SqlCommand command = new SqlCommand(updateQuery, connection);

					command.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					connection.Close();
				}
			}
		}
		public static void InsertEmployeeData()
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				try
				{
					connection.Open();
					string updateQuery = "INSERT INTO Employee (FirstName, MiddleName, LastName, DOB, MobileNumber, Address) VALUES ('Vipul', 'Kumar', 'Upadhyay', '1999-07-07', '1234567890', 'Ahmedabad, Gujarat'),('Bhavin', 'Kumar', 'Kareliya', '2000-05-10', '9876543210', 'Rajkot, Gujarat'),('Jil', 'Kumar', 'Patel', '2001-09-15', '5555555555', 'Anand, Gujarat')";
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