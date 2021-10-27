CREATE TABLE [dbo].[tUsuarios] (
    [IDUsuario]   INT            IDENTITY (1, 1) NOT NULL,
    [Usuario]     NVARCHAR (100) CONSTRAINT [DF_tUsuarios_Usuario] DEFAULT ('-') NOT NULL,
    [Contrasenia] NVARCHAR (MAX) CONSTRAINT [DF_tUsuarios_Contrasenia] DEFAULT ('-') NOT NULL,
    [Salt]        NVARCHAR (MAX) CONSTRAINT [DF_tUsuarios_Salt] DEFAULT ('-') NOT NULL,
    [EstaActivo]  BIT            CONSTRAINT [DF_tUsuarios_EstaActivo] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_tUsuarios] PRIMARY KEY CLUSTERED ([IDUsuario] ASC),
    CONSTRAINT [UNI_tUsuarios] UNIQUE NONCLUSTERED ([Usuario] ASC)
);



