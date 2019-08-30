using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
       
        DepartamentoRepository DepartamentoRepository = new DepartamentoRepository();
        [Authorize]
        [HttpGet]
        //listar
        public IActionResult Listar()
        {
            return Ok(DepartamentoRepository.Listar());
        }

        //listar por id
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Departamento Departamento = DepartamentoRepository.BuscarPorId(id);
            if (Departamento == null)
                return NotFound();
            return Ok(Departamento);
        }
        //Cadastrar
        [HttpPost]
        public IActionResult Cadastrar(Departamento departamento)
        {
            try
            {
                DepartamentoRepository.Cadastrar(departamento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Não foi dessa vez..." + ex.Message });
            }
        }


    }
}
