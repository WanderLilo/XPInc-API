using API.ApplicationCore.DTOs;
using API.ApplicationCore.Entities;
using API.ApplicationCore.Interfaces;
using API.Infrastructure.Data.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.ApplicationCore.Services
{
    public class VeiculoService : IVeiculoService
    {
        private VeiculoContext _contexto;
        private IMapper _mapper;

        public VeiculoService(VeiculoContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        public async Task Adicionar(VeiculoDTO veiculoDTO)
        {
            var veiculo = _mapper.Map<Veiculo>(veiculoDTO);

            await _contexto.Veiculos.AddAsync(veiculo);
            await _contexto.SaveChangesAsync();
        }

        public async Task Atualizar(VeiculoDTO veiculoDTO)
        {
            var veiculo = _mapper.Map<Veiculo>(veiculoDTO);

            _contexto.Veiculos.Update(veiculo);
            await _contexto.SaveChangesAsync();
        }

        public async Task Remover(int id)
        {
            var veiculo = await _contexto.Veiculos.FindAsync(id);
            if (veiculo == null) return;

            _contexto.Veiculos.Remove(veiculo);
            await _contexto.SaveChangesAsync();
        }

        public async Task<VeiculoDTO> ObterPorId(int id)
        {
            var veiculo = await _contexto.Veiculos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            var veiculoDTO = _mapper.Map<VeiculoDTO>(veiculo);
            return veiculoDTO;
        }

        public async Task<List<VeiculoDTO>> ObterTodos()
        {
            var veiculos = await _contexto.Veiculos.AsNoTracking().ToListAsync();

            var veiculosDTO = _mapper.Map<List<VeiculoDTO>>(veiculos);
            return veiculosDTO;
        }


    }
}
