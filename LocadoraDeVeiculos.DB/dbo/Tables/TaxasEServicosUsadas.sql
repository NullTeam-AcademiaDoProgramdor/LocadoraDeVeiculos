CREATE TABLE [dbo].[TaxasEServicosUsadas] (
    [id]           INT IDENTITY (1, 1) NOT NULL,
    [taxaEServico] INT NOT NULL,
    [locacao]      INT NOT NULL,
    CONSTRAINT [PK_TaxasEServicosUsadas] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_TaxasEServicosUsadas_Locacao] FOREIGN KEY ([locacao]) REFERENCES [dbo].[Locacao] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_TaxasEServicosUsadas_TaxaEServico] FOREIGN KEY ([taxaEServico]) REFERENCES [dbo].[TaxaEServico] ([id]) ON DELETE CASCADE
);



