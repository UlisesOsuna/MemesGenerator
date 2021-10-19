CREATE TABLE [dbo].[tCategorias] (
    [IDCategoria] INT            IDENTITY (1, 1) NOT NULL,
    [Categoria]   NVARCHAR (100) CONSTRAINT [DF_tCategorias_Categoria] DEFAULT ('-') NULL,
    [EstaActivo]  BIT            CONSTRAINT [DF_tCategorias_EstaActivo] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_tCategorias] PRIMARY KEY CLUSTERED ([IDCategoria] ASC),
    CONSTRAINT [UNI_tCategorias] UNIQUE NONCLUSTERED ([Categoria] ASC)
);

