using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTableDoNet.Models;

namespace UserTableDoNet.DapperExamples
{
	public class DapperExample

	{
		//global using 
		SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
		{
			DataSource = ".",
			InitialCatalog = "UserDb",
			UserID = "sa",
			Password = "sa@123",
			TrustServerCertificate = true
		};

		public void Run()
		{

			Read();
			Edit(3);
			

			Create("Than", 25, "nmid(n)122","Hlaing","09782") ;
			Delete(13);
		    Delete(1);


		}
		public void Read()
		{
			using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
			{

				string query = @"
								SELECT [UserId]
									  ,[UserName]
									  ,[Age]
									  ,[NRC]
									  ,[Address]
									  ,[MobileNo]
								  FROM [dbo].[Tbl_User]";

				List<UserDataModel> lst = db.Query<UserDataModel>(query).ToList();
				foreach (var data in lst)
				{
					Console.WriteLine(data.UserId);
					Console.WriteLine(data.UserName);
					Console.WriteLine(data.NRC);
					Console.WriteLine(data.Address);

					Console.WriteLine("------------------------");

				}
			}


		}

		private void Create(string UserName, int Age, string NRC, string Address,string MobileNo)
		{
			using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
			{
				string query = @"INSERT INTO [dbo].[Tbl_User]
								   ([UserName]
								   ,[Age]
								   ,[NRC]
								   ,[Address]
								   ,[MobileNo])
							 VALUES
								   (@UserName
								   ,@Age
								   ,@NRC
								   ,@Address
								   ,@MobileNo)";
				UserDataModel userDataModel = new UserDataModel()
				{
					UserName = UserName,
					Age = Age,
					NRC = NRC,
					Address = Address,
					MobileNo = MobileNo


				};

				int resut = db.Execute(query, userDataModel);
				string message = resut > 0 ? "Save Successfully " : "Faild";
				Console.WriteLine(message);
			}
		}

		private void Edit(int Id)
		{
			using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
			{
				string query = @"SELECT [UserId]
									  ,[UserName]
									  ,[Age]
									  ,[NRC]
									  ,[Address]
									  ,[MobileNo]
								  FROM [dbo].[Tbl_User] where UserId = @UserId";
				UserDataModel? item = db.Query<UserDataModel>(query, new UserDataModel { UserId = Id }).FirstOrDefault();

				if (item is null)
				{
					Console.WriteLine("No  Data Found");
					return;
				}
				
				Console.WriteLine(item.UserName);
				Console.WriteLine(item.Age);
				Console.WriteLine(item.Address);
			}
		}

		private void Delete(int Id)
		{
			string query = @"DELETE FROM [dbo].[Tbl_User]
                             WHERE UserId = @UserId";

			UserDataModel userDataModel = new UserDataModel()
			{
				UserId = Id


			};

			using (IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
			{

				int resut = db.Execute(query, userDataModel);
				string message = resut > 0 ? "Delete Successfully " : "Faild";
				Console.WriteLine(message);
			}
		}

		
	}
}
