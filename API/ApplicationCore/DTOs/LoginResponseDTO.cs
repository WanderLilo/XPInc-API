using API.ApplicationCore.Enums;
using System.ComponentModel.DataAnnotations;

namespace API.ApplicationCore.DTOs
{
    public class LoginResponseDTO
    {
        public string Email { get; set; }
        public string Perfil { get; set; }
        public string Token { get; set; }

    }
}
