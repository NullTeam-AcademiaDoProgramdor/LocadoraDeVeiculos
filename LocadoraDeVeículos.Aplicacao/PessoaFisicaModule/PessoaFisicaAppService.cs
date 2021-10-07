using LocadoraDeVeículos.Aplicacao.Shared;
using LocadoraDeVeiculos.Dominio.PessoaFisicaModule;
using LocadoraDeVeiculos.Dominio.Shared;
using LocadoraDeVeiculos.Infra.Log;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeículos.Aplicacao.PessoaFisicaModule
{
    public class PessoaFisicaAppService : ICadastravel<PessoaFisica>
    {
        private IRepositorBase<PessoaFisica> repositorio;
        private readonly DBLocadoraContext dbContext;

        public PessoaFisicaAppService(IRepositorBase<PessoaFisica> repositor, DBLocadoraContext dbContext)
        {
            repositorio = repositor;
            this.dbContext = dbContext;
        }

        public virtual string InserirNovo(PessoaFisica registro)
        {
            string resultadoValidacao = registro.Validar();
            Serilog.Log.Logger.Aqui().Information($"Validando Pessoa Fisica [{registro.Nome}], Resultado: {resultadoValidacao}");

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                repositorio.InserirNovo(registro);
                dbContext.SaveChanges();
            }

            return resultadoValidacao;
        }

        public virtual string Editar(int id, PessoaFisica registro)
        {
            string resultadoValidacao = registro.Validar();
            Serilog.Log.Logger.Aqui().Information($"Validando Pessoa Fisica [{registro.Nome}]: {id}, Resultado: {resultadoValidacao}");

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                repositorio.Editar(id, registro);
                dbContext.SaveChanges();
            }

            return resultadoValidacao;
        }

        public bool Excluir(int id)
        {
            bool resultado = repositorio.Excluir(id);
            dbContext.SaveChanges();

            return resultado;
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
