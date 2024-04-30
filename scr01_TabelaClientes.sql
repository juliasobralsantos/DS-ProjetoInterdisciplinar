IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [TB_CLIENTES] (
    [Id] int NOT NULL IDENTITY,
    [Nome] varchar(200) NOT NULL,
    [CPF] varchar(200) NOT NULL,
    [Telefone] bigint NOT NULL,
    [Endereço] varchar(200) NOT NULL,
    [Email] varchar(200) NOT NULL,
    CONSTRAINT [PK_TB_CLIENTES] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [TB_PROCEDIMENTOS] (
    [Id] int NOT NULL IDENTITY,
    [Nome] varchar(200) NOT NULL,
    [Descriçao] varchar(200) NOT NULL,
    [ValorProcedimento] float NOT NULL,
    [DataInicioProcedimento] datetime2 NOT NULL,
    [ProfissionalResponsavel] varchar(200) NOT NULL,
    CONSTRAINT [PK_TB_PROCEDIMENTOS] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CPF', N'Email', N'Endereço', N'Nome', N'Telefone') AND [object_id] = OBJECT_ID(N'[TB_CLIENTES]'))
    SET IDENTITY_INSERT [TB_CLIENTES] ON;
INSERT INTO [TB_CLIENTES] ([Id], [CPF], [Email], [Endereço], [Nome], [Telefone])
VALUES (1, '243.567.431-10', 'amandasilva123@gmail.com', 'Rua das Orquídeas, 295 - Morumbi', 'Amanda da Silva', CAST(11965843278 AS bigint)),
(2, '189.298.674-23', 'MaduOliveira@hotmail.com', 'Rua Maria Cândida, 728 - Casa 2 - Vila Guilherme', 'Maria Eduarda Oliveira', CAST(11948291640 AS bigint)),
(3, '368.583.783-79', 'silvaelisa2297@gmail.com', 'Rua Olavo Egídio, 469 - Santana', 'Elisa de Souza Santos', CAST(11987953869 AS bigint)),
(4, '474.973.864-84', 'lucianaalmeida9@hotmail.com', 'Av. General Ataliba Leonel, 2034 - Parada Inglesa', 'Luciana Almeida', CAST(11938596036 AS bigint)),
(5, '282.684.290-19', 'fernanda23antunes@gmail.com', 'Rua da Gávea, 55 - Vila Maria', 'Fernanda Antunes', CAST(11910384874 AS bigint)),
(6, '173.183.286-57', 'andressaferreira79@hotmail.com', 'Rua Jacuna, 226 - Carandiru', 'Andressa Ferreira', CAST(11928462967 AS bigint)),
(7, '372.293.480-48', 'analulisboa1011@outlook.com', 'Av. Coronel Sezefredo Fagundes, 2847, apto. 210 - Tremembé', 'Ana Luiza Lisboa', CAST(11949687931 AS bigint));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CPF', N'Email', N'Endereço', N'Nome', N'Telefone') AND [object_id] = OBJECT_ID(N'[TB_CLIENTES]'))
    SET IDENTITY_INSERT [TB_CLIENTES] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataInicioProcedimento', N'Descriçao', N'Nome', N'ProfissionalResponsavel', N'ValorProcedimento') AND [object_id] = OBJECT_ID(N'[TB_PROCEDIMENTOS]'))
    SET IDENTITY_INSERT [TB_PROCEDIMENTOS] ON;
INSERT INTO [TB_PROCEDIMENTOS] ([Id], [DataInicioProcedimento], [Descriçao], [Nome], [ProfissionalResponsavel], [ValorProcedimento])
VALUES (1, '0001-01-01T00:00:00.0000000', 'Massagem local que pode ser realizada em diversas partes do corpo.', 'Drenagem Linfática', 'Sonia', 149.99000000000001E0),
(2, '0001-01-01T00:00:00.0000000', 'Limpeza facial com utilização de produtos, retira impurezas da pele.', 'Limpeza de Pele', 'Solange', 119.98999999999999E0),
(3, '0001-01-01T00:00:00.0000000', 'Aparelho que utiliza da rádiofrequência para reduzir flacidez corporal.', 'Rádio Frequência', 'Sonia', 99.989999999999995E0),
(4, '0001-01-01T00:00:00.0000000', 'Aparelho de ultrassom utilizado para reduzir gordura localizada.', 'Cavitação', 'Solange', 89.989999999999995E0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataInicioProcedimento', N'Descriçao', N'Nome', N'ProfissionalResponsavel', N'ValorProcedimento') AND [object_id] = OBJECT_ID(N'[TB_PROCEDIMENTOS]'))
    SET IDENTITY_INSERT [TB_PROCEDIMENTOS] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240428193334_MigracaoInicial', N'8.0.4');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [TB_CLIENTES] ADD [UsuarioId] int NULL;
GO

CREATE TABLE [TB_USUARIOS] (
    [Id] int NOT NULL IDENTITY,
    [Nome] varchar(200) NOT NULL,
    [Login] varchar(200) NOT NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    [DataAcesso] datetime2 NULL,
    [TipoUsuario] int NOT NULL,
    CONSTRAINT [PK_TB_USUARIOS] PRIMARY KEY ([Id])
);
GO

UPDATE [TB_CLIENTES] SET [UsuarioId] = 1
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_CLIENTES] SET [UsuarioId] = 1
WHERE [Id] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_CLIENTES] SET [UsuarioId] = 1
WHERE [Id] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_CLIENTES] SET [UsuarioId] = 1
WHERE [Id] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_CLIENTES] SET [UsuarioId] = 1
WHERE [Id] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_CLIENTES] SET [UsuarioId] = 1
WHERE [Id] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_CLIENTES] SET [UsuarioId] = 1
WHERE [Id] = 7;
SELECT @@ROWCOUNT;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAcesso', N'Login', N'Nome', N'PasswordHash', N'PasswordSalt', N'TipoUsuario') AND [object_id] = OBJECT_ID(N'[TB_USUARIOS]'))
    SET IDENTITY_INSERT [TB_USUARIOS] ON;
