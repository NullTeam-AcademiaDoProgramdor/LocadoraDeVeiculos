﻿using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.PessoaFisicaModule;
using LocadoraDeVeiculos.Dominio.PessoaJuridicaModule;
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
                    [ID_EMPRESALIGADA] 
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
                    @ID_EMPRESALIGADA
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
                    [ID_EMPRESALIGADA] = @ID_EMPRESALIGADA

                WHERE [ID] = @ID";

        private const string sqlExcluirPessoaFisica =
            @"DELETE FROM [PessoaFisica] 
                WHERE [ID] = @ID";

        private const string sqlSelecionarTodasPessoasFisicas =
            @"SELECT 
                    CP.[NOME], 
                    CP.[CPF],
                    CP.[RG],                    
                    CP.[CNH],     
                    CP.[VENCIMENTOCNH],     
                    CP.[TELEFONE],     
                    CP.[ENDERECO],     
                    CP.[ID_EMPRESALIGADA],
                    CT.[NOMEPJ], 
                    CT.[CNPJ],
                    CT.[ENDERECOPJ],                    
                    CT.[TELEFONEPJ] 
            FROM
                [PessoaFisica] AS CP LEFT JOIN 
                [PessoaJuridica] AS CT
            ON
                CT.ID = CP.ID_EMPRESALIGADA";

        private const string sqlSelecionarPessoaFisicaPorId =
            @"SELECT 
                    CP.[NOME], 
                    CP.[CPF],
                    CP.[RG],                    
                    CP.[CNH],     
                    CP.[VENCIMENTOCNH],     
                    CP.[TELEFONE],     
                    CP.[ENDERECO],     
                    CP.[ID_EMPRESALIGADA],
                    CT.[NOMEPJ], 
                    CT.[CNPJ],
                    CT.[ENDERECOPJ],                    
                    CT.[TELEFONEPJ] 
            FROM
                [PessoaFisica] AS CP LEFT JOIN 
                [PessoaJuridica] AS CT
            ON
                CT.ID = CP.ID_EMPRESALIGADA
            WHERE 
                CP.[ID] = @ID";

        private const string sqlExistePessoaFisica =
            @"SELECT 
                COUNT(*) 
            FROM 
                [PessoaFisica]
            WHERE 
                [ID] = @ID";

        #endregion

        public override string InserirNovo(PessoaFisica registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirPessoaFisica, ObtemParametrosPessoaJuridica(registro));
            }

            return resultadoValidacao;
        }


        public override string Editar(int id, PessoaFisica registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarPessoaFisica, ObtemParametrosPessoaJuridica(registro));
            }

            return resultadoValidacao;
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExistePessoaFisica, AdicionarParametro("ID", id));
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
            var vencimentoCnh = Convert.ToDateTime(reader["HORATERMINO"]);
            var telefone = Convert.ToString(reader["TELEFONE"]);
            var endereco = Convert.ToString(reader["ENDERECO"]);

            var nomePJuridica = Convert.ToString(reader["NOMEPJ"]);
            var CNPJ = Convert.ToString(reader["CNPJ"]);
            var enderecoPJuridica = Convert.ToString(reader["ENDERECOPJ"]);
            var telefonePJuridica = Convert.ToString(reader["TELEFONEPJ"]);

            PessoaJuridica pJuridica = null;
            if (reader["ID_EMPRESALIGADA"] != DBNull.Value)
            {
                pJuridica = new PessoaJuridica(nomePJuridica, CNPJ, telefonePJuridica, enderecoPJuridica);
                pJuridica.Id = Convert.ToInt32(reader["ID_EMPRESALIGADA"]);
            }

            PessoaFisica pessoaFisica = new PessoaFisica(nome, CPF, RG, CNH, vencimentoCnh, telefone, endereco, pJuridica);
            pessoaFisica.Id = Convert.ToInt32(reader["ID"]);

            return pessoaFisica;
        }

        private Dictionary<string, object> ObtemParametrosPessoaJuridica(PessoaFisica pessoaFisica)
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
            parametros.Add("ID_EMPRESALIGADA", pessoaFisica.PessoaJuridica?.Id);

            return parametros;
        }
    }
}
