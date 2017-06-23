CREATE DATABASE CarControl
GO
USE CarControl
GO
CREATE TABLE usuario (
login_usuario VARCHAR(50) PRIMARY KEY,
senha_usuario VARCHAR(30) not null
)
go
create procedure sp_login
	 @p_login VARCHAR(50)
	,@p_senha VARCHAR(30)
as
begin
	select * from usuario where @p_login = login_usuario AND @p_senha = senha_usuario
end
go

create procedure sp_Select_usuario
as
begin
	select * from usuario
end
go

create procedure sp_Insert_usuario
	 @p_login VARCHAR(50)
	,@p_senha VARCHAR(30)
as
begin
	Insert Into usuario (login_usuario, senha_usuario)
	Values(@p_login, @p_senha)
end
go


create procedure sp_Update_usuario
	 @p_login VARCHAR(50)
	,@p_senha VARCHAR(30)
as
begin
	update usuario
	set senha_usuario = @p_senha where login_usuario = @p_login
end
go


create procedure sp_Delete_usuario
	 @p_login VARCHAR(50)
as
begin
	Delete from usuario where login_usuario = @p_login 
end
go

CREATE TABLE cliente (
id_cliente INT PRIMARY KEY IDENTITY,
nome_cliente VARCHAR(30),
CPF_cliente CHAR(12),
telefone_cliente CHAR(13),
especificacao_cliente CHAR(1)
)
GO
create procedure sp_select_Cliente
as
begin
	select * from cliente
end
go

create procedure sp_Insert_Cliente
	
	@p_nome_cliente VARCHAR(30),
	@p_CPF_cliente CHAR(12),
	@p_telefone_cliente CHAR(13),
	@p_especificacao_cliente CHAR(1)

as
begin
	insert into cliente (nome_cliente, CPF_cliente, telefone_cliente, especificacao_cliente)
	Values(@p_nome_cliente, @p_CPF_cliente, @p_telefone_cliente, @p_especificacao_cliente)
end
go

create procedure sp_Update_Cliente
	
	@p_id_cliente INT,
	@p_nome_cliente VARCHAR(30),
	@p_CPF_cliente CHAR(12),
	@p_telefone_cliente CHAR(13),
	@p_especificacao_cliente CHAR(1)

as
begin
	Update cliente
	set nome_cliente = @p_nome_cliente, CPF_cliente = @p_CPF_cliente, telefone_cliente = @p_telefone_cliente, especificacao_cliente = @p_especificacao_cliente
	where id_cliente = @p_id_cliente
end
go

create procedure sp_Delete_Cliente
	
	@id_cliente INT
as
begin
	delete from cliente where id_cliente = @id_cliente
end
go

CREATE TABLE veiculo (
id_veiculos INT PRIMARY KEY IDENTITY,
marca_veiculo VARCHAR(30),
modelo_veiculo  VARCHAR(30),
placa_veiculo CHAR(9),
id_cliente INT,
CONSTRAINT fk_id_cliente FOREIGN KEY (id_cliente) REFERENCES cliente(id_cliente)
)
GO
create procedure sp_select_Veiculo
as
begin
	select veiculo.id_veiculos, veiculo.marca_veiculo, veiculo.modelo_veiculo, veiculo.placa_veiculo, cliente.nome_cliente, cliente.id_cliente from veiculo inner join cliente on
	cliente.id_cliente = veiculo.id_cliente
end
go

CREATE PROCEDURE sp_select_Veiculo_by_id
	@p_id_cliente INT
AS
BEGIN
	SELECT id_veiculos, placa_veiculo FROM veiculo 
	WHERE id_cliente = @p_id_cliente
END
GO

CREATE PROCEDURE sp_insert_veiculo
	
	
	@p_marca_veiculo		VARCHAR(30),
	@p_modelo_veiculo		VARCHAR(30),
	@p_placa_veiculo		CHAR(9),
	@p_id_cliente		INT

AS 
BEGIN
	INSERT INTO veiculo(marca_veiculo,modelo_veiculo,placa_veiculo,id_cliente)
	VALUES( @p_marca_veiculo, @p_modelo_veiculo, @p_placa_veiculo,@p_id_cliente)
END
GO

CREATE PROCEDURE sp_update_veiculo
	
	@p_id_veiculos			INT,
	@p_marca_veiculo		VARCHAR(30),
	@p_modelo_veiculo		VARCHAR(30),
	@p_placa_veiculo		CHAR(9),
	@p_id_cliente		INT

AS
BEGIN
	UPDATE veiculo
	SET marca_veiculo = @p_marca_veiculo, modelo_veiculo = @p_modelo_veiculo, placa_veiculo = @p_placa_veiculo, id_cliente = @p_id_cliente
	WHERE id_veiculos = @p_id_veiculos
END
GO

CREATE PROCEDURE sp_delete_veiculo
	
	@p_id_veiculos INT
