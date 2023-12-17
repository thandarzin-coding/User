using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTableDoNet.Models;

namespace UserTableDoNet.DB
{
	public class AppDbContent : DbContext
    {
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
			{
				DataSource = ".",
				InitialCatalog = "UserDb",
				UserID = "sa",
				Password = "sa@123",
				TrustServerCertificate = true
			};

			optionsBuilder.UseSqlServer(_sqlConnectionStringBuilder.ConnectionString);
		}

	     public	DbSet<UserDataModel> users {  get; set; }	

	}
}
