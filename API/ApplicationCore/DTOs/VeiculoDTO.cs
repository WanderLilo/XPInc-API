using System.ComponentModel.DataAnnotations;

namespace API.ApplicationCore.DTOs
{
    public class VeiculoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(150, ErrorMessage = "Campo {0} deve ter no maximo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "Campo {0} deve ter no maximo {1} caracteres")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório")]
        public int Ano { get; set; }

    }
}
