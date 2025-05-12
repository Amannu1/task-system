using System.Diagnostics.CodeAnalysis;

namespace TaskSystem.Models
{
    [ExcludeFromCodeCoverage]
    public class LoginModel
    {
        public string? Login {  get; set; }
        public string? Password { get; set; }
    }
}
