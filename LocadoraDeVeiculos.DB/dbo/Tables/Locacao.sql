CREATE TABLE [dbo].[Locacao] (
    [id]                          INT        IDENTITY (1, 1) NOT NULL,
    [condutor]                    INT        NOT NULL,
    [automovel]                   INT        NOT NULL,
    [dataSaida]                   DATETIME   NOT NULL,
    [dataDevolucaoEsperada]       DATETIME   NOT NULL,
    [dataDevolucao]               DATETIME   NULL,
    [caucao]                      FLOAT (53) NOT NULL,
    [funcionario]                 INT        NOT NULL,
    [kmRegistrada]                INT        NULL,
    [kmAutomovelFinal]            INT        NULL,
    [porcentagemFinalCombustivel] INT        NULL,
    [planoSelecionado]            INT        NOT NULL,
    [cupom]                       INT        NULL,
    CONSTRAINT [PK_Locacao] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Locacao_Automovel] FOREIGN KEY ([automovel]) REFERENCES [dbo].[Automovel] ([id]),
    CONSTRAINT [FK_Locacao_Cupom] FOREIGN KEY ([cupom]) REFERENCES [dbo].[Cupom] ([id]),
    CONSTRAINT [FK_Locacao_Funcionario] FOREIGN KEY ([funcionario]) REFERENCES [dbo].[Funcionario] ([id]),
    CONSTRAINT [FK_Locacao_PessoaFisica] FOREIGN KEY ([condutor]) REFERENCES [dbo].[PessoaFisica] ([id]) 
);





