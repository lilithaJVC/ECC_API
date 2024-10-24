namespace ECC_API.Models
{
    public class LoginRequest
    {
        public int studentNum { get; set; }
        public string Firstname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
