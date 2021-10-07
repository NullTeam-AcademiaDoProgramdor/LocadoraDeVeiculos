using LocadoraDeVeículos.Aplicacao.Shared;
using LocadoraDeVeiculos.Dominio.PessoaJuridicaModule;
using LocadoraDeVeiculos.Dominio.Shared;
using LocadoraDeVeiculos.Infra.Log;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeículos.Aplicacao.PessoaJuridicaModule
{
    public class PessoaJuridicaAppService : ICadastravel<PessoaJuridica>
    {
        private IRepositorBase<PessoaJuridica> repositorio;
        private readonly DBLocadoraContext db;

        public PessoaJuridicaAppService(IRepositorBase<PessoaJuridica> repositor, DBLocadoraContext db)
        {
            repositorio = repositor;
            this.db = db;
        }

        public string InserirNovo(PessoaJuridica registro)
        {
            string resultadoValidacao = registro.Validar();
            Serilog.Log.Logger.Aqui().Information($"Validando Pessoa Jurídica [{registro.Nome}], Resultado: {resultadoValidacao}");

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                repositorio.InserirNovo(registro);
                db.SaveChanges();
            }

            return resultadoValidacao;
        }

        public string Editar(int id, PessoaJuridica registro)
        {
            string resultadoValidacao = registro.Validar();
            Serilog.Log.Logger.Aqui().Information($"Validando Pessoa Jurídica [{registro.Nome}]: {id}, Resultado: {resultadoValidacao}");

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                repositorio.Editar(id, registro);
                db.SaveChanges();
            }

            return resultadoValidacao;
        }

        public bool Excluir(int id)
        {
            bool resultado = repositorio.Excluir(id);
            db.SaveChanges();

            return resultado;
        }

        public bool Existe(int id)
        {
            return repositorio.Existe(id);
        }


        public PessoaJuridica SelecionarPorId(int id)
        {
            return repositorio.SelecionarPorId(id);
        }

        public List<PessoaJuridica> SelecionarTodos()
        {
            return repositorio.SelecionarTodos();
        }
    }
}
