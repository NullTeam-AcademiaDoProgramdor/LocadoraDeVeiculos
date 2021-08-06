CREATE TABLE [dbo].[Funcionario] (
    [nome]          VARCHAR (50) NOT NULL,
    [dataDeEntrada] DATETIME     NOT NULL,
    [salario]       FLOAT (53)   NOT NULL,
    [senha]         VARCHAR (50) NOT NULL,
    [id]            INT          IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_Funcionario] PRIMARY KEY CLUSTERED ([id] ASC)
);

