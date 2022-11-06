using System.ComponentModel;

namespace ProjectExamWebClient.ViewModels
{
    public class LoginViewModel
    {
        public string? Email { get; set; }
        [PasswordPropertyText]
        public string? Password { get; set; }
    }
}
