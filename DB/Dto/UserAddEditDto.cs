using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Dto
{
	public class UserAddEditDto
	{
		public string? Id { get; set; }

		[Required(ErrorMessage = "Podaj imię")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Podaj nazwisko")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Wybierz rolę")]
		[MinLength(1)]
		public string Role { get; set; }

		[Required(ErrorMessage = "Podaj email")]
		[EmailAddress]
		public string Email { get; set; }

		[Required(ErrorMessage = "Podaj hasło")]
		[DataType(DataType.Password)]
		[RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*\W).+$", ErrorMessage = "Hasło musi zawierać co najmniej jeden znak dużej litery, jedną cyfrę i jeden znak niealfanumeryczny.")]
		[MinLength(6, ErrorMessage = "Hasło powinno mieć długość co najmniej 6 znaków")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Powtórz hasło")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Podano dwa różne hasła")]
		public string ConfirmPassword { get; set; }
	}
}
