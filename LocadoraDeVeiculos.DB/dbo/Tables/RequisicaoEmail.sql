CREATE TABLE [dbo].[RequisicaoEmail]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [mensagem] VARCHAR(1000) NULL, 
    [emailDestino] VARCHAR(1000) NULL, 
    [nomePdf] VARCHAR(1000) NULL
)
