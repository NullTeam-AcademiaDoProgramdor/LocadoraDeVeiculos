using System;
using System.Collections.Generic;

#nullable disable

namespace LocadoraDeVeiculos.Infra.ORM.Models
{
    public partial class PessoaJuridica
    {
        public PessoaJuridica()
        {
            PessoaFisicas = new HashSet<PessoaFisica>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<PessoaFisica> PessoaFisicas { get; set; }
    }
}