AS
BEGIN
	DELETE FROM veiculo where id_veiculos = @p_id_veiculos
END
GO

CREATE TABLE tipo_vaga
(
	id_tipo_vaga		INT PRIMARY KEY IDENTITY(1,1),
	nome_tipo_vaga		VARCHAR(30) NOT NULL,
	preco_mensalista		DECIMAL(5,2) NOT NULL,
	preco_horista		DECIMAL(5,2) NOT NULL
)
GO

CREATE PROCEDURE sp_select_tipo_vaga
AS
BEGIN
	SELECT * FROM tipo_vaga
END
GO

CREATE PROCEDURE sp_select_horista
@p_id_tipo_vaga INT
AS
BEGIN
	SELECT preco_horista FROM tipo_vaga WHERE id_tipo_vaga = @p_id_tipo_vaga
END
GO

CREATE PROCEDURE sp_select_mensalista
@p_id_tipo_vaga INT
AS
BEGIN
	SELECT preco_mensalista FROM tipo_vaga WHERE id_tipo_vaga = @p_id_tipo_vaga
END
GO

CREATE PROCEDURE sp_select_tipo_vaga2
AS
BEGIN
	SELECT id_tipo_vaga, nome_tipo_vaga FROM tipo_vaga
END
GO

CREATE PROCEDURE sp_insert_tipo_vaga
	
	@p_nome_tipo_vaga		VARCHAR(30),
	@p_preco_mensalista		DECIMAL(5,2),
	@p_preco_horista		DECIMAL(5,2) 

AS 
BEGIN
	INSERT INTO tipo_vaga(nome_tipo_vaga,preco_mensalista,preco_horista)
	VALUES(@p_nome_tipo_vaga,@p_preco_mensalista,@p_preco_horista)
END
GO

CREATE PROCEDURE sp_update_tipo_vaga
	
	@p_id_tipo_vaga INT,
	@p_nome_tipo_vaga		VARCHAR(30),
	@p_preco_mensalista		DECIMAL(5,2),
	@p_preco_horista		DECIMAL(5,2) 

AS
BEGIN
	UPDATE tipo_vaga
	SET nome_tipo_vaga= @p_nome_tipo_vaga,preco_mensalista= @p_preco_mensalista, preco_horista= @p_preco_horista
	WHERE id_tipo_vaga = @p_id_tipo_vaga
END
GO

CREATE PROCEDURE sp_delete_tipo_vaga
	
	@p_id_tipo_vaga INT
AS
BEGIN
	DELETE FROM tipo_vaga where id_tipo_vaga = @p_id_tipo_vaga
END
GO

CREATE TABLE vaga
(
	id_vaga				INT PRIMARY KEY IDENTITY(1,1),
	id_cliente			INT,
	id_veiculos			INT,
	id_tipo_vaga		INT,
	ocupado				CHAR(1) NOT NULL,
	andar				VARCHAR(5) NOT NULL,
	bloco				VARCHAR(20) NOT NULL,
	numero_vaga			VARCHAR(10) NOT NULL,
	data_entrada       DATETIME NOT NULL,

	CONSTRAINT fk_vaga_cliente FOREIGN KEY (id_cliente)
	REFERENCES cliente (id_cliente),

	CONSTRAINT fk_vaga_tipo_vaga FOREIGN KEY (id_tipo_vaga)
	REFERENCES tipo_vaga (id_tipo_vaga),

	CONSTRAINT fk_vaga_veiculos FOREIGN KEY (id_veiculos)
	REFERENCES veiculo (id_veiculos),
)
GO

CREATE PROCEDURE sp_select_vaga
AS
BEGIN
	SELECT vaga.id_vaga, vaga.numero_vaga, vaga.ocupado, vaga.andar, vaga.bloco, veiculo.id_veiculos, veiculo.modelo_veiculo, veiculo.marca_veiculo, veiculo.placa_veiculo, cliente.id_cliente, cliente.nome_cliente, cliente.especificacao_cliente, tipo_vaga.id_tipo_vaga, tipo_vaga.nome_tipo_vaga, vaga.data_entrada FROM vaga 
	inner join veiculo on veiculo.id_veiculos = vaga.id_veiculos
	inner join cliente on cliente.id_cliente = vaga.id_cliente
	inner join tipo_vaga on tipo_vaga.id_tipo_vaga = vaga.id_tipo_vaga
END
GO

CREATE PROCEDURE sp_insert_vaga
	@p_numero_vaga VARCHAR,
	@p_bloco VARCHAR,
	@p_andar VARCHAR,
	@p_ocupado CHAR,
	@p_id_cliente int,
	@p_id_veiculos int,
	@p_id_tipo_vaga int
