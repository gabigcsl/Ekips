using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositorio
{
    public class CargosRepository
    {
        //listar(get)
        public List<Cargos> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Cargos.ToList();
            }
        }
        //buscar cargo por id
        public Cargos BuscarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Cargos.FirstOrDefault(x => x.IdCargo == id);
            }
        }

        //cadastrar(post)
        public void Cadastrar(Cargos cargo)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                ctx.Cargos.Add(cargo);
                ctx.SaveChanges();
            }
        }
            //atualizar 
            public void Atualizar(Cargos cargos)
            {
                using (EkipsContext ctx = new EkipsContext())
                {
                    Cargos CargoBuscado = ctx.Cargos.FirstOrDefault(x => x.IdCargo == cargos.IdCargo);
                    CargoBuscado.Nome = cargos.Nome;
                    ctx.Cargos.Update(CargoBuscado);
                    ctx.SaveChanges();
                }
            }
    }
}
