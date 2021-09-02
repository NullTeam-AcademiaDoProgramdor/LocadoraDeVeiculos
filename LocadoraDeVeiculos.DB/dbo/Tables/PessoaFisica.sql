CREATE TABLE [dbo].[PessoaFisica] (
    [id]            INT          IDENTITY (1, 1) NOT NULL,
    [nome]          VARCHAR (50) NOT NULL,
    [cpf]           VARCHAR (50) NOT NULL,
    [rg]            VARCHAR (50) NOT NULL,
    [cnh]           VARCHAR (50) NOT NULL,
    [vencimentoCnh] VARCHAR (50) NOT NULL,
    [telefone]      VARCHAR (50) NOT NULL,
    [endereco]      VARCHAR (50) NOT NULL,
    [empresaLigada] INT          NULL,
    [email] VARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_PessoaFisica] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_PessoaFisica_PessoaJuridica] FOREIGN KEY ([empresaLigada]) REFERENCES [dbo].[PessoaJuridica] ([id]) ON DELETE SET NULL
);





