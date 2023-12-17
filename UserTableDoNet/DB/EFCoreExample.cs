using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTableDoNet.Models;

namespace UserTableDoNet.DB
{
	public class EFCoreExample
	{
		private readonly AppDbContent _dbContext = new AppDbContent();

		public void Run()
		{
			Read();
			Create("Thandar", 25, "nrc1222", "hlaing", "9795999");
			
		}

		public void Read()
		{
			var lst = _dbContext.users.AsNoTracking().ToList();
			foreach (var data in lst)
			{
				Console.WriteLine(data.UserId);
				Console.WriteLine(data.UserName);
				Console.WriteLine(data.NRC);
				Console.WriteLine(data.Address);

				Console.WriteLine("------------------------");

			}


		}

		public void Create(string UserName, int Age, string NRC, string Address, string MobileNo)
		{


			UserDataModel userDataModel = new UserDataModel()
			{
				UserName = UserName,
				Age = Age,
				NRC = NRC,
				Address = Address,
				MobileNo = MobileNo


			};
			_dbContext.users.Add(userDataModel);
			int resut = _dbContext.SaveChanges();
			string message = resut > 0 ? "Save Successfully " : "Faild";
			Console.WriteLine(message);
		}

		public void Edit(int Id)
		{
			UserDataModel? item = _dbContext.users.FirstOrDefault(x => x.UserId == Id);
			if (item == null)
			{
				Console.WriteLine("No data found.");

			}
			Console.WriteLine(item.UserName);
			Console.WriteLine(item.Age);
			Console.WriteLine(item.Address);
		}

	


	}

}

