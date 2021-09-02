CREATE TABLE [dbo].[PessoaJuridica] (
    [id]       INT          IDENTITY (1, 1) NOT NULL,
    [nome]     VARCHAR (50) NOT NULL,
    [cnpj]     VARCHAR (50) NOT NULL,
    [endereco] VARCHAR (50) NOT NULL,
    [telefone] VARCHAR (50) NOT NULL,
    [email] VARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_PessoaJuridica] PRIMARY KEY CLUSTERED ([id] ASC)
);

