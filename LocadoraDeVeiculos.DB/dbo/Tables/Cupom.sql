CREATE TABLE [dbo].[Cupom] (
    [id]             INT           NOT NULL IDENTITY,
    [codigo]         VARCHAR (100) NOT NULL,
    [parceiro]       INT           NOT NULL,
    [tipo]           VARCHAR (50)  NOT NULL,
    [valor]          FLOAT (53)    NOT NULL,
    [valorMinimo]    FLOAT (53)    NOT NULL,
    [dataVencimento] DATETIME      NOT NULL,
    [qtdUsos]        INT           NOT NULL,
    CONSTRAINT [PK_Cupom] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Cupom_Parceiro] FOREIGN KEY ([parceiro]) REFERENCES [dbo].[Parceiro] ([id]) ON DELETE CASCADE
);



