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
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculosController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        // GET: api/Veiculos
        [HttpGet]
        [Authorize(Roles = "adm,editor")]
        public async Task<ActionResult<IEnumerable<VeiculoDTO>>> ObterTodos()
        {
            var veiculos = await _veiculoService.ObterTodos();
            return Ok(veiculos);
        }

        // GET: api/Veiculos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VeiculoDTO>> ObterPorId(int id)
        {
            var veiculo = await _veiculoService.ObterPorId(id);

            if (veiculo == null)
            {
                return NotFound();
            }

            return Ok(veiculo);
        }


        // POST: api/Veiculos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "adm,editor")]
        public async Task<ActionResult<VeiculoDTO>> Adicionar(VeiculoDTO veiculo)
        {
            await _veiculoService.Adicionar(veiculo);
            return CreatedAtAction(nameof(ObterPorId), new { id = veiculo.Id }, veiculo);
        }


        // PUT: api/Veiculos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "adm")]
        public async Task<IActionResult> Atualizar(int id, VeiculoDTO veiculo)
        {
            if (id != veiculo.Id)
            {
                return BadRequest();
            }

            var veiculoExistente = await _veiculoService.ObterPorId(id);
            if (veiculoExistente == null)
            {
                return NotFound();
            }

            await _veiculoService.Atualizar(veiculo);
            return NoContent();
        }


        // DELETE: api/Veiculos/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "adm")]
        public async Task<IActionResult> Remover(int id)
        {
            var veiculoExistente = await _veiculoService.ObterPorId(id);
            if (veiculoExistente == null)
            {
                return NotFound();
            }

            await _veiculoService.Remover(id);
            return NoContent();
        }

    }
}
