CREATE TABLE [dbo].[GrupoAutomovel] (
    [id]                                   INT          IDENTITY (1, 1) NOT NULL,
    [nome]                                 VARCHAR (50) NOT NULL,
    [planoDIario_precoDIa]                 FLOAT (53)   NOT NULL,
    [planoDiario_precoKm]                  FLOAT (53)   NOT NULL,
    [planoKmControlado_precoDia]           FLOAT (53)   NOT NULL,
    [planoKmControlado_precoKmExtrapolado] FLOAT (53)   NOT NULL,
    [planoKmControlado_KmDisponiveis]      FLOAT (53)   NOT NULL,
    [planoKmLivre_precoDia]                FLOAT (53)   NOT NULL,
    CONSTRAINT [PK_GrupoAutomoveis] PRIMARY KEY CLUSTERED ([id] ASC)
);

