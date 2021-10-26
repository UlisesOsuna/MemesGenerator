CREATE TABLE [dbo].[tImagenes] (
    [IDImagen]    INT            IDENTITY (1, 1) NOT NULL,
    [Hash]        NVARCHAR (50)  CONSTRAINT [DF_tImagenes_Hash] DEFAULT ('-') NOT NULL,
    [Descripcion] NVARCHAR (100) CONSTRAINT [DF_tImagenes_Descripcion] DEFAULT ('-') NOT NULL,
    [Base64]      VARCHAR (MAX)  CONSTRAINT [DF_tImagenes_Base64] DEFAULT ('-') NOT NULL,
    [IDCategoria] INT            CONSTRAINT [DF_tImagenes_IDCategoria] DEFAULT ((0)) NOT NULL,
    [EstaActivo]  BIT            CONSTRAINT [DF_tImagenes_EstaActivo] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_tImagenes] PRIMARY KEY CLUSTERED ([IDImagen] ASC),
    CONSTRAINT [FK_tImagenes_IDCategoria] FOREIGN KEY ([IDCategoria]) REFERENCES [dbo].[tCategorias] ([IDCategoria]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [UNI_tImagenes] UNIQUE NONCLUSTERED ([Hash] ASC)
);


GO