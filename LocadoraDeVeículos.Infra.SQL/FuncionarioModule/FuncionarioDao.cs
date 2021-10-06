using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.Infra.Log;
using LocadoraDeVeiculos.Infra.ORM.Shared;
using LocadoraDeVeiculos.Infra.Shared;
using LocadoraDeVeiculos.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeículos.Infra.SQL.FuncionarioModule
{
    public class FuncionarioDao : SQLDAOBase, IRepositorFuncionarioBase
    {
        #region queries
        private const string sqlInserirFuncionario =
            @"INSERT INTO FUNCIONARIO 
	                (
		                [NOME], 
		                [DATADEENTRADA], 
		                [SALARIO],
                        [SENHA]
	                ) 
	                VALUES
	                (
                        @NOME, 
                        @DATADEENTRADA,
                        @SALARIO,
		                @SENHA
	                )";

        private const string sqlEditarFuncionario =
            @"UPDATE FUNCIONARIO
                    SET
                        [NOME] = @NOME, 
		                [DATADEENTRADA] = @DATADEENTRADA, 
		                [SALARIO] = @SALARIO,
                        [SENHA] = @SENHA
                    WHERE 
                        ID = @ID";

        private const string sqlExcluirFuncionario =
            @"DELETE 
                    FROM 
                        FUNCIONARIO
                    WHERE
                        ID = @ID";

        private const string sqlExisteFuncionario =
            @"SELECT 
                COUNT(*) 
            FROM 
                [FUNCIONARIO]
            WHERE 
                [ID] = @ID";

        private const string sqlSelecionarFuncionarioPorId =
            @"SELECT
                        [ID],
                        [NOME],
                        [DATADEENTRADA],
                        [SALARIO],
                        [SENHA]
                    FROM
                        FUNCIONARIO
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarFuncionarioNomeESenha =
            @"SELECT
                        [ID],
                        [NOME],
                        [DATADEENTRADA],
                        [SALARIO],
                        [SENHA]
                    FROM
                        FUNCIONARIO
                    WHERE 
                        NOME = @NOME 
                    AND
                        SENHA = @SENHA";

        private const string sqlSelecionarTodosFuncionarios =
            @"SELECT
                        [ID],
                        [NOME],
                        [DATADEENTRADA],
                        [SALARIO],
                        [SENHA]
	                FROM
                        FUNCIONARIO";
        #endregion

        public bool InserirNovo(Funcionario registro)
        {
            Serilog.Log.Logger.Aqui().Information($"Inserindo Funcionario [{registro.Nome}]");
            Serilog.Log.Debug($"SQL inserir Funcionario: {sqlInserirFuncionario}");
            registro.Id = Db.Insert(sqlInserirFuncionario, ObtemParametrosFuncionario(registro));
            return registro.Id != 0;

          
        }
       
        public bool Editar(int id, Funcionario registro)
        {
            try
            {
                Serilog.Log.Logger.Aqui().Information($"Editando Funcionario [{registro.Nome}]:{id}");
                Serilog.Log.Debug($"SQL editar pessoa fisica: {sqlEditarFuncionario}");

                registro.Id = id;
                Db.Update(sqlEditarFuncionario, ObtemParametrosFuncionario(registro));
                return true;
            }
            catch (Exception e)
            {
                Serilog.Log.Error(e, e.Message + $"\nID: {id}");
                return false;
            }

        }

        public bool Excluir(int id)
        {
            try
            {
                Serilog.Log.Logger.Aqui().Information($"Excluindo Funcionario{id}");

                Serilog.Log.Debug($"SQL excluir pessoa fisica: {sqlExcluirFuncionario}");

                Db.Delete(sqlExcluirFuncionario, AdicionarParametro("ID", id));
                return true;
            }
            catch (Exception e)
            {
                Serilog.Log.Error(e, e.Message + $"\nID: {id}");
                return false;
            }
        }

        public bool Existe(int id)
        {
            return Db.Exists(sqlExisteFuncionario, AdicionarParametro("ID", id));
        }

        public Funcionario SelecionarPorId(int id)
        {
            Serilog.Log.Logger.Aqui().Information($"Selecionando Funcionario por id: {id}");

            Serilog.Log.Debug($"SQL Selecionar Funcionario por id: {sqlSelecionarFuncionarioPorId}");

            return Db.Get(sqlSelecionarFuncionarioPorId, ConverterEmFuncionario, AdicionarParametro("ID", id));
        }

        public List<Funcionario> SelecionarTodos()
        {
            Serilog.Log.Logger.Aqui().Information($"Selecionando Todos os Funcionarios");

            Serilog.Log.Debug($"SQL Selecionar Todos os Funcionarios: {sqlSelecionarTodosFuncionarios}");

            return Db.GetAll(sqlSelecionarTodosFuncionarios, ConverterEmFuncionario);
        }

        public Funcionario SelecionarPorNomeESenha(string nome, string senha)
        {
            Dictionary<string, object> parametros = new Dictionary<string, object>()
            {
                {"NOME", nome}, {"SENHA",senha}
            };
            return Db.Get(sqlSelecionarFuncionarioNomeESenha, ConverterEmFuncionario, parametros);
        }

        private Dictionary<string, object> ObtemParametrosFuncionario(Funcionario funcionario)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", funcionario.Id);
            parametros.Add("NOME", funcionario.Nome);
            parametros.Add("DATADEENTRADA", funcionario.DataAdmissao);
            parametros.Add("SALARIO", funcionario.Salario);
            parametros.Add("SENHA", funcionario.Senha);

            return parametros;
        }

        private Funcionario ConverterEmFuncionario(IDataReader reader)
        {
            var id = Convert.ToInt32(reader["ID"]);
            var nome = Convert.ToString(reader["NOME"]);
            var dataDeEntrada = Convert.ToDateTime(reader["DATADEENTRADA"]);
            var salario = Convert.ToDouble(reader["SALARIO"]);
            var senha = Convert.ToString(reader["SENHA"]);

            Funcionario funcionario = new Funcionario(nome, dataDeEntrada, salario, senha);

            funcionario.Id = id;

            return funcionario;
        }

    }
}
