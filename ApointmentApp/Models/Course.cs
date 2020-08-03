using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApointmentApp.Models
{
	public class Course
	{
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int CourseID { get; set; }
		public string CourseTitle { get; set; }
		public decimal Fee { get; set; }
		public string Perequisites { get; set; }
		public int Duration { get; set; }
		public int Credits { get; set; }
		public ICollection<Enrollment> Enrollments { get; set; }
	}
}


