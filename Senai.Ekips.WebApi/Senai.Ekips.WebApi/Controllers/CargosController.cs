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
    public class CargosController : ControllerBase
    {
        
        CargosRepository CargosRepository = new CargosRepository();

        public CargosRepository CargosRepository1 { get => CargosRepository; set => CargosRepository = value; }

        [Authorize]
        [HttpGet]
        //listar
        public IActionResult Listar()
        {
            return Ok(CargosRepository1.Listar());
        }
        //buscar cargo por id
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Cargos Cargo = CargosRepository1.BuscarPorId(id);
            if (Cargo == null)
                return NotFound();
            return Ok(Cargo);
        }

        //cadastrar
        [HttpPost]
        public IActionResult Cadastrar(Cargos cargo)
        {
            try
            {
                CargosRepository1.Cadastrar(cargo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Não foi dessa vez..." + ex.Message });
            }
        }

        //atualizar
        [HttpPut]
        public IActionResult Atualizar(Cargos cargos)
        {
            try
            {
                Cargos CargoBuscado = CargosRepository1.BuscarPorId(cargos.IdCargo);
                if (CargoBuscado == null)
                    return NotFound();
                CargosRepository1.Atualizar(cargos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Não deu certo" });
            }
        }
    }
}
