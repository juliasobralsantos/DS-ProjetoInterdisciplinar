using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EsteticaEProcedimentos.Models;
using EsteticaEProcedimentos.Data;
using Microsoft.EntityFrameworkCore;

namespace EsteticaEProcedimentos.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public class ClientesController : ControllerBase
    {
        private static List<Clientes> clientes = new List<Clientes>()
        {
            new Clientes() { Id = 1, Nome = "Amanda da Silva", CPF = "243.567.431-10", Telefone = 11965843278, Endereço = "Rua das Orquídeas, 295 - Morumbi", Email = "amandasilva123@gmail.com"},
                new Clientes() { Id = 2, Nome = "Maria Eduarda Oliveira", CPF = "189.298.674-23", Telefone = 11948291640, Endereço = "Rua Maria Cândida, 728 - Casa 2 - Vila Guilherme", Email = "MaduOliveira@hotmail.com"},
                new Clientes() { Id = 3, Nome = "Elisa de Souza Santos", CPF = "368.583.783-79", Telefone = 11987953869, Endereço = "Rua Olavo Egídio, 469 - Santana", Email = "silvaelisa2297@gmail.com"},
                new Clientes() { Id = 4, Nome = "Luciana Almeida", CPF = "474.973.864-84", Telefone = 11938596036, Endereço = "Av. General Ataliba Leonel, 2034 - Parada Inglesa", Email = "lucianaalmeida9@hotmail.com"},
                new Clientes() { Id = 5, Nome = "Fernanda Antunes", CPF = "282.684.290-19", Telefone = 11910384874, Endereço = "Rua da Gávea, 55 - Vila Maria", Email = "fernanda23antunes@gmail.com"},
                new Clientes() { Id = 6, Nome = "Andressa Ferreira", CPF = "173.183.286-57", Telefone = 11928462967, Endereço = "Rua Jacuna, 226 - Carandiru", Email = "andressaferreira79@hotmail.com"},
                new Clientes() { Id = 7, Nome = "Ana Luiza Lisboa", CPF = "372.293.480-48", Telefone = 11949687931, Endereço = "Av. Coronel Sezefredo Fagundes, 2847, apto. 210 - Tremembé", Email = "analulisboa1011@outlook.com"}
        };

        private readonly DataContext _context;

        public ClientesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Clientes c = await _context.TB_CLIENTES
                    .FirstOrDefaultAsync(cBusca => cBusca.Id == id);
                return Ok(c);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Clientes> lista = await _context.TB_CLIENTES.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Clientes novoCliente)
        {
            try
            {
                if(novoCliente.CPF.Length > 11)
                {
                    throw new Exception("CPF inválido.");
                }
                await _context.TB_CLIENTES.AddAsync(novoCliente);
                await _context.SaveChangesAsync();

                return Ok(novoCliente.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Clientes novoCliente)
        {
             try
            {
                if(novoCliente.CPF.Length > 11)
                {
                    throw new System.Exception("CPF inválido.");
                }
                _context.TB_CLIENTES.Update(novoCliente);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Clientes cRemover = await _context.TB_CLIENTES.FirstOrDefaultAsync(c => c.Id == id);

                _context.TB_CLIENTES.Remove(cRemover);
                int linhaAfetadas = await _context.SaveChangesAsync();
                return Ok(linhaAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}