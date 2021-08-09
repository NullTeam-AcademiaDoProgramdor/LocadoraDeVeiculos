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

        public override string Validar()
        {
            return "ESTA_VALIDO";
        }
    }
}
