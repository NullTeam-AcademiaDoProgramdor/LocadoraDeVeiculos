using LocadoraDeVeiculos.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Dominio.FuncionarioModule
{
    public interface IRepositorFuncionarioBase : IRepositorBase<Funcionario>
    {
        Funcionario SelecionarPorNomeESenha(string nome, string senha);
    }
}
