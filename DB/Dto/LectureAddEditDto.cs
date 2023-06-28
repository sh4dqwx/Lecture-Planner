using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Dto
{
	public class LectureAddEditDto
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Podaj temat")]
		public string Topic { get; set; }

		[Required(ErrorMessage = "Podaj datę")]
		[Range(typeof(DateOnly), "1950-01-01", "2099-01-01", ErrorMessage = "Niepoprawna data")]
		[DataType(DataType.Date)]
		public DateOnly Date { get; set; }

		[Required]
		[Range(typeof(TimeOnly), "08:00", "15:00", ErrorMessage = "Niepoprawna godzina początkowa")]
		[DataType(DataType.Time)]
		public TimeOnly StartHour { get; set; }

		[Required]
		[Range(typeof(TimeOnly), "08:30", "15:30", ErrorMessage = "Niepoprawna godzina końcowa")]
		[DataType(DataType.Time)]
		public TimeOnly EndHour { get; set; }

		[Required]
		[Range(1, int.MaxValue, ErrorMessage = "Wybierz salę")]
		public int HallId { get; set; }

		public string? LecturerId { get; set; }
	}
}
