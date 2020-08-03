using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApointmentApp.Models
{
	public class Student
	{
		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FirstMidName { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }
		public DateTime EnrollmentDate { get; set; }
		public ICollection<Enrollment> Enrollments { get; set; }
	}
}
