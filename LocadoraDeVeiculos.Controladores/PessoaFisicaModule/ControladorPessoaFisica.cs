using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.PessoaFisicaModule;
using LocadoraDeVeiculos.Dominio.PessoaJuridicaModule;
using LocadoraDeVeiculos.Dominio.LocacaoModule;
using LocadoraDeVeiculos.Controladores.LocacaoModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.Controladores.PessoaFisicaModule
{
    public class ControladorPessoaFisica : Controlador<PessoaFisica>
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

        public override string InserirNovo(PessoaFisica registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirPessoaFisica, ObtemParametrosPessoaFisica(registro));
            }

            return resultadoValidacao;
        }


        public override string Editar(int id, PessoaFisica registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarPessoaFisica, ObtemParametrosPessoaFisica(registro));
            }

            return resultadoValidacao;
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirPessoaFisica, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExistePessoaFisica, AdicionarParametro("ID", id));
        }

        public override PessoaFisica SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarPessoaFisicaPorId, ConverterEmPessoaFisica, AdicionarParametro("ID", id));
        }

        public override List<PessoaFisica> SelecionarTodos()
        {
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