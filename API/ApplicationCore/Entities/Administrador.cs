using API.ApplicationCore.Enums;

namespace API.ApplicationCore.Entities
{
    public class Administrador
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Perfil Perfil { get; set; }
    }
}
