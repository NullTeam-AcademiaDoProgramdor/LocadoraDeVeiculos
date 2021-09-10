using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.PessoaJuridicaModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Controladores.PessoaJuridicaModule
{
    public class ControladorPessoaJuridica : Controlador<PessoaJuridica>
    {
        #region Queries
        private const string sqlInserirPessoaJuridica =
            @"INSERT INTO [PESSOAJURIDICA]
                (       
                    [NOME], 
                    [CNPJ],
                    [ENDERECO],                    
                    [TELEFONE],         
                    [EMAIL]         
                )
            VALUES
                (
                    @NOME,
                    @CNPJ,
                    @ENDERECO,
                    @TELEFONE,         
                    @EMAIL
                )";

        private const string sqlEditarPessoaJuridica =
            @" UPDATE [PESSOAJURIDICA]
                SET 
                    [NOME] = @NOME, 
                    [CNPJ] = @CNPJ, 
                    [ENDERECO] = @ENDERECO,
                    [TELEFONE] = @TELEFONE,         
                    [EMAIL] = @EMAIL
                WHERE [ID] = @ID";

        private const string sqlExcluirPessoaJuridica =
            @"DELETE FROM [PESSOAJURIDICA] 
                WHERE [ID] = @ID";

        private const string sqlSelecionarPessoaJuridicaPorId =
            @"SELECT
                    [ID],
		            [NOME], 
		            [CNPJ], 
		            [ENDERECO],
                    [TELEFONE],         
                    [EMAIL]   
	            FROM
                    PESSOAJURIDICA
                WHERE 
                    ID = @ID";

        private const string sqlSelecionarTodosPessoasJuridicas =
            @"SELECT
                    [ID],
		            [NOME], 
		            [CNPJ], 
		            [ENDERECO],
                    [TELEFONE],         
                    [EMAIL]   
	            FROM
                    PESSOAJURIDICA";

        private const string sqlExistePessoaJuridica =
            @"SELECT 
                COUNT(*) 
            FROM 
                [PESSOAJURIDICA]
            WHERE 
                [ID] = @ID";

        #endregion

        public override string InserirNovo(PessoaJuridica registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirPessoaJuridica, ObtemParametrosPessoaJuridica(registro));
            }

            return resultadoValidacao;
        }

        public override string Editar(int id, PessoaJuridica registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarPessoaJuridica, ObtemParametrosPessoaJuridica(registro));
            }

            return resultadoValidacao;
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirPessoaJuridica, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExistePessoaJuridica, AdicionarParametro("ID", id));
        }


        public override PessoaJuridica SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarPessoaJuridicaPorId, ConverterEmPessoaJuridica, AdicionarParametro("ID", id));
        }

        public override List<PessoaJuridica> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosPessoasJuridicas, ConverterEmPessoaJuridica);
        }

        private Dictionary<string, object> ObtemParametrosPessoaJuridica(PessoaJuridica pessoaJuridica)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", pessoaJuridica.Id);
            parametros.Add("NOME", pessoaJuridica.Nome);
            parametros.Add("CNPJ", pessoaJuridica.Cnpj);
            parametros.Add("ENDERECO", pessoaJuridica.Endereco);
            parametros.Add("TELEFONE", pessoaJuridica.Telefone);
            parametros.Add("EMAIL", pessoaJuridica.Email);

            return parametros;
        }

        private PessoaJuridica ConverterEmPessoaJuridica(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string nome = Convert.ToString(reader["NOME"]);
            string cnpj = Convert.ToString(reader["CNPJ"]);
            string endereco = Convert.ToString(reader["ENDERECO"]);
            string telefone = Convert.ToString(reader["TELEFONE"]);
            string email = Convert.ToString(reader["EMAIL"]);

            PessoaJuridica pessoaJuridica = new PessoaJuridica(nome, cnpj, telefone, endereco, email);

            pessoaJuridica.Id = id;

            return pessoaJuridica;
        }
    }
}