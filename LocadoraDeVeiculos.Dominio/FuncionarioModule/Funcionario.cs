using LocadoraDeVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.FuncionarioModule
{
    public class Funcionario : EntidadeBase
    {
        public Funcionario(string nome, DateTime dataAdmissao, double salario, string senha)
        {
            Nome = nome;
            DataAdmissao = dataAdmissao;
            Salario = salario;
            Senha = senha;
        }

        public string Nome { get; }
        public DateTime DataAdmissao { get; }
        public double Salario { get; }
        public string Senha { get; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Funcionario);
        }

        public bool Equals(Funcionario other)
        {
            return other != null &&
                   Id == other.Id &&
                   Nome == other.Nome &&
                   DataAdmissao == other.DataAdmissao &&
                   Salario == other.Salario &&
                   Senha == other.Senha;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (DataAdmissao > DateTime.Now)
                resultadoValidacao = "O campo data de admissão não pode ser no futuro";            

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }


    }
}
