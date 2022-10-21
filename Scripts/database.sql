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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221021004630_Initial-Migration')
BEGIN
    CREATE TABLE [Customer] (
        [Id] int NOT NULL IDENTITY,
        [FirstName] nvarchar(100) NOT NULL,
        [LastName] nvarchar(100) NOT NULL,
        [Age] int NOT NULL,
        [Status] bit NOT NULL,
        CONSTRAINT [PK_Customer] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221021004630_Initial-Migration')
BEGIN
    CREATE TABLE [Product] (
        [Id] int NOT NULL IDENTITY,
        [Code] varchar(20) NOT NULL,
        [Description] nvarchar(200) NOT NULL,
        [UnitPrice] decimal(11,2) NOT NULL,
        [Status] bit NOT NULL,
        CONSTRAINT [PK_Product] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221021004630_Initial-Migration')
BEGIN
    CREATE TABLE [Sale] (
        [Id] int NOT NULL IDENTITY,
        [SaleDate] DATE NOT NULL,
        [SaleNumber] varchar(20) NOT NULL,
        [CustomerId] int NOT NULL,
        [TotalSale] decimal(11,2) NOT NULL,
        [Status] bit NOT NULL,
        CONSTRAINT [PK_Sale] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Sale_Customer_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customer] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221021004630_Initial-Migration')
BEGIN
    CREATE TABLE [SaleDetail] (
        [Id] int NOT NULL IDENTITY,
        [SaleId] int NOT NULL,
        [ProductId] int NOT NULL,
        [Quantity] decimal(11,2) NOT NULL,
        [UnitPrice] decimal(11,2) NOT NULL,
        [TotalPrice] decimal(11,2) NOT NULL,
        [Status] bit NOT NULL,
        CONSTRAINT [PK_SaleDetail] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_SaleDetail_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_SaleDetail_Sale_SaleId] FOREIGN KEY ([SaleId]) REFERENCES [Sale] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221021004630_Initial-Migration')
BEGIN
    CREATE INDEX [IX_Sale_CustomerId] ON [Sale] ([CustomerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221021004630_Initial-Migration')
BEGIN
    CREATE INDEX [IX_SaleDetail_ProductId] ON [SaleDetail] ([ProductId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221021004630_Initial-Migration')
BEGIN
    CREATE INDEX [IX_SaleDetail_SaleId] ON [SaleDetail] ([SaleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221021004630_Initial-Migration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221021004630_Initial-Migration', N'6.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221021010038_DataPrueba')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Age', N'FirstName', N'LastName', N'Status') AND [object_id] = OBJECT_ID(N'[Customer]'))
        SET IDENTITY_INSERT [Customer] ON;
    EXEC(N'INSERT INTO [Customer] ([Id], [Age], [FirstName], [LastName], [Status])
    VALUES (1, 68, N''Barack'', N''Obama'', CAST(1 AS bit)),
    (2, 75, N''Joe'', N''Biden'', CAST(1 AS bit)),
    (3, 70, N''Vladimir'', N''Putin'', CAST(1 AS bit))');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Age', N'FirstName', N'LastName', N'Status') AND [object_id] = OBJECT_ID(N'[Customer]'))
        SET IDENTITY_INSERT [Customer] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221021010038_DataPrueba')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Code', N'Description', N'Status', N'UnitPrice') AND [object_id] = OBJECT_ID(N'[Product]'))
        SET IDENTITY_INSERT [Product] ON;
    EXEC(N'INSERT INTO [Product] ([Id], [Code], [Description], [Status], [UnitPrice])
    VALUES (1, ''0001'', N''Xbox Series X'', CAST(1 AS bit), 499.0),
    (2, ''0002'', N''PlayStation 5'', CAST(1 AS bit), 630.0),
    (3, ''0003'', N''Nintendo Switch'', CAST(1 AS bit), 599.0),
    (4, ''0004'', N''Wii U'', CAST(1 AS bit), 150.0)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Code', N'Description', N'Status', N'UnitPrice') AND [object_id] = OBJECT_ID(N'[Product]'))
        SET IDENTITY_INSERT [Product] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221021010038_DataPrueba')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221021010038_DataPrueba', N'6.0.10');
END;
GO

COMMIT;
GO

