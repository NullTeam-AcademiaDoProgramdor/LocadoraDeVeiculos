using LocadoraDeVeículos.Aplicacao.Shared;
using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.Infra.Log;
using LocadoraDeVeiculos.Infra.ORM.Models;
using LocadoraDeVeiculos.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeículos.Aplicacao.FuncionarioModule
{
    public class FuncionarioAppService : ICadastravel<Funcionario>
    {
        private IRepositorFuncionarioBase repositorio;
        private  DBLocadoraContext db;

        public FuncionarioAppService(IRepositorFuncionarioBase repositor, DBLocadoraContext db)
        {
            repositorio = repositor;
            this.db = db;
            
        }

        public string InserirNovo(Funcionario registro) 
        {
            string resultadoValidacao = registro.Validar();
            Serilog.Log.Logger.Aqui().Information($"Validando Funcionario [{registro.Nome}], Resultado: {resultadoValidacao}");
            if (resultadoValidacao == "ESTA_VALIDO")
            {
                repositorio.InserirNovo(registro);
                db.SaveChanges();

            }

            return resultadoValidacao;
        }

        public string Editar(int id, Funcionario registro)
        {
            string resultadoValidacao = registro.Validar();
            Serilog.Log.Logger.Aqui().Information($"Validando Funcionario [{registro.Nome}]: {id}, Resultado: {resultadoValidacao}");
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

        public Funcionario SelecionarPorId(int id)
        {
            return repositorio.SelecionarPorId(id);
        }

        public Funcionario SelecionarPorNomeESenha(string nome, string senha)
        {
            return repositorio.SelecionarPorNomeESenha(nome, senha);
        }

        public List<Funcionario> SelecionarTodos()
        {
            return repositorio.SelecionarTodos();
        }
    }
}
