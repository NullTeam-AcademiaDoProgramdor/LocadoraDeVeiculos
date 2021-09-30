using System;
using System.Collections.Generic;

#nullable disable

namespace LocadoraDeVeiculos.Infra.ORM.Models
{
    public partial class PessoaFisica
    {
        public PessoaFisica()
        {
            Locacaos = new HashSet<Locacao>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Cnh { get; set; }
        public string VencimentoCnh { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public int? EmpresaLigada { get; set; }
        public string Email { get; set; }

        public virtual PessoaJuridica EmpresaLigadaNavigation { get; set; }
        public virtual ICollection<Locacao> Locacaos { get; set; }
    }
}
