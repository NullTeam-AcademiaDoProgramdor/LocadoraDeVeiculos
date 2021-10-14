using LocadoraDeVeículos.Aplicacao.Shared;
using LocadoraDeVeiculos.Dominio.AutomovelModule;
using LocadoraDeVeiculos.Infra.Log;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeículos.Aplicacao.AutomovelModule
{
    public class AutomovelAppService : ICadastravel<Automovel>
    {
        private IRepositorAutomovelBase repositorio;
        private DBLocadoraContext db;

        public AutomovelAppService(IRepositorAutomovelBase repositorio,
                                   DBLocadoraContext db)
        {
            this.db = db;
            this.repositorio = repositorio;
        }

        public string Editar(int id, Automovel registro)
        {
            string resultadoValidacao = registro.Validar();
            Serilog.Log.Logger.Aqui().Information($"Validando automovel [{registro.Modelo}]: {id}, Resultado: {resultadoValidacao}");

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                repositorio.Editar(id, registro);
                db.SaveChanges();
                //repositorioFotos.Modificar(registro.Fotos, registro.id);
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

        public string EditarKmRegistrada(int id, Automovel registro)
        {
            string resultadoValidacao = registro.Validar();
            Serilog.Log.Logger.Aqui().Information($"Validando automovel [{registro.Modelo}], Resultado: {resultadoValidacao}");

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                repositorio.EditarKmRegistrada(id, registro);
                db.SaveChanges();
            }

            return resultadoValidacao;
        }

        public string InserirNovo(Automovel registro)
        {
            string resultadoValidacao = registro.Validar();
            Serilog.Log.Logger.Aqui().Information($"Validando automovel [{registro.Modelo}], Resultado: {resultadoValidacao}");

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                repositorio.InserirNovo(registro);
                db.SaveChanges();
                //repositorioFotos.Modificar(registro.Fotos, registro.id);
            }

            return resultadoValidacao;
        }

        public Automovel SelecionarPorId(int id)
        {
            var automovel = repositorio.SelecionarPorId(id);

            //AdicionarFotosNoAutomovel(automovel);

            return automovel;
        }

        public List<Automovel> SelecionarTodos()
        {
            var automoveis = repositorio.SelecionarTodos();

            //foreach (var automovel in automoveis)
            //    AdicionarFotosNoAutomovel(automovel);

            return automoveis;
        }

        public List<Automovel> SelecionarDisponiveis()
        {
            return repositorio.SelecionarAutomoveisDisponiveis();
        }

        //private void AdicionarFotosNoAutomovel(Automovel automovel)
        //{
        //    automovel.Fotos = repositorioFotos.Buscar(automovel.id);
        //}
    }
}
