using System;
using System.Collections.Generic;
using LocadoraDeVeiculos.Infra.Log;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeículos.Aplicacao.Shared;
using LocadoraDeVeiculos.Dominio.CupomModule;
using LocadoraDeVeiculos.Infra.ORM.Models;

namespace LocadoraDeVeículos.Aplicacao.CupomModule
{
    public class CupomAppService : ICadastravel<Cupom>
    {
        private IRepositorCupomBase repositorio;
        private DBLocadoraContext db;

        public CupomAppService(IRepositorCupomBase repositorio, DBLocadoraContext db)
        {
            this.repositorio = repositorio;
            this.db = db;
        }

        public string Editar(int id, Cupom registro)
        {
            string resultadoValidacao = registro.Validar();
            Serilog.Log.Logger.Aqui().Information($"Validando cupom [{registro.Codigo}]: {id}, Resultado: {resultadoValidacao}");

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

        public string InserirNovo(Cupom registro)
        {
            string resultadoValidacao = registro.Validar();
            Serilog.Log.Logger.Aqui().Information($"Validando cupom [{registro.Codigo}], Resultado: {resultadoValidacao}");

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                repositorio.InserirNovo(registro);
                db.SaveChanges();
            }

            return resultadoValidacao;
        }

        public Cupom SelecionarPorId(int id)
        {
            return repositorio.SelecionarPorId(id);
        }

        public List<Cupom> SelecionarTodos()
        {
            return repositorio.SelecionarTodos();
        }

        public void EditarQtdUsos(Cupom cupom)
        {
            repositorio.EditarQtdUsos(cupom);
            db.SaveChanges();
        }

        public Cupom SelecionarPorCodigo(string codigo)
        {
            return repositorio.SelecionarPorCodigo(codigo);
        }

        public List<Cupom> SelecionarValidos()
        {
            return repositorio.SelecionarValidos();
        }
    }
}