AS
BEGIN
	INSERT INTO vaga(numero_vaga, bloco, andar, ocupado, id_cliente, id_veiculos, id_tipo_vaga, data_entrada)
	VALUES(@p_numero_vaga, @p_bloco, @p_andar, @p_ocupado, @p_id_cliente, @p_id_veiculos, @p_id_tipo_vaga, GETDATE())
END
GO


CREATE PROCEDURE sp_ocupar_vaga
	@p_id_vaga INT,
	@p_numero_vaga VARCHAR,
	@p_bloco VARCHAR,
	@p_andar VARCHAR,
	@p_ocupado CHAR,
	@p_id_cliente int,
	@p_id_veiculos int,
	@p_id_tipo_vaga int
AS
BEGIN
	UPDATE vaga
	SET numero_vaga = @p_numero_vaga, bloco = @p_bloco, andar = @p_andar, id_cliente = @p_id_cliente, id_veiculos = @p_id_veiculos, id_tipo_vaga = @p_id_tipo_vaga, ocupado = @p_ocupado, data_entrada = GETDATE()
	WHERE id_vaga = @p_id_vaga
END
GO

CREATE PROCEDURE sp_desocupar_vaga
	@p_id_vaga INT,
	@p_numero_vaga VARCHAR,
	@p_bloco VARCHAR,
	@p_andar VARCHAR,
	@p_ocupado CHAR,
	@p_id_cliente int,
	@p_id_veiculos int,
	@p_id_tipo_vaga int
AS
BEGIN
	UPDATE vaga
	SET numero_vaga = @p_numero_vaga, bloco = @p_bloco, andar = @p_andar, id_cliente = @p_id_cliente, id_veiculos = @p_id_veiculos, id_tipo_vaga = @p_id_tipo_vaga, ocupado = @p_ocupado, data_entrada = GETDATE()
	WHERE id_vaga = @p_id_vaga
END
GO
CREATE PROCEDURE sp_delete_vaga
	
	@p_id_vaga INT
AS
BEGIN
	DELETE FROM vaga where id_vaga = @p_id_vaga
END
GO

Insert Into usuario (login_usuario, senha_usuario)
Values('Usuario', '123')
GO

insert into cliente (nome_cliente, CPF_cliente, telefone_cliente, especificacao_cliente)
Values('[Vazio]', '[Vazio]', '[Vazio]', 'V')
GO

INSERT INTO tipo_vaga(nome_tipo_vaga, preco_mensalista, preco_horista)
VALUES('[Vazio]', 0.00, 0.00)
GO

INSERT INTO veiculo (marca_veiculo, modelo_veiculo, placa_veiculo, id_cliente)
VALUES('[Vazio]', '[Vazio]', '[Vazio]', 1)
GO

CREATE TABLE registro (
id_registro INT PRIMARY KEY IDENTITY,
entrada_registro DATETIME,
saida_registro DATETIME,
id_cliente INT,
id_veiculos INT,
id_tipo_vaga INT,
id_vaga INT, 
preco DECIMAL(5,2)

	CONSTRAINT fk_registros_cliente FOREIGN KEY (id_cliente)
	REFERENCES cliente (id_cliente),

	CONSTRAINT fk_registros_tipo_vaga FOREIGN KEY (id_tipo_vaga)
	REFERENCES tipo_vaga (id_tipo_vaga),

	CONSTRAINT fk_registros_veiculos FOREIGN KEY (id_veiculos)
	REFERENCES veiculo (id_veiculos),

	CONSTRAINT fk_registros_vaga FOREIGN KEY (id_vaga)
	REFERENCES vaga (id_vaga),
)
GO

CREATE PROCEDURE sp_select_registro
AS
BEGIN
	SELECT registro.id_registro, registro.entrada_registro, registro.saida_registro, marca_veiculo, modelo_veiculo, placa_veiculo,nome_cliente, CPF_cliente, telefone_cliente, especificacao_cliente, nome_tipo_vaga, numero_vaga, preco FROM registro
	inner join veiculo on veiculo.id_veiculos = registro.id_veiculos
	inner join cliente on cliente.id_cliente = registro.id_cliente
	inner join tipo_vaga on tipo_vaga.id_tipo_vaga = registro.id_tipo_vaga
	inner join vaga on vaga.id_vaga = registro.id_vaga
END
GO

CREATE PROCEDURE sp_insert_registro
	@p_entrada_registro DATETIME,
	@p_saida_registro DATETIME,
	@p_id_cliente int,
	@p_id_veiculos int,
	@p_id_tipo_vaga int,
	@p_id_vaga int,
	@p_preco DECIMAL

AS
BEGIN
	INSERT INTO registro (entrada_registro, saida_registro, id_cliente, id_veiculos, id_tipo_vaga, id_vaga, preco)
	VALUES(@p_entrada_registro, @p_saida_registro, @p_id_cliente, @p_id_veiculos, @p_id_tipo_vaga, @p_id_vaga, @p_preco)
END
GO