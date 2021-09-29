using System;
using System.Collections.Generic;
using LocadoraDeVeiculos.Infra.Log;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraDeVeículos.Aplicacao.Shared;
using LocadoraDeVeiculos.Dominio.CupomModule;

namespace LocadoraDeVeículos.Aplicacao.CupomModule
{
    public class CupomAppService : ICadastravel<Cupom>
    {
        private RepositorCupomBase repositorio;

        public CupomAppService(RepositorCupomBase repositorio)
        {
            this.repositorio = repositorio;
        }

        public string Editar(int id, Cupom registro)
        {
            string resultadoValidacao = registro.Validar();
            Serilog.Log.Logger.Aqui().Information($"Validando cupom [{registro.Codigo}]: {id}, Resultado: {resultadoValidacao}");

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

        public string InserirNovo(Cupom registro)
        {
            string resultadoValidacao = registro.Validar();
            Serilog.Log.Logger.Aqui().Information($"Validando cupom [{registro.Codigo}], Resultado: {resultadoValidacao}");

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                repositorio.InserirNovo(registro);
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
