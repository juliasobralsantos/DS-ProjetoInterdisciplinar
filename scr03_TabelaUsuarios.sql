﻿BEGIN TRANSACTION;
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

