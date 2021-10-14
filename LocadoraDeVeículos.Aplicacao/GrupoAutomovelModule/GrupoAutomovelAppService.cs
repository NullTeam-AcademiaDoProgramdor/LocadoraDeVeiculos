using LocadoraDeVeículos.Aplicacao.Shared;
using LocadoraDeVeiculos.Dominio.GrupoAutomovelModule;
using LocadoraDeVeiculos.Dominio.Shared;
using LocadoraDeVeiculos.Infra.Log;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeículos.Aplicacao.GrupoAutomovelModule
{
    public class GrupoAutomovelAppService : ICadastravel<GrupoAutomovel>
    {
        private IRepositorBase<GrupoAutomovel> repositorio;
        private DBLocadoraContext db;

        public GrupoAutomovelAppService(IRepositorBase<GrupoAutomovel> repositorio,
                                        DBLocadoraContext db)
        {
            this.repositorio = repositorio;
            this.db = db;
        }

        public string Editar(int id, GrupoAutomovel registro)
        {
            string resultadoValidacao = registro.Validar();
            Serilog.Log.Logger.Aqui().Information($"Validando Grupo de Automóvel [{registro.Nome}]: {id}, Resultado: {resultadoValidacao}");

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

        public string InserirNovo(GrupoAutomovel registro)
        {
            string resultadoValidacao = registro.Validar();
            Serilog.Log.Logger.Aqui().Information($"Validando Grupo de Automóvel [{registro.Nome}], Resultado: {resultadoValidacao}");

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                repositorio.InserirNovo(registro);
                db.SaveChanges();
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
