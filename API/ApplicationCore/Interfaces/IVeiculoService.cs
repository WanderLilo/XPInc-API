using API.ApplicationCore.DTOs;

namespace API.ApplicationCore.Interfaces
{
    public interface IVeiculoService
    {
        Task Adicionar(VeiculoDTO veiculoDTO);
        Task Atualizar(VeiculoDTO veiculoDTO);
        Task Remover(int id);
        Task<VeiculoDTO> ObterPorId(int id);
        Task<List<VeiculoDTO>> ObterTodos();
    }
}