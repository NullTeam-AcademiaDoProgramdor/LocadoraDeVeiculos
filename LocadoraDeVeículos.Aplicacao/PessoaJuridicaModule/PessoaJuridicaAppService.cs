using LocadoraDeVeículos.Aplicacao.Shared;
using LocadoraDeVeiculos.Dominio.PessoaJuridicaModule;
using LocadoraDeVeículos.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeículos.Aplicacao.PessoaJuridicaModule
{
    public class PessoaJuridicaAppService : ICadastravel<PessoaJuridica>
    {
        private IRepositor<PessoaJuridica> repositorio;

        public PessoaJuridicaAppService(IRepositor<PessoaJuridica> repositor)
        {
            repositorio = repositor;
        }

        public string InserirNovo(PessoaJuridica registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                repositorio.InserirNovo(registro);
            }

            return resultadoValidacao;
        }

        public string Editar(int id, PessoaJuridica registro)
        {
            string resultadoValidacao = registro.Validar();

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
