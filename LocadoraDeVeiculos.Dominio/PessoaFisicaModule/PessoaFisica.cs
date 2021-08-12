using LocadoraDeVeiculos.Dominio.PessoaJuridicaModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.PessoaFisicaModule
{
    public class PessoaFisica
    {
        public PessoaFisica(string nome, string cPF, string rG, string cNH,
            string telefone, string endereco, PessoaJuridica pessoaJuridica = null)
        {
            Nome = nome;
            CPF = cPF;
            RG = rG;
            CNH = cNH;
            Telefone = telefone;
            Endereco = endereco;
            PessoaJuridica = pessoaJuridica;
        }

        //Dever ter o nome, CPF, RG, CNH, telefone, endereço
        //Pode ser ligada a uma pessoa jurídica

        public string Nome { get; }
        public string CPF { get; }
        public string RG { get; }
        public string CNH { get; }
        public string Telefone { get; }
        public string Endereco { get; }
        public PessoaJuridica PessoaJuridica { get; }
    }
}
