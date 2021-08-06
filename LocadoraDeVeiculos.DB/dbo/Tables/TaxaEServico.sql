CREATE TABLE [dbo].[TaxaEServico] (
    [id]     INT          IDENTITY (1, 1) NOT NULL,
    [ehFixo] BIT          NOT NULL,
    [preco]  FLOAT (53)   NOT NULL,
    [nome]   VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_TaxaEServico] PRIMARY KEY CLUSTERED ([id] ASC)
);

