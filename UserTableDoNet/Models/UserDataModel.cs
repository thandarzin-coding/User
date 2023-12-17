using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserTableDoNet.Models
{
	[Table("Tbl_User")]
	public class UserDataModel
	{
		[Key]
		public int UserId { get; set; }

		public string UserName { get; set; }

		public int Age { get; set; }

		public string NRC { get; set; }

		public string Address { get; set; }

		public string MobileNo { get; set; }
	}
}
