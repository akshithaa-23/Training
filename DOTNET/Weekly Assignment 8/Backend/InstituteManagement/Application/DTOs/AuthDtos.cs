using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AuthDtos
    {
        public record RegisterDto(string FullName, string Email, string Password, string Role);
        public record LoginDto(string Email, string Password);
        public record AuthResultDto(string Token, string FullName, string Email, string Role);
    }
}
