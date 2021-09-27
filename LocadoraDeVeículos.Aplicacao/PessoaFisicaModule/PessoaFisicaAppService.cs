using LocadoraDeVeículos.Aplicacao.Shared;
using LocadoraDeVeiculos.Dominio.PessoaFisicaModule;
using LocadoraDeVeiculos.Infra.Log;
using LocadoraDeVeículos.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeículos.Aplicacao.PessoaFisicaModule
{
    public class PessoaFisicaAppService : ICadastravel<PessoaFisica>
    {
        private RepositorBase<PessoaFisica> repositorio;

        public PessoaFisicaAppService(RepositorBase<PessoaFisica> repositor)
        {
            repositorio = repositor;
        }

        public string InserirNovo(PessoaFisica registro)
        {
            string resultadoValidacao = registro.Validar();
            Serilog.Log.Information($"Validando Pessoa Fisica [{registro.Nome}], Resultado: {resultadoValidacao}");

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                repositorio.InserirNovo(registro);
            }

            return resultadoValidacao;
        }

        public string Editar(int id, PessoaFisica registro)
        {
            string resultadoValidacao = registro.Validar();
            Serilog.Log.Information($"Validando Pessoa Fisica [{registro.Nome}]: {id}, Resultado: {resultadoValidacao}");

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                repositorio.Editar(id, registro);
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

        public PessoaFisica SelecionarPorId(int id)
        {
            return repositorio.SelecionarPorId(id);
        }

        public List<PessoaFisica> SelecionarTodos()
        {
            return repositorio.SelecionarTodos();
        }
    }
}
