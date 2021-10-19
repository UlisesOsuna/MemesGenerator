CREATE TABLE [dbo].[tUsuarios] (
    [IDUsuario]   INT            IDENTITY (1, 1) NOT NULL,
    [Usuario]     NVARCHAR (100) CONSTRAINT [DF_tUsuarios_Usuario] DEFAULT ('-') NULL,
    [Contrasenia] NVARCHAR (100) CONSTRAINT [DF_tUsuarios_Contrasenia] DEFAULT ('-') NULL,
    [EstaActivo]  BIT            CONSTRAINT [DF_tUsuarios_EstaActivo] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_tUsuarios] PRIMARY KEY CLUSTERED ([IDUsuario] ASC),
    CONSTRAINT [UNI_tUsuarios] UNIQUE NONCLUSTERED ([Usuario] ASC)
);

