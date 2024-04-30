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


    public class ProcedimentosController : ControllerBase
    {
        private static List<Procedimentos> clientes = new List<Procedimentos>()
        {
            new Procedimentos() {Id = 1, Nome = "Drenagem Linfática", Descriçao = "Massagem local que pode ser realizada em diversas partes do corpo.", ValorProcedimento = 149.99, ProfissionalResponsavel = "Sonia"},
            new Procedimentos() {Id = 2, Nome = "Limpeza de Pele", Descriçao = "Limpeza facial com utilização de produtos, retira impurezas da pele.", ValorProcedimento = 119.99, ProfissionalResponsavel = "Solange"},
            new Procedimentos() {Id = 3, Nome = "Rádio Frequência", Descriçao = "Aparelho que utiliza da rádiofrequência para reduzir flacidez corporal.", ValorProcedimento = 99.99, ProfissionalResponsavel = "Sonia"},
            new Procedimentos() {Id = 4, Nome = "Cavitação", Descriçao = "Aparelho de ultrassom utilizado para reduzir gordura localizada.", ValorProcedimento = 89.99, ProfissionalResponsavel = "Solange"}
        };

        private readonly DataContext _context;

        public ProcedimentosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Procedimentos p = await _context.TB_PROCEDIMENTOS
                    .FirstOrDefaultAsync(pBusca => pBusca.Id == id);
                return Ok(p);
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
                List<Procedimentos> lista = await _context.TB_PROCEDIMENTOS.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Procedimentos novoProcedimento)
        {
            try
            {
                await _context.TB_PROCEDIMENTOS.AddAsync(novoProcedimento);
                await _context.SaveChangesAsync();

                return Ok(novoProcedimento.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Procedimentos novoProcedimento)
        {
             try
            {
                _context.TB_PROCEDIMENTOS.Update(novoProcedimento);
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
                Procedimentos pRemover = await _context.TB_PROCEDIMENTOS.FirstOrDefaultAsync(p => p.Id == id);

                _context.TB_PROCEDIMENTOS.Remove(pRemover);
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