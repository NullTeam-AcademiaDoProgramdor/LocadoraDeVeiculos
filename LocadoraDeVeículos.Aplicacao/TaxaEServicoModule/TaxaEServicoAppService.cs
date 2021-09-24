using LocadoraDeVeículos.Aplicacao.Shared;
using LocadoraDeVeiculos.Dominio.TaxasEServicosModule;
using LocadoraDeVeiculos.Infra.Log;
using LocadoraDeVeículos.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeículos.Aplicacao.TaxaEServicoModule
{
    public class TaxaEServicoAppService : ICadastravel<TaxaEServico>
    {
        RepositorBase<TaxaEServico> repositorio;

        public TaxaEServicoAppService(RepositorBase<TaxaEServico> repositorio)
        {
            this.repositorio = repositorio;
        }

        public string InserirNovo(TaxaEServico registro)
        {
            string resultadoValidacao = registro.Validar();
            Log.log.Info($"Validando Taxa e Serviço [{registro.Nome}], Resultado: {resultadoValidacao}");

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                repositorio.InserirNovo(registro);
            }

            return resultadoValidacao;
        }

        public string Editar(int id, TaxaEServico registro)
        {
            string resultadoValidacao = registro.Validar();
            Log.log.Info($"Validando Taxa e Serviço [{registro.Nome}]: {id}, Resultado: {resultadoValidacao}");

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

        public TaxaEServico SelecionarPorId(int id)
        {
            return repositorio.SelecionarPorId(id);
        }

        public List<TaxaEServico> SelecionarTodos()
        {
            return repositorio.SelecionarTodos();
        }        
    }
}
