CREATE TABLE tUsuarios(
	IDUsuario		INT			IDENTITY(1, 1)
	, Usuario		NVARCHAR(100)	CONSTRAINT DF_tUsuarios_Usuario		DEFAULT('-')	NOT NULL
	, Contrasenia	NVARCHAR(100)	CONSTRAINT DF_tUsuarios_Contrasenia	DEFAULT('-')	NOT NULL
	, EstaActivo	BIT			CONSTRAINT DF_tUsuarios_EstaActivo		DEFAULT(1)	NOT NULL

	CONSTRAINT	PK_tUsuarios		PRIMARY KEY	(IDUsuario)
	, CONSTRAINT	UNI_tUsuarios		UNIQUE		(Usuario)
)

