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
    public class FuncionarioController : ControllerBase
    {
        FuncionarioRepository FuncionarioRepository = new FuncionarioRepository();
        [Authorize]
        [HttpGet]
        //listar
        public IActionResult Listar()
        {
            return Ok(FuncionarioRepository.Listar());
        }

        //cadastrar
        [HttpPost]
        public IActionResult Cadastrar (Funcionarios funcionario)
        {
            try
            {
                FuncionarioRepository.Cadastrar(funcionario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Não foi dessa vez..." + ex.Message });
            }
        }
        //buscar por id
        [Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Funcionarios Funcionario = FuncionarioRepository.BuscarPorId(id);
            if (Funcionario == null)
                return NotFound();
            return Ok(Funcionario);
        }

        //atualizar
        [HttpPut]
        public IActionResult Atualizar(Funcionarios funcionario)
        {
            try
            {
                Funcionarios FuncionarioBuscado = FuncionarioRepository.BuscarPorId(funcionario.IdFuncionario);
                if (FuncionarioBuscado == null)
                    return NotFound();
                FuncionarioRepository.Atualizar(funcionario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Não deu certo" });
            }
        }

        //delete 
        [HttpDelete("{id}")]
        public IActionResult Deletar (int id)
        {
            FuncionarioRepository.Deletar(id);
            return Ok();
        }
        ////
    }
}
