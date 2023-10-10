          -- DDL Database Definition Language --

-- Criar o banco de dados a ser utilizado
CREATE DATABASE Health_Clinic;

GO

-- Seleciona o banco de dados que foi criado
USE Health_Clinic;

GO

-- Cria as tabelas do tipos de usuario
CREATE TABLE TiposDeUsuario
	(
	ID_TipoDeUsuario UNIQUEIDENTIFIER PRIMARY KEY,
	Titulo VARCHAR (100) NOT NULL,
	);

GO

-- Cria as tabelas do banco de dados
CREATE TABLE Usuario
	(
	ID_Usuario UNIQUEIDENTIFIER PRIMARY KEY ,
	ID_TipoDeUsuario UNIQUEIDENTIFIER FOREIGN KEY REFERENCES TiposDeUsuario(ID_TipoDeUsuario) NOT NULL,
	Nome VARCHAR(50) NOT NULL UNIQUE,
	Email VARCHAR(200) NOT NULL UNIQUE,
	Senha VARCHAR(200) NOT NULL			
	);

GO

CREATE TABLE Paciente	
	(
	ID_Paciente UNIQUEIDENTIFIER  PRIMARY KEY ,
	ID_Usuario UNIQUEIDENTIFIER  FOREIGN KEY REFERENCES Usuario(ID_Usuario) NOT NULL,
	Nome VARCHAR(200) NOT NULL,
	CPF CHAR(11) UNIQUE NOT NULL ,
	RG CHAR(9) UNIQUE NOT NULL,
	Data_de_Nascimento DATE NOT NULL,
	Endereco VARCHAR(200) NOT NULL,
	Numero_da_Residencia INT NOT NULL,
	Telefone CHAR(11) NOT NULL,
	Sexo VARCHAR(200) NOT NULL
	);

GO 

CREATE TABLE Especialidade	
	(
	ID_Especialidade UNIQUEIDENTIFIER PRIMARY KEY ,
	Especialidade_Medica VARCHAR(200) NOT NULL
	);

GO

CREATE TABLE Clinica
	(
    ID_Clinica UNIQUEIDENTIFIER  PRIMARY KEY,
    Nome_Fantasia VARCHAR(200) UNIQUE NOT NULL,
    Endereco VARCHAR(250) NOT NULL,
    Numero INT NOT NULL,
    CEP CHAR(8) UNIQUE NOT NULL,
    Razao_Social VARCHAR(200) UNIQUE NOT NULL    
	);

GO 

CREATE TABLE Medico
	(
	ID_Medico UNIQUEIDENTIFIER  PRIMARY KEY ,
	ID_Usuario UNIQUEIDENTIFIER  FOREIGN KEY REFERENCES Usuario(ID_Usuario) NOT NULL,
	Nome VARCHAR(200) NOT NULL,
	CRM CHAR(7) NOT NULL,
	ID_Clinica UNIQUEIDENTIFIER  FOREIGN KEY REFERENCES Clinica(ID_Clinica) ,
	ID_Especialidade UNIQUEIDENTIFIER  FOREIGN KEY REFERENCES Especialidade(ID_Especialidade) 
	);

GO 

CREATE TABLE [Consulta]
	(
    ID_Consulta UNIQUEIDENTIFIER  PRIMARY KEY ,
    ID_Medico UNIQUEIDENTIFIER  FOREIGN KEY REFERENCES Medico(ID_Medico) NOT NULL,
    ID_Paciente UNIQUEIDENTIFIER  FOREIGN KEY REFERENCES Paciente(ID_Paciente) NOT NULL,
    Data_da_Consulta DATE NOT NULL,
	Horario_da_Consulta TIME NOT NULL,
	Descricao TEXT,
	Feedback  TEXT
	);


