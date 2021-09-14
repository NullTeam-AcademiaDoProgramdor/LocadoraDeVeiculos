using LocadoraDeVeículos.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.FuncionarioModule
{
    public abstract class RepositorFuncionarioBase : IRepositor<Funcionario>
    {
        public abstract Funcionario SelecionarPorNomeESenha(string nome, string senha);
    }
}
