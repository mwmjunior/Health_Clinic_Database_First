


-- Cria a stored procedure para inserir valores na tabela TiposDeUsuario
CREATE PROCEDURE InserirValoresEmTiposDeUsuario
AS
BEGIN
    -- Insere os valores iniciais
    INSERT INTO TiposDeUsuario (ID_TipoDeUsuario, Titulo)
    VALUES (NEWID(), 'Administrador'),
	        (NEWID(), 'Medico'), 
			(NEWID(), 'Paciente');

    PRINT 'Valores inseridos na tabela TiposDeUsuario com sucesso.';
END;

EXEC InserirValoresEmTiposDeUsuario;
SELECT * FROM TiposDeUsuario ;
--------------------------------------



-- Cria a stored procedure para inserir valores na tabela Especialidade
CREATE PROCEDURE InserirValoresEmEspecialidade
AS
BEGIN
    -- Insere os valores iniciais
    INSERT INTO Especialidade (ID_Especialidade, Especialidade_Medica)
    VALUES (NEWID(), 'Geriatra'), (NEWID(), 'Pediatra');

    PRINT 'Valores inseridos na tabela Especialidade com sucesso.';
END;

EXEC InserirValoresEmEspecialidade;
SELECT * FROM Especialidade ;
--------------------------------------


CREATE PROCEDURE InserirValoresEmClinica
AS
BEGIN
    -- Insere os valores iniciais
    INSERT INTO Clinica (ID_Clinica, Nome_Fantasia, Endereco, Numero, CEP, Razao_Social)
    VALUES 
        (NEWID(), 'Clinica Saude Integral', 'Rua Tenente Arthur Sprenger', 456, '82600340', 'Clinica Medica Vida e Saude Ltda');

    PRINT 'Valores inseridos na tabela Clinica com sucesso.';
END;

EXEC InserirValoresEmClinica;
SELECT * FROM  Clinica ;
--------------------------------------


-- Cria a stored procedure para inserir valores na tabela Usuario
CREATE PROCEDURE InserirValoresEmUsuario
AS
BEGIN
    -- Insere os valores iniciais
    INSERT INTO Usuario (ID_Usuario, ID_TipoDeUsuario, Nome, Email, Senha)
    VALUES 
        (NEWID(), 'D209FCC9-F2AC-4510-B380-8343AB0290D6', 'Paciente_01', 'paciente1@email.com', 'senha1'),
		(NEWID(), 'D209FCC9-F2AC-4510-B380-8343AB0290D6', 'Paciente_02', 'paciente2@email.com', 'senha2'),
		(NEWID(), '46CF1E5E-AC18-4014-931A-F2171231885D', 'Medico_01',   'medico1@email.com',   'senha3'),
		(NEWID(), '46CF1E5E-AC18-4014-931A-F2171231885D', 'Medico_02',   'medico2@email.com',   'senha4'),
        (NEWID(), 'BAEE496B-A243-4F24-83BD-42F810136F9B', 'Administrador', 'administrador@email.com', 'admin');

    PRINT 'Valores inseridos na tabela Usuario com sucesso.';
END;


EXEC InserirValoresEmUsuario;
SELECT * FROM  Usuario ;
--------------------------------------


-- Cria a stored procedure para inserir valores na tabela Paciente
CREATE PROCEDURE InserirValoresEmPaciente
AS
BEGIN
    -- Insere os valores iniciais
    INSERT INTO Paciente (ID_Paciente, ID_Usuario, Nome, CPF, RG, Data_de_Nascimento, Endereco, Numero_da_Residencia, Telefone, Sexo)
    VALUES 
        (NEWID(), '468CACC8-8496-490F-835C-830081FE8B4A', 'João da Silva', '12345678901', '123456789', '1990-01-15', 'Rua A, Bairro X', 123, '987654321', 'Masculino'),
        (NEWID(), '68FA748E-2154-4910-8D6F-E2D921F0EA53', 'Maria Oliveira', '98765432101', '987654321', '1985-05-25', 'Avenida B, Bairro Y', 456, '123456789', 'Feminino');

    PRINT 'Valores inseridos na tabela Paciente com sucesso.';
END;

EXEC InserirValoresEmPaciente;
SELECT * FROM  Paciente ;
--------------------------------------

-- Cria a stored procedure para inserir valores na tabela Medico
CREATE PROCEDURE InserirValoresEmMedico
AS
BEGIN
    -- Insere os valores iniciais
    INSERT INTO Medico (ID_Medico, ID_Usuario, Nome, CRM, ID_Clinica, ID_Especialidade)
    VALUES 
        (NEWID(), 'AF013551-090A-44F3-9C88-3276DD0BF013', 'Dr. João', '1234567', '47B10377-A24D-4150-8509-9B6B41E28406', '2771A316-B189-4B75-94D5-6A0C052A502F'),
        (NEWID(), 'EE9EF4DF-56DE-488C-B988-29D484F57C21', 'Dra. Maria', '9876543', '47B10377-A24D-4150-8509-9B6B41E28406', '912BCFDE-00C1-4632-9636-9ED346CBBE69');

    PRINT 'Valores inseridos na tabela Medico com sucesso.';
END;


EXEC InserirValoresEmMedico;
SELECT * FROM  Medico ;
--------------------------------------



-- Cria a stored procedure para inserir valores na tabela Consulta
CREATE PROCEDURE InserirValoresEmConsulta
AS
BEGIN
    -- Insere os valores iniciais
    INSERT INTO Consulta (ID_Consulta, ID_Medico, ID_Paciente, Data_da_Consulta, Horario_da_Consulta, Descricao, Feedback)
    VALUES 
        (NEWID(), '18EB330C-36AF-4529-98ED-425B7D2DEB8C', 'BA8BD114-6AE6-4A1A-B4A1-7725601A99EB', '2023-10-01 10:00:00', '10:00:00', 'Descrição da consulta 1', 'Bom relacionamento com paciente'),
        (NEWID(), 'C5BF694F-5732-4FD4-81D2-4D186DFEBE8B', '81C1FF02-771C-4F21-BAB9-B89EBFEBCB2C', '2023-10-02 14:30:00', '14:30:00', 'Descrição da consulta 2', 'Otimo atendimento');

    PRINT 'Valores inseridos na tabela Consulta com sucesso.';
END;

EXEC InserirValoresEmConsulta;
SELECT * FROM  Consulta ;
--------------------------------------

