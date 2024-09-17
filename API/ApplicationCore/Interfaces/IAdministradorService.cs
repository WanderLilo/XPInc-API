using API.ApplicationCore.DTOs;
using API.ApplicationCore.Entities;

namespace API.ApplicationCore.Interfaces
{
    public interface IAdministradorService
    {
        Task<AdministradorDTO?> Login(LoginDTO loginDTO);
        Task Adicionar(AdministradorDTO veiculoDTO);
        Task Atualizar(AdministradorDTO veiculoDTO);
        Task Remover(int id);
        Task<AdministradorDTO> ObterPorId(int id);
        Task<List<AdministradorDTO>> ObterTodos();

    }
}