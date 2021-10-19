CREATE TABLE [dbo].[tUsuariosPermisos] (
    [IDPermiso]  INT           IDENTITY (1, 1) NOT NULL,
    [IDUsuario]  INT           NOT NULL,
    [Permiso]    NVARCHAR (50) CONSTRAINT [DF_tUsuariosPermisos_Permiso] DEFAULT ('-') NULL,
    [EstaActivo] BIT           CONSTRAINT [DF_tUsuariosPermisos_EstaActivo] DEFAULT ((1)) NULL,
    CONSTRAINT [PK_tUsuariosPermisos] PRIMARY KEY CLUSTERED ([IDPermiso] ASC),
    CONSTRAINT [FK_tUsuariosPermisos_IDUsuario] FOREIGN KEY ([IDUsuario]) REFERENCES [dbo].[tUsuarios] ([IDUsuario]),
    CONSTRAINT [UNI_tUsuariosPermisos] UNIQUE NONCLUSTERED ([IDUsuario] ASC, [Permiso] ASC)
);

