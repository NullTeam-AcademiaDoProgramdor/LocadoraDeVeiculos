CREATE TABLE [dbo].[Automovel] (
    [id]                   INT          IDENTITY (1, 1) NOT NULL,
    [placa]                VARCHAR (50) NOT NULL,
    [chassi]               VARCHAR (50) NOT NULL,
    [marca]                VARCHAR (50) NOT NULL,
    [cor]                  VARCHAR (50) NOT NULL,
    [modelo]               VARCHAR (50) NOT NULL,
    [tipoCombustivel]      VARCHAR (50) NOT NULL,
    [capacidadeTanque]     FLOAT (53)   NOT NULL,
    [ano]                  INT          NOT NULL,
    [capacidadePortaMalas] FLOAT (53)   NOT NULL,
    [n_portas]             INT          NOT NULL,
    [cambio]               VARCHAR (50) NOT NULL,
    [grupo]                INT          NOT NULL,
    [direcao]              VARCHAR (50) NOT NULL,
    [kmRegistrada]         INT          NULL, 
    CONSTRAINT [PK_Automovel] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Automovel_GrupoAutomoveis] FOREIGN KEY ([grupo]) REFERENCES [dbo].[GrupoAutomovel] ([id]) ON DELETE CASCADE
);





