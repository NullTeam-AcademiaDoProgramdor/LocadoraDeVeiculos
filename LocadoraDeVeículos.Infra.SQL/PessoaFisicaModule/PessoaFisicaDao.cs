using LocadoraDeVeiculos.Dominio.PessoaFisicaModule;
using LocadoraDeVeiculos.Dominio.PessoaJuridicaModule;
using LocadoraDeVeiculos.Dominio.Shared;
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

namespace LocadoraDeVeículos.Infra.SQL.PessoaFisicaModule
{
    public class PessoaFisicaDao : SQLDAOBase, IRepositorBase<PessoaFisica>
    {
        #region Queries
        private const string sqlInserirPessoaFisica =
            @"INSERT INTO [PessoaFisica]
                (       
                    [NOME], 
                    [CPF],
                    [RG],                    
                    [CNH],     
                    [VENCIMENTOCNH],     
                    [TELEFONE],     
                    [ENDERECO],     
                    [EMPRESALIGADA], 
                    [EMAIL]
                )
            VALUES
                (
                    @NOME,
                    @CPF,
                    @RG,
                    @CNH,
                    @VENCIMENTOCNH,
                    @TELEFONE,
                    @ENDERECO,
                    @EMPRESALIGADA, 
                    @EMAIL
                )";
        private const string sqlEditarPessoaFisica =
            @" UPDATE [PessoaFisica]
                SET 
                    [NOME] = @NOME, 
                    [CPF] = @CPF,
                    [RG] = @RG,                    
                    [CNH] = @CNH,     
                    [VENCIMENTOCNH] = @VENCIMENTOCNH,     
                    [TELEFONE] = @TELEFONE,     
                    [ENDERECO] = @ENDERECO,     
                    [EMPRESALIGADA] = @EMPRESALIGADA, 
                    [EMAIL] = @EMAIL
                WHERE [ID] = @ID";

        private const string sqlExcluirPessoaFisica =
            @"DELETE FROM [PESSOAFISICA] 
                WHERE [ID] = @ID";

        private const string sqlSelecionarTodasPessoasFisicas =
            @"SELECT 
                    CP.[ID],
                    CP.[NOME], 
                    CP.[CPF],
                    CP.[RG],                    
                    CP.[CNH],     
                    CP.[VENCIMENTOCNH],     
                    CP.[TELEFONE],     
                    CP.[ENDERECO],     
                    CP.[EMPRESALIGADA],
                    CP.[EMAIL],
                    CT.[NOME] as [NOMEPJ], 
                    CT.[CNPJ],
                    CT.[ENDERECO] as [ENDERECOPJ],                    
                    CT.[TELEFONE] as [TELEFONEPJ],
                    CT.[EMAIL] as [EMAILPJ]
            FROM
                [PESSOAFISICA] AS CP LEFT JOIN 
                [PESSOAJURIDICA] AS CT
            ON
                CT.ID = CP.EMPRESALIGADA";

        private const string sqlSelecionarPessoaFisicaPorId =
            @"SELECT 
                    CP.[ID],
                    CP.[NOME], 
                    CP.[CPF],
                    CP.[RG],                    
                    CP.[CNH],     
                    CP.[VENCIMENTOCNH],     
                    CP.[TELEFONE],     
                    CP.[ENDERECO],     
                    CP.[EMPRESALIGADA],
                    CP.[EMAIL],
                    CT.[NOME] as [NOMEPJ], 
                    CT.[CNPJ],
                    CT.[ENDERECO] as [ENDERECOPJ],                    
                    CT.[TELEFONE] as [TELEFONEPJ],
                    CT.[EMAIL] as [EMAILPJ]
            FROM
                [PESSOAFISICA] AS CP LEFT JOIN 
                [PESSOAJURIDICA] AS CT
            ON
                CT.ID = CP.EMPRESALIGADA
            WHERE 
                CP.[ID] = @ID";

        private const string sqlExistePessoaFisica =
            @"SELECT 
                COUNT(*) 
            FROM 
                [PESSOAFISICA]
            WHERE 
                [ID] = @ID";

        #endregion   

        public bool InserirNovo(PessoaFisica registro)
        {
            Serilog.Log.Logger.Aqui().Information($"Inserindo Pessoa Fisica [{registro.Nome}]");

            Serilog.Log.Debug($"SQL inserir pessoa fisica: {sqlInserirPessoaFisica}");

            registro.Id = Db.Insert(sqlInserirPessoaFisica, ObtemParametrosPessoaFisica(registro));
            return registro.Id != 0;
        }

