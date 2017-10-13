-- Geração de Modelo físico
-- Sql ANSI 2003 - brModelo.



CREATE TABLE PEDIDO (
idPedido int PRIMARY KEY IDENTITY,
dataPedido dateTime not null,
dataPrevistaEntrega dateTime not null,
dataEntrega dateTime,
statusPedido int not null,
idCliente int not null
)
GO

CREATE TABLE PAGAMENTO (
idPagamento int PRIMARY KEY IDENTITY,
situacao int not null,
formaPagamento int not null,
parcelas int not null,
idPedido int not null
)
GO

CREATE TABLE ENDERECO (
idEndereco int PRIMARY KEY IDENTITY,
rua nvarchar(50) not null,
numero nvarchar(50) not null,
complemento nvarchar(50) not null,
bairro nvarchar(25) not null,
cidade nvarchar(20) not null,
estado char(2) not null,
cep nvarchar(11),
idCliente int not null
)
GO

CREATE TABLE USUARIO (
idUsuario int PRIMARY KEY IDENTITY,
nome nvarchar(50) not null,
login nvarchar(20) not null,
senha nvarchar(50) not null,
dataCadastro dateTime not null,
ativo bit not null
)
GO

CREATE TABLE MONTAGEM (
idMontagem int PRIMARY KEY IDENTITY,
valor numeric(3,2) not null,
idPedido int not null,
idArmacao int not null
)
GO

CREATE TABLE ARMACAO (
idArmacao int PRIMARY KEY IDENTITY,
modelo int not null,
marca nvarchar(20),
referencia nvarchar(20),
vertical numeric(3,2),
horizontal numeric(3,2),
diagonalMaior numeric(3,2),
ponte numeric(3,2),
valor numeric(3,2) not null,
idPedido int not null
)
GO

CREATE TABLE TIPOLENTE (
idTipoLente int PRIMARY KEY IDENTITY,
material int not null,
tipoVisao int not null,
tipoProducao int not null,
descricao nvarchar(25) not null,
indice int not null,
idLente int not null
)
GO

CREATE TABLE LENTE (
idLente int PRIMARY KEY IDENTITY,
olho int not null,
diametro int not null,
valor numeric(3,2) not null,
idPedido int not null
)
GO

CREATE TABLE COLORACAO (
idColoracao int PRIMARY KEY IDENTITY,
tipoColoracao int not null,
cor nvarchar(20) not null,
valor numeric(3,2) not null,
idPedido int not null
)
GO

CREATE TABLE ANTIRREFLEXO (
idAntirreflexo int PRIMARY KEY IDENTITY,
tipoAntirreflexo int not null,
valor numeric(3,2) not null,
idPedido int not null
)
GO

CREATE TABLE DIOPTRIA (
idDioptria int PRIMARY KEY IDENTITY,
esf numeric(3,2),
cil numeric(3,2),
eixo int,
adicao numeric(3,2),
dnp numeric(3,2),
altura numeric(3,2),
prisma1 numeric(3,2),
base1 int,
prisma2 numeric(3,2),
base2 int,
idLente int not null
)
GO

CREATE TABLE CLIENTE (
idCliente int PRIMARY KEY IDENTITY(100,1),
nome nvarchar(50) not null,
email nvarchar(20),
dataCadastro dateTime not null,
cpfCnpj nvarchar(20),
tipoCliente nvarchar(20) not null
)
GO

CREATE TABLE TELEFONE (
idTelefone int PRIMARY KEY IDENTITY,
ddd int not null,
numero int not null,
idCliente int not null
)
GO

ALTER TABLE PEDIDO ADD CONSTRAINT FK_CLIENTE_PEDIDO FOREIGN KEY(idCliente) REFERENCES CLIENTE (idCliente)
ALTER TABLE ENDERECO ADD CONSTRAINT FK_CLIENTE_ENDERECO FOREIGN KEY(idCliente) REFERENCES CLIENTE (idCliente)
ALTER TABLE TIPOLENTE ADD CONSTRAINT FK_LENTE_TIPOLENTE FOREIGN KEY(idLente) REFERENCES LENTE (idLente)
ALTER TABLE PAGAMENTO ADD CONSTRAINT FK_PEDIDO_PAGAMENTO FOREIGN KEY(idPedido) REFERENCES PEDIDO (idPedido)
ALTER TABLE MONTAGEM ADD CONSTRAINT FK_PEDIDO_MONTAGEM FOREIGN KEY(idPedido) REFERENCES PEDIDO (idPedido)
ALTER TABLE MONTAGEM ADD CONSTRAINT FK_ARMACAO_MONTAGEM FOREIGN KEY(idArmacao) REFERENCES ARMACAO (idArmacao)
ALTER TABLE ARMACAO ADD CONSTRAINT FK_PEDIDO_ARMACAO FOREIGN KEY(idPedido) REFERENCES PEDIDO (idPedido)
ALTER TABLE LENTE ADD CONSTRAINT FK_PEDIDO_LENTE FOREIGN KEY(idPedido) REFERENCES PEDIDO (idPedido)
ALTER TABLE COLORACAO ADD CONSTRAINT FK_PEDIDO_COLORACAO FOREIGN KEY(idPedido) REFERENCES PEDIDO (idPedido)
ALTER TABLE ANTIRREFLEXO ADD CONSTRAINT FK_PEDIDO_ANTIRREFLEXO FOREIGN KEY(idPedido) REFERENCES PEDIDO (idPedido)
ALTER TABLE DIOPTRIA ADD CONSTRAINT FK_LENTE_DIOPTRIA FOREIGN KEY(idLente) REFERENCES LENTE (idLente)
ALTER TABLE TELEFONE ADD CONSTRAINT FK_PEDIDO_TELEFONE FOREIGN KEY(idCliente) REFERENCES CLIENTE (idCliente)
ALTER TABLE USUARIO ADD CONSTRAINT UK_USUARIO_LOGIN UNIQUE (login)
ALTER TABLE CLIENTE ADD CONSTRAINT UK_CLIENTE_EMAIL UNIQUE (email)
ALTER TABLE CLIENTE ADD CONSTRAINT UK_CLIENTE_CPFCNPJ UNIQUE (cpfCnpj)

