using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.ApplicationCore.DTOs;
using API.Infrastructure.Data.Context;
using API.ApplicationCore.Interfaces;
using API.ApplicationCore.Services;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradoresController : ControllerBase
    {
        private readonly IAdministradorService _administradorService;
        private readonly IConfiguration _configuration;

        public AdministradoresController(IAdministradorService administradorService, IConfiguration configuration)
        {
            _administradorService = administradorService;
            _configuration = configuration;
        }

        
        [HttpPost("/login")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<LoginResponseDTO>>> Login(LoginDTO login)
        {
            var administrador = await _administradorService.Login(login);
            if (administrador == null)
            {
                return Unauthorized();
            }

            string token = TokenService.GenerateJWTToken(administrador,_configuration);
            
            return Ok(new LoginResponseDTO() { 
                Email = administrador.Email,
                Perfil = administrador.Perfil.ToString(),
                Token = token
            });
        }

        // GET: api/Administradors
        [HttpGet]
        [Authorize(Roles = "adm")]
        public async Task<ActionResult<IEnumerable<AdministradorDTO>>> ObterTodos()
        {
            var administradores = await _administradorService.ObterTodos();
            return Ok(administradores);
        }

        // GET: api/Administradors/5
        [HttpGet("{id}")]
        [Authorize(Roles = "adm")]
        public async Task<ActionResult<AdministradorDTO>> ObterPorId(int id)
        {
            var administrador = await _administradorService.ObterPorId(id);

            if (administrador == null)
            {
                return NotFound();
            }

            return Ok(administrador);
        }


        // POST: api/Administradors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "adm")]
        public async Task<ActionResult<AdministradorDTO>> Adicionar(AdministradorDTO administrador)
        {
            await _administradorService.Adicionar(administrador);
            return CreatedAtAction(nameof(ObterPorId), new { id = administrador.Id }, administrador);
        }


        // PUT: api/Administradors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "adm")]
        public async Task<IActionResult> Atualizar(int id, AdministradorDTO administrador)
        {
            if (id != administrador.Id)
            {
                return BadRequest();
            }

            var administradorExistente = await _administradorService.ObterPorId(id);
            if (administradorExistente == null)
            {
                return NotFound();
            }

            await _administradorService.Atualizar(administrador);
            return NoContent();
        }


        // DELETE: api/Administradors/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "adm")]
        public async Task<IActionResult> Remover(int id)
        {
            var administradorExistente = await _administradorService.ObterPorId(id);
            if (administradorExistente == null)
            {
                return NotFound();
            }

            await _administradorService.Remover(id);
            return NoContent();
        }


    }
}
