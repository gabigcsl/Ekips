using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositorio
{
    public class FuncionarioRepository
    {
        //listar(get)
        public List<Funcionarios> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Funcionarios.ToList();
            }
        }
        //cadastrar(post)
        public void Cadastrar(Funcionarios funcionario)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                ctx.Funcionarios.Add(funcionario);
                ctx.SaveChanges();
            }
        }

        //buscar por id
        public Funcionarios BuscarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Funcionarios.FirstOrDefault(x => x.IdFuncionario == id);
            }
        }
        //atualizar 
        public void Atualizar(Funcionarios funcionario)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Funcionarios FuncionarioBuscada = ctx.Funcionarios.FirstOrDefault(x => x.IdFuncionario == funcionario.IdFuncionario);
                FuncionarioBuscada.Nome = funcionario.Nome;
                ctx.Funcionarios.Update(FuncionarioBuscada);
                ctx.SaveChanges();
            }
        }
        //deletar

        public void Deletar(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Funcionarios Funcionario = ctx.Funcionarios.Find(id);
                ctx.Funcionarios.Remove(Funcionario);
                ctx.SaveChanges();
            }
        }

        ///////
    }
}
