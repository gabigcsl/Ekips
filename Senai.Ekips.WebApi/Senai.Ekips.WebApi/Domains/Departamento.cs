using System;
using System.Collections.Generic;

namespace Senai.Ekips.WebApi.Domains
{
    public partial class Departamento
    {
        public Departamento()
        {
            Funcionarios = new HashSet<Funcionarios>();
        }

        public int IdDepartamento { get; set; }
        public string Nome { get; set; }

        public ICollection<Funcionarios> Funcionarios { get; set; }
    }
}
