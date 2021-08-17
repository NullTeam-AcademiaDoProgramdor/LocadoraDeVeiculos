CREATE TABLE [dbo].[FotoAutomovel] (
    [id]        INT   IDENTITY (1, 1) NOT NULL,
    [foto]      IMAGE NOT NULL,
    [automovel] INT   NOT NULL,
    CONSTRAINT [PK_FotoAutomovel] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_FotoAutomovel_Automovel] FOREIGN KEY ([automovel]) REFERENCES [dbo].[Automovel] ([id]) ON DELETE CASCADE
);



