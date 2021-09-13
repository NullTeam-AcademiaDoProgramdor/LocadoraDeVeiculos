using LocadoraDeVeículos.Aplicacao.Shared;
using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
using LocadoraDeVeículos.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeículos.Aplicacao.GrupoAutomovelModule
{
    public class GrupoAutomovelAppService : ICadastravel<GrupoAutomovel>
    {
        private IRepositor<GrupoAutomovel> repositorio;

        public GrupoAutomovelAppService(IRepositor<GrupoAutomovel> repositorio)
        {
            this.repositorio = repositorio;
        }

        public string Editar(int id, GrupoAutomovel registro)
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

        public string InserirNovo(GrupoAutomovel registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                repositorio.InserirNovo(registro);
            }

            return resultadoValidacao;
        }

        public GrupoAutomovel SelecionarPorId(int id)
        {
            return repositorio.SelecionarPorId(id);
        }

        public List<GrupoAutomovel> SelecionarTodos()
        {
            return repositorio.SelecionarTodos();
        }
    }
}
