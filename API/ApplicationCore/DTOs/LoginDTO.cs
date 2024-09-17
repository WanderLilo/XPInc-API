using System.ComponentModel.DataAnnotations;

namespace API.ApplicationCore.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(255, ErrorMessage = "Campo {0} deve ter no maximo {1} caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "Campo {0} deve ter no maximo {1} caracteres")]
        public string Senha { get; set; }

    }
}
