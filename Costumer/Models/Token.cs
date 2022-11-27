namespace Customer.Models
{
    public class Token
    {
        public string JwtToken { get; set; }
        public int ExpiresIn { get; set; }
    }
}
