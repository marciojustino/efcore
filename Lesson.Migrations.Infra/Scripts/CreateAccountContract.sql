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

CREATE TABLE [Bank] (
    [Id] bigint NOT NULL IDENTITY,
    [Name] nvarchar(200) NOT NULL,
    [Code] nvarchar(4) NOT NULL,
    CONSTRAINT [PK_Bank] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Client] (
    [Id] bigint NOT NULL IDENTITY,
    [Document] nvarchar(450) NULL,
    [Name] nvarchar(200) NOT NULL,
    [BirthDate] DATETIME NOT NULL,
    CONSTRAINT [PK_Client] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Agency] (
    [Id] bigint NOT NULL IDENTITY,
    [Name] nvarchar(200) NOT NULL,
    [Code] nvarchar(4) NOT NULL,
    [BankId] bigint NOT NULL,
    CONSTRAINT [PK_Agency] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Agency_Bank_BankId] FOREIGN KEY ([BankId]) REFERENCES [Bank] ([Id])
);
GO

CREATE TABLE [Account] (
    [Id] bigint NOT NULL IDENTITY,
    [Number] nvarchar(20) NOT NULL,
    [OpenedAt] DATETIME NOT NULL,
    [UpdatedAt] DATETIME NULL,
    [Status] nvarchar(max) NOT NULL DEFAULT N'Active',
    [BankId] bigint NOT NULL,
    [AgencyId] bigint NOT NULL,
    CONSTRAINT [PK_Account] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Account_Agency_AgencyId] FOREIGN KEY ([AgencyId]) REFERENCES [Agency] ([Id]),
    CONSTRAINT [FK_Account_Bank_BankId] FOREIGN KEY ([BankId]) REFERENCES [Bank] ([Id])
);
GO

CREATE TABLE [AccountClient] (
    [AccountId] bigint NOT NULL,
    [ClientId] bigint NOT NULL,
    CONSTRAINT [PK_AccountClient] PRIMARY KEY ([AccountId], [ClientId]),
    CONSTRAINT [FK_AccountClient_Account_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Account] ([Id]),
    CONSTRAINT [FK_AccountClient_Client_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [Client] ([Id])
);
GO

CREATE INDEX [IX_Account_AgencyId] ON [Account] ([AgencyId]);
GO

CREATE INDEX [IX_Account_BankId] ON [Account] ([BankId]);
GO

CREATE INDEX [IX_Account_Number] ON [Account] ([Number]);
GO

CREATE INDEX [IX_AccountClient_ClientId] ON [AccountClient] ([ClientId]);
GO

CREATE INDEX [IX_Agency_BankId] ON [Agency] ([BankId]);
GO

CREATE INDEX [IX_Agency_Code] ON [Agency] ([Code]);
GO

CREATE INDEX [IX_Agency_Name] ON [Agency] ([Name]);
GO

CREATE INDEX [IX_Bank_Code] ON [Bank] ([Code]);
GO

CREATE INDEX [IX_Bank_Name] ON [Bank] ([Name]);
GO

CREATE INDEX [IX_Client_Document] ON [Client] ([Document]);
GO

CREATE INDEX [IX_Client_Name] ON [Client] ([Name]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210509201801_CreateInitialStructure', N'5.0.5');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Account] ADD [ContractId] bigint NOT NULL DEFAULT CAST(0 AS bigint);
GO

CREATE TABLE [Contract] (
    [Id] bigint NOT NULL IDENTITY,
    [CreatedAt] DATETIME NOT NULL DEFAULT (GETDATE()),
    [DATETIME] datetime2 NULL,
    [AccountId] bigint NOT NULL,
    CONSTRAINT [PK_Contract] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Contract_Account_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [Account] ([Id])
);
GO

CREATE UNIQUE INDEX [IX_Contract_AccountId] ON [Contract] ([AccountId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210509210355_CreateAccountContract', N'5.0.5');
GO

COMMIT;
GO

