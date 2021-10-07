using LocadoraDeVeiculos.Dominio.PessoaJuridicaModule;
using LocadoraDeVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.PessoaFisicaModule
{
    public class PessoaFisica : EntidadeBase, IEquatable<PessoaFisica>
    {
        public PessoaFisica(string nome, string cPF, string rG, string cNH,
            DateTime vencimentoCNH, string telefone, string endereco,
            PessoaJuridica pessoaJuridica, string email)
        {
            Nome = nome;
            CPF = cPF;
            RG = rG;
            CNH = cNH;
            VencimentoCNH = vencimentoCNH;
            Telefone = telefone;
            Endereco = endereco;
            PessoaJuridica = pessoaJuridica;
            Email = email;
        }

        public PessoaFisica()
        {

        }

        public string Nome { get; }
        public string CPF { get; }
        public string RG { get; }
        public string CNH { get; }
        public DateTime VencimentoCNH { get; }
        public string Telefone { get; }
        public string Endereco { get; }
        public string Email { get; }
        public virtual PessoaJuridica PessoaJuridica { get; }

        public override bool Equals(object obj)
        {
            return Equals(obj as PessoaFisica);
        }

        public bool Equals(PessoaFisica other)
        {
            return other != null &&
                   id == other.id &&
                   Id == other.Id &&
                   Nome == other.Nome &&
                   CPF == other.CPF &&
                   RG == other.RG &&
                   CNH == other.CNH &&
                   VencimentoCNH == other.VencimentoCNH &&
                   Telefone == other.Telefone &&
                   Endereco == other.Endereco &&
                   EqualityComparer<PessoaJuridica>.Default.Equals(PessoaJuridica, other.PessoaJuridica);
        }

        public override int GetHashCode()
        {
            int hashCode = 1053604776;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CPF);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(RG);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CNH);
            hashCode = hashCode * -1521134295 + VencimentoCNH.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Telefone);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Endereco);
            hashCode = hashCode * -1521134295 + EqualityComparer<PessoaJuridica>.Default.GetHashCode(PessoaJuridica);
            return hashCode;
        }

        public override string ToString()
        {
            if (PessoaJuridica != null)
                return Nome + $" ({PessoaJuridica.Nome})";
            else
                return Nome;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(Nome))
                resultadoValidacao = "O campo 'nome' não pode estar vazio.";

            if (string.IsNullOrEmpty(CPF))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo 'CPF' não pode estar vazio.";
            else if (CPF.Length != 14)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "CPF inválido.";

            if (string.IsNullOrEmpty(RG))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo 'RG' não pode estar vazio.";

            if (string.IsNullOrEmpty(CNH))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo 'CNH' não pode estar vazio.";
            else if (CNH.Length != 12)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "CNH inválida.";

            if (string.IsNullOrEmpty(Telefone))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo 'Telefone' não pode estar vazio.";
            else if (Telefone.Length != 14 && Telefone.Length != 13)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Número de telefone muito pequeno.";

            if (string.IsNullOrEmpty(Endereco))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo 'Endereço' não pode estar vazio.";

            try
            {
                MailAddress email = new MailAddress(Email);
            }
            catch (Exception)
            {
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Digite um E-mail válido";
            }

            if (VencimentoCNH == DateTime.MinValue)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo 'data de vencimento' não pode estar vazio.";
            else if (DateTime.Compare(VencimentoCNH, DateTime.Now) <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "A data de vencimento da CNH não pode ser aceita.";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }
    }
}