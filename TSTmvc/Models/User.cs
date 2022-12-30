using System;
using System.ComponentModel.DataAnnotations;

namespace TSTmvc.Models
{
	public class User
	{
		[Required]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Email { get; set; }
		public string Phone { get; set; }
		public string City { get; set; }
		public DateOnly DateOfBirth { get; set; }
		public char Sex { get; set; }
		public string Address { get; set; }
		public string SignUpDate { get; set; }
		public int YearsTraded { get; set; }
	}
}

