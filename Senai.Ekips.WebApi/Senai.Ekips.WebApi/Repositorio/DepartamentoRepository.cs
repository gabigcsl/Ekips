using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositorio
{
    public class DepartamentoRepository
    {
        //listar(get)
        public List<Departamento> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Departamento.ToList();
            }
        }

        //listar por id

        public Departamento BuscarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Departamento.FirstOrDefault(x => x.IdDepartamento == id);
            }
        }

        // Cadastrar
        public void Cadastrar(Departamento departamento)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                ctx.Departamento.Add(departamento);
                ctx.SaveChanges();
            }
        }


    }
}
