using LocadoraDeVeiculos.Controladores.Shared;
using LocadoraDeVeiculos.Dominio.PessoaFisicaModule;
using System;
using System.Collections.Generic;
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
                    CT.[NOME], 
                    CT.[CNPJ],
                    CT.[ENDERECO],                    
                    CT.[TELEFONE] 
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
                    CT.[NOME], 
                    CT.[CNPJ],
                    CT.[ENDERECO],                    
                    CT.[TELEFONE] 
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

        public override string Editar(int id, PessoaFisica registro)
        {
            throw new NotImplementedException();
        }

        public override bool Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Existe(int id)
        {
            throw new NotImplementedException();
        }

        public override string InserirNovo(PessoaFisica registro)
        {
            throw new NotImplementedException();
        }

        public override PessoaFisica SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public override List<PessoaFisica> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}
