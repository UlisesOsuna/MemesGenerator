CREATE TABLE tCategorias(
	IDCategoria	INT			IDENTITY(1, 1)
	, Categoria	NVARCHAR(100)	CONSTRAINT DF_tCategorias_Categoria	DEFAULT('-')	NOT NULL		
	, EstaActivo	BIT			CONSTRAINT DF_tCategorias_EstaActivo	DEFAULT(1)	NOT NULL

	CONSTRAINT	PK_tCategorias		PRIMARY KEY	(IDCategoria)
	, CONSTRAINT	UNI_tCategorias	UNIQUE		(Categoria)
)

