using LocadoraDeVeiculos.Dominio.PessoaJuridicaModule;
using LocadoraDeVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.PessoaFisicaModule
{
    public class PessoaFisica : EntidadeBase, IEquatable<PessoaFisica>
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

        public override bool Equals(object obj)
        {
            return Equals(obj as PessoaFisica);
        }

        public bool Equals(PessoaFisica other)
        {
            return other != null &&
                   Nome == other.Nome &&
                   CPF == other.CPF &&
                   RG == other.RG &&
                   CNH == other.CNH &&
                   Telefone == other.Telefone &&
                   Endereco == other.Endereco &&
                   EqualityComparer<PessoaJuridica>.Default.Equals(PessoaJuridica, other.PessoaJuridica);
        }

        public override int GetHashCode()
        {
            int hashCode = 1083796582;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CPF);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(RG);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CNH);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Telefone);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Endereco);
            hashCode = hashCode * -1521134295 + EqualityComparer<PessoaJuridica>.Default.GetHashCode(PessoaJuridica);
            return hashCode;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(Nome))
                resultadoValidacao = "O campo 'nome' não pode estar vazio.";

            if (string.IsNullOrEmpty(CPF))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo 'CPF' não pode estar vazio.";
            
            if (string.IsNullOrEmpty(RG))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo 'RG' não pode estar vazio.";
            
            if (string.IsNullOrEmpty(CNH))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo 'CNH' não pode estar vazio.";
            
            if (string.IsNullOrEmpty(Telefone))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo 'Telefone' não pode estar vazio.";
            
            if (string.IsNullOrEmpty(Endereco))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo 'Endereço' não pode estar vazio.";
            
            return resultadoValidacao;
        }
    }
}