INSERT INTO [TB_USUARIOS] ([Id], [DataAcesso], [Login], [Nome], [PasswordHash], [PasswordSalt], [TipoUsuario])
VALUES (1, NULL, 'UsuarioAdmin', 'Usuário', 0xED6727A8D5DDC0A17C7470B285C6E31BF26427F2F208D617B3FE8795FFDBCCE1459FD75F495B12BF8C82036B389B44CDBA7A9BA931FA70A854C5DFC86AD83694, 0xD603CDCE21C9DA738916A961F560ABF5FB34BCC8B102532ED46831071A966EFE484ADFC1561806CF36D2FAE31646157AC9389A9408C9DFCE6EFBA3F1E5D1260C8B9793F97BC3A6BF41289B3E97B7EE8ACBB4884A2E8E40DF8EF4B0F4DE91CE9261F9BA4F2DFC2B659134F9A11712EBC6377E05394AFAA0475DEEAD37EBD45031, 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataAcesso', N'Login', N'Nome', N'PasswordHash', N'PasswordSalt', N'TipoUsuario') AND [object_id] = OBJECT_ID(N'[TB_USUARIOS]'))
    SET IDENTITY_INSERT [TB_USUARIOS] OFF;
GO

CREATE INDEX [IX_TB_CLIENTES_UsuarioId] ON [TB_CLIENTES] ([UsuarioId]);
GO

ALTER TABLE [TB_CLIENTES] ADD CONSTRAINT [FK_TB_CLIENTES_TB_USUARIOS_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [TB_USUARIOS] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240430195020_MigracaoUsuário', N'8.0.4');
GO

COMMIT;
GO

