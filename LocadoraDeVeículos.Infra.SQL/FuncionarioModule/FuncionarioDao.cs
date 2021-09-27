using LocadoraDeVeiculos.Dominio.FuncionarioModule;
using LocadoraDeVeiculos.Infra.Log;
using LocadoraDeVeículos.Infra.Shared;
using LocadoraDeVeiculos.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeículos.Infra.SQL.FuncionarioModule
{
    public class FuncionarioDao : RepositorFuncionarioBase
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

        public override bool InserirNovo(Funcionario registro)
        {
            Log.log.Info($"Inserindo Funcionario [{registro.Nome}]");
            Log.log.Debug($"SQL inserir Funcionario: {sqlInserirFuncionario}");
            registro.Id = Db.Insert(sqlInserirFuncionario, ObtemParametrosFuncionario(registro));
            return registro.Id != 0;

          
        }
       
        public override bool Editar(int id, Funcionario registro)
        {
            try
            {
                Log.log.Info($"Editando Funcionario [{registro.Nome}]:{id}");
                Log.log.Debug($"SQL editar pessoa fisica: {sqlEditarFuncionario}");

                registro.Id = id;
                Db.Update(sqlEditarFuncionario, ObtemParametrosFuncionario(registro));
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public override bool Excluir(int id)
        {
            try
            {
                Log.log.Info($"Excluindo Funcionario{id}");

                Log.log.Debug($"SQL excluir pessoa fisica: {sqlExcluirFuncionario}");

                Db.Delete(sqlExcluirFuncionario, AdicionarParametro("ID", id));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteFuncionario, AdicionarParametro("ID", id));
        }

        public override Funcionario SelecionarPorId(int id)
        {
            Log.log.Info($"Selecionando Funcionario por id: {id}");

            Log.log.Debug($"SQL Selecionar Funcionario por id: {sqlSelecionarFuncionarioPorId}");

            return Db.Get(sqlSelecionarFuncionarioPorId, ConverterEmFuncionario, AdicionarParametro("ID", id));
        }

        public override List<Funcionario> SelecionarTodos()
        {
            Log.log.Info($"Selecionando Todos os Funcionarios");

            Log.log.Debug($"SQL Selecionar Todos os Funcionarios: {sqlSelecionarTodosFuncionarios}");

            return Db.GetAll(sqlSelecionarTodosFuncionarios, ConverterEmFuncionario);
        }

        public override Funcionario SelecionarPorNomeESenha(string nome, string senha)
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
