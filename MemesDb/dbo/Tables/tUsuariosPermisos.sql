CREATE TABLE tUsuariosPermisos(
	IDPermiso		INT			IDENTITY(1, 1)
	, IDUsuario	INT			CONSTRAINT DF_tUsuariosPermisos_IDUsuario	DEFAULT(0)	NOT NULL
	, Permiso		NVARCHAR(50)	CONSTRAINT DF_tUsuariosPermisos_Permiso		DEFAULT('-')	NOT NULL
	, EstaActivo	BIT			CONSTRAINT DF_tUsuariosPermisos_EstaActivo	DEFAULT(1)	NOT NULL

	CONSTRAINT	PK_tUsuariosPermisos			PRIMARY KEY	(IDPermiso)
	, CONSTRAINT	UNI_tUsuariosPermisos			UNIQUE		(IDUsuario, Permiso)
	, CONSTRAINT	FK_tUsuariosPermisos_IDUsuario
	FOREIGN KEY(IDUsuario) REFERENCES tUsuarios(IDUsuario)
	ON UPDATE CASCADE
	ON DELETE CASCADE
)