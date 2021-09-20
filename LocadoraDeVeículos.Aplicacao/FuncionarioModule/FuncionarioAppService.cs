using LocadoraDeVeículos.Aplicacao.Shared;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeículos.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeículos.Aplicacao.FuncionarioModule
{
    public class FuncionarioAppService : ICadastravel<Funcionario>
    {
        private RepositorFuncionarioBase repositorio;

        public FuncionarioAppService(RepositorFuncionarioBase repositor)
        {
            repositorio = repositor;
        }

        public string InserirNovo(Funcionario funcionario)
        {
            string resultadoValidacao = funcionario.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                repositorio.InserirNovo(funcionario);
            }

            return resultadoValidacao;
        }

        public string Editar(int id, Funcionario funcionario)
        {
            string resultadoValidacao = funcionario.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                repositorio.Editar(id, funcionario);
            }

            return resultadoValidacao;
        }

        public bool Excluir(int id)
        {
            return repositorio.Excluir(id);
        }

        public bool Existe(int id)
        {
            return repositorio.Existe(id);
        }

        public Funcionario SelecionarPorId(int id)
        {
            return repositorio.SelecionarPorId(id);
        }

        public Funcionario SelecionarPorNomeESenha(string nome, string senha)
        {
            return repositorio.SelecionarPorNomeESenha(nome, senha);
        }

        public List<Funcionario> SelecionarTodos()
        {
            return repositorio.SelecionarTodos();
        }
    }
}
