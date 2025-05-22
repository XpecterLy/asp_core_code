using System.ComponentModel.DataAnnotations;

namespace TeamTask.Aplication.DTOs
{
    public class AuthUserRequest
    {
        [Required]
        [EmailAddress(ErrorMessage = "The email is not in a valid format.")]
        public string gmail { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$",
        ErrorMessage = "The password must be at least 8 characters long, including one uppercase letter, one lowercase letter, one number, and one special character.")]
        public string password { get; set; }
    }

    public class AuthUserResponse
    {
        public string token { get; set; }   
    }
}
