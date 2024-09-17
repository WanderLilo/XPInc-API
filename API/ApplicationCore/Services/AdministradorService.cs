using API.ApplicationCore.DTOs;
using API.ApplicationCore.Entities;
using API.ApplicationCore.Interfaces;
using API.Infrastructure.Data.Context;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.ApplicationCore.Services
{
    public class AdministradorService : IAdministradorService
    {
        private VeiculoContext _contexto;
        private IMapper _mapper;

        public AdministradorService(VeiculoContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        public async Task<AdministradorDTO?> Login(LoginDTO loginDTO)
        {
            var administrador = await _contexto.Administradores.FirstOrDefaultAsync(p => p.Email == loginDTO.Email && p.Senha == loginDTO.Senha);

            var administradorDTO = _mapper.Map<AdministradorDTO>(administrador);

            return administradorDTO;
        }

        public async Task Adicionar(AdministradorDTO administradorDTO)
        {
            var administrador = _mapper.Map<Administrador>(administradorDTO);

            await _contexto.Administradores.AddAsync(administrador);
            await _contexto.SaveChangesAsync();
        }

        public async Task Atualizar(AdministradorDTO administradorDTO)
        {
            var administrador = _mapper.Map<Administrador>(administradorDTO);

            _contexto.Administradores.Update(administrador);
            await _contexto.SaveChangesAsync();
        }

        public async Task Remover(int id)
        {
            var administrador = await _contexto.Administradores.FindAsync(id);
            if (administrador == null) return;

            _contexto.Administradores.Remove(administrador);
            await _contexto.SaveChangesAsync();
        }

        public async Task<AdministradorDTO> ObterPorId(int id)
        {
            var administrador = await _contexto.Administradores.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            var administradorDTO = _mapper.Map<AdministradorDTO>(administrador);
            return administradorDTO;
        }

        public async Task<List<AdministradorDTO>> ObterTodos()
        {
            var administradors = await _contexto.Administradores.AsNoTracking().ToListAsync();

            var administradorsDTO = _mapper.Map<List<AdministradorDTO>>(administradors);
            return administradorsDTO;
        }



    }
}
