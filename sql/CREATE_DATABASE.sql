Use EscuelaDB;

CREATE TABLE dbo.Maestros(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Apellido VARCHAR(50),
	Nombre VARCHAR(50),
	Numero_Documento INT
);

CREATE TABLE dbo.Estudiantes(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Apellido VARCHAR(50),
	Nombre VARCHAR(50),
	Numero_Documento INT,
	Legajo VARCHAR(20),
	Saldo FLOAT
);

CREATE TABLE dbo.Materias(
	Id INT PRIMARY KEY,
	Nombre VARCHAR(100)
);

CREATE TABLE dbo.Catedras(
	Id INT NOT NULL PRIMARY KEY,
	Materia INT,
	Turno CHAR,
	Dia VARCHAR(10),
	Horario VARCHAR(50),
	CONSTRAINT FK_Catedra_Materia FOREIGN KEY (Materia) REFERENCES dbo.Materias (Id)
);

CREATE TABLE dbo.Maestros_Catedras(
	Maestro INT,
	Catedra INT,
	CONSTRAINT PK_Maestro_Catedra  PRIMARY KEY CLUSTERED (Maestro,Catedra),
	CONSTRAINT FK_Maestro_Id FOREIGN KEY (Maestro) REFERENCES dbo.Maestros (Id),
	CONSTRAINT FK_Maestro_Catedra FOREIGN KEY (Catedra) REFERENCES dbo.Catedras (Id)
);

CREATE TABLE dbo.Cursadas(
	Catedra INT NOT NULL,
	Alumno INT NOT NULL,
	Fecha DATE,
	CONSTRAINT PK_Cursada PRIMARY KEY CLUSTERED (Catedra,Alumno),
	CONSTRAINT FK_Cursada_Catedra FOREIGN KEY (Catedra) REFERENCES dbo.Catedras (Id),
	CONSTRAINT FK_Alumno_Id FOREIGN KEY (Alumno) REFERENCES dbo.Estudiantes (Id)
);

CREATE TABLE dbo.Roles(
	Id INT NOT NULL PRIMARY KEY,
	Nombre VARCHAR(20) NOT NULL,
);

CREATE TABLE dbo.Logins(
	IdUsuario VARCHAR(20) PRIMARY KEY,
	Contrasena VARCHAR(50) NOT NULL,
	Nombre VARCHAR(50),
	Apellido VARCHAR(50),
	Email VARCHAR(100),
	IdRole INT NOT NULL,
	CONSTRAINT FK_Login_Role FOREIGN KEY (IdRole) REFERENCES dbo.Roles (Id)
);

/* Roles de Usuario */
INSERT INTO dbo.Roles (Id,Nombre) VALUES (1,'Administrador');
INSERT INTO dbo.Roles (Id,Nombre) VALUES (2,'Analista');
INSERT INTO dbo.Roles (Id,Nombre) VALUES (3,'Profesor');
INSERT INTO dbo.Roles (Id,Nombre) VALUES (4,'Alumno');

/* Logins */
INSERT INTO dbo.Logins (IdUsuario,Contrasena,Nombre,Apellido,Email,IdRole) VALUES ('admin','E99A18C428CB38D5F260853678922E03','System','','',1);