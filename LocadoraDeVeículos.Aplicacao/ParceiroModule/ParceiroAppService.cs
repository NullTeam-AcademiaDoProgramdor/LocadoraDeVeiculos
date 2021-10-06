using LocadoraDeVeículos.Aplicacao.Shared;
using LocadoraDeVeiculos.Dominio.ParceiroModule;
using LocadoraDeVeiculos.Dominio.Shared;
using LocadoraDeVeiculos.Infra.Log;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeículos.Aplicacao.ParceiroModule
{
    public class ParceiroAppService : ICadastravel<Parceiro>
    {
        private IRepositorBase<Parceiro> repositorio;
        private DBLocadoraContext db;
        public ParceiroAppService(IRepositorBase<Parceiro> repositor,
                                  DBLocadoraContext db)
        {
            repositorio = repositor;
            this.db = db;
        }

        public string InserirNovo(Parceiro registro)
        {
            string resultadoValidacao = registro.Validar();
            Serilog.Log.Logger.Aqui().Information($"Validando parceiro [{registro.Nome}], Resultado: {resultadoValidacao}");

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                repositorio.InserirNovo(registro);
                db.SaveChanges();
            }

            return resultadoValidacao;
        }

        public string Editar(int id, Parceiro registro)
        {
            string resultadoValidacao = registro.Validar();
            Serilog.Log.Logger.Aqui().Information($"Validando parceiro [{registro.Nome}]: {id}, Resultado: {resultadoValidacao}");

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


        public Parceiro SelecionarPorId(int id)
        {
            return repositorio.SelecionarPorId(id);
        }

        public List<Parceiro> SelecionarTodos()
        {
            return repositorio.SelecionarTodos();
        }
    }
}
