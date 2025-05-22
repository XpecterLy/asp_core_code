using System.ComponentModel.DataAnnotations;

namespace TeamTask.Aplication.DTOs
{
    public class UserDtos
    {
        [Required]
        [RegularExpression(@"^\d{6,10}$", ErrorMessage = "The NIT must have between 6 and 10 digits.")]
        public string nit { get; set; }
        [Required]
        [MinLength(4, ErrorMessage = "The username must be at least 4 characters.")]
        public string user_name { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "The name must have at least 2 characters.")]
        public string name { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "The email is not in a valid format.")]
        public string email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
        ErrorMessage = "The password must be at least 8 characters long, including one uppercase letter, one lowercase letter, one number, and one special character.")]
        public string password { get; set; }
    }

    public class UserResponse
    {
        [Required]
        public string nit { get; set; }
        [Required]
        public string user_name { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
    }
}