        public bool Editar(int id, PessoaFisica registro)
        {
            try
            {
                Serilog.Log.Logger.Aqui().Information($"Editando Pessoa Fisica [{registro.Nome}]:{id}");

                Serilog.Log.Debug($"SQL editar pessoa fisica: {sqlEditarPessoaFisica}");

                registro.Id = id;
                Db.Update(sqlEditarPessoaFisica, ObtemParametrosPessoaFisica(registro));
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
                Serilog.Log.Logger.Aqui().Information($"Excluindo Pessoa Fisica {id}");

                Serilog.Log.Debug($"SQL excluir pessoa fisica: {sqlExcluirPessoaFisica}");

                Db.Delete(sqlExcluirPessoaFisica, AdicionarParametro("ID", id));
                return true;
            }
            catch(Exception e)
            {
                Serilog.Log.Error(e, e.Message + $"\nID: {id}");
                return false;
            }
        }

        public bool Existe(int id)
        {
            return Db.Exists(sqlExistePessoaFisica, AdicionarParametro("ID", id));
        }    

        public PessoaFisica SelecionarPorId(int id)
        {
            Serilog.Log.Logger.Aqui().Information($"Selecionando Pessoa Fisica por id: {id}");

            Serilog.Log.Debug($"SQL Selecionar pessoa fisica por id: {sqlSelecionarPessoaFisicaPorId}");

            return Db.Get(sqlSelecionarPessoaFisicaPorId, ConverterEmPessoaFisica, AdicionarParametro("ID", id));
        }

        public List<PessoaFisica> SelecionarTodos()
        {
            Serilog.Log.Logger.Aqui().Information($"Selecionando Pessoa Fisica todas as pessoas fisicas");

            Serilog.Log.Debug($"SQL Selecionar todas as pessoas fisicas: {sqlSelecionarTodasPessoasFisicas}");

            return Db.GetAll(sqlSelecionarTodasPessoasFisicas, ConverterEmPessoaFisica);
        }

        private PessoaFisica ConverterEmPessoaFisica(IDataReader reader)
        {
            var nome = Convert.ToString(reader["NOME"]);
            var CPF = Convert.ToString(reader["CPF"]);
            var RG = Convert.ToString(reader["RG"]);
            var CNH = Convert.ToString(reader["CNH"]);
            var vencimentoCnh = Convert.ToDateTime(reader["VENCIMENTOCNH"]);
            var telefone = Convert.ToString(reader["TELEFONE"]);
            var endereco = Convert.ToString(reader["ENDERECO"]);
            var email = Convert.ToString(reader["EMAIL"]);

            var nomePJuridica = Convert.ToString(reader["NOMEPJ"]);
            var CNPJ = Convert.ToString(reader["CNPJ"]);
            var enderecoPJuridica = Convert.ToString(reader["ENDERECOPJ"]);
            var telefonePJuridica = Convert.ToString(reader["TELEFONEPJ"]);
            var emailPJuridica = Convert.ToString(reader["EMAILPJ"]);

            PessoaJuridica pJuridica = null;
            if (reader["EMPRESALIGADA"] != DBNull.Value)
            {
                pJuridica = new PessoaJuridica(nomePJuridica, CNPJ, telefonePJuridica, enderecoPJuridica, emailPJuridica);
                pJuridica.Id = Convert.ToInt32(reader["EMPRESALIGADA"]);
            }

            PessoaFisica pessoaFisica = new PessoaFisica(nome, CPF, RG, CNH, vencimentoCnh, telefone, endereco, pJuridica, email);
            pessoaFisica.Id = Convert.ToInt32(reader["ID"]);

            return pessoaFisica;
        }

        private Dictionary<string, object> ObtemParametrosPessoaFisica(PessoaFisica pessoaFisica)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", pessoaFisica.Id);
            parametros.Add("NOME", pessoaFisica.Nome);
            parametros.Add("CPF", pessoaFisica.CPF);
            parametros.Add("RG", pessoaFisica.RG);
            parametros.Add("CNH", pessoaFisica.CNH);
            parametros.Add("VENCIMENTOCNH", pessoaFisica.VencimentoCNH);
            parametros.Add("TELEFONE", pessoaFisica.Telefone);
            parametros.Add("ENDERECO", pessoaFisica.Endereco);
            parametros.Add("EMAIL", pessoaFisica.Email);
            parametros.Add("EMPRESALIGADA", pessoaFisica.PessoaJuridica?.Id);

            return parametros;
        }
    }
}
