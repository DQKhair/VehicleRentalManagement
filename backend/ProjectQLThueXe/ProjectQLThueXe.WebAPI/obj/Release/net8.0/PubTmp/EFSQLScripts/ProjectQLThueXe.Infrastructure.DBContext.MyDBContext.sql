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

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241028181214_InitialDB'
)
BEGIN
    CREATE TABLE [CarType] (
        [CarType_ID] int NOT NULL IDENTITY,
        [CarTypeName] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_CarType] PRIMARY KEY ([CarType_ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241028181214_InitialDB'
)
BEGIN
    CREATE TABLE [KCT] (
        [KCT_ID] uniqueidentifier NOT NULL,
        [KCT_Name] nvarchar(50) NOT NULL,
        [KCT_Phone] nvarchar(12) NOT NULL,
        [KCT_address] nvarchar(100) NOT NULL,
        [KCT_CCCD] nvarchar(12) NOT NULL,
        CONSTRAINT [PK_KCT] PRIMARY KEY ([KCT_ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241028181214_InitialDB'
)
BEGIN
    CREATE TABLE [KT] (
        [KT_ID] uniqueidentifier NOT NULL,
        [KT_Name] nvarchar(50) NOT NULL,
        [KT_Phone] nvarchar(12) NOT NULL,
        [KT_Address] nvarchar(100) NOT NULL,
        [KT_CCCD] nvarchar(12) NOT NULL,
        CONSTRAINT [PK_KT] PRIMARY KEY ([KT_ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241028181214_InitialDB'
)
BEGIN
    CREATE TABLE [Car] (
        [Car_ID] uniqueidentifier NOT NULL,
        [Model] nvarchar(50) NOT NULL,
        [Price] float NOT NULL,
        [status] bit NOT NULL,
        [location] nvarchar(max) NOT NULL,
        [CarType_ID] int NULL,
        [KCT_ID] uniqueidentifier NULL,
        CONSTRAINT [PK_Car] PRIMARY KEY ([Car_ID]),
        CONSTRAINT [FK_Car_CarType] FOREIGN KEY ([CarType_ID]) REFERENCES [CarType] ([CarType_ID]),
        CONSTRAINT [FK_Car_KCT] FOREIGN KEY ([KCT_ID]) REFERENCES [KCT] ([KCT_ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241028181214_InitialDB'
)
BEGIN
    CREATE TABLE [Receipts] (
        [Receipt_ID] uniqueidentifier NOT NULL,
        [totalMoney] float NOT NULL,
        [TimeStart] datetime2 NOT NULL,
        [TimeEnd] datetime2 NOT NULL,
        [TotalDay] int NOT NULL,
        [ReceiptTime] datetime2 NOT NULL,
        [KT_ID] uniqueidentifier NULL,
        CONSTRAINT [PK_Receipts] PRIMARY KEY ([Receipt_ID]),
        CONSTRAINT [FK_Receipts_KT] FOREIGN KEY ([KT_ID]) REFERENCES [KT] ([KT_ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241028181214_InitialDB'
)
BEGIN
    CREATE TABLE [ReceiptDetail] (
        [ReceiptDetail_ID] uniqueidentifier NOT NULL,
        [Car_model] nvarchar(50) NOT NULL,
        [Car_Price] float NOT NULL,
        [Car_ID] uniqueidentifier NULL,
        [Receipt_ID] uniqueidentifier NULL,
        CONSTRAINT [PK_ReceiptDetail] PRIMARY KEY ([ReceiptDetail_ID]),
        CONSTRAINT [FK_ReceiptDetail_Car] FOREIGN KEY ([Car_ID]) REFERENCES [Car] ([Car_ID]),
        CONSTRAINT [FK_ReceiptDetail_Receipts] FOREIGN KEY ([Receipt_ID]) REFERENCES [Receipts] ([Receipt_ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241028181214_InitialDB'
)
BEGIN
    CREATE INDEX [IX_Car_CarType_ID] ON [Car] ([CarType_ID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241028181214_InitialDB'
)
BEGIN
    CREATE INDEX [IX_Car_KCT_ID] ON [Car] ([KCT_ID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241028181214_InitialDB'
)
BEGIN
    CREATE INDEX [IX_ReceiptDetail_Car_ID] ON [ReceiptDetail] ([Car_ID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241028181214_InitialDB'
)
BEGIN
    CREATE INDEX [IX_ReceiptDetail_Receipt_ID] ON [ReceiptDetail] ([Receipt_ID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241028181214_InitialDB'
)
BEGIN
    CREATE INDEX [IX_Receipts_KT_ID] ON [Receipts] ([KT_ID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241028181214_InitialDB'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241028181214_InitialDB', N'8.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241029151524_updateColCar'
)
BEGIN
    ALTER TABLE [Car] ADD [NumberPlate] nvarchar(10) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241029151524_updateColCar'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241029151524_updateColCar', N'8.0.10');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241029154109_fixTableReceipt'
)
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Receipts]') AND [c].[name] = N'TimeEnd');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Receipts] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Receipts] DROP COLUMN [TimeEnd];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241029154109_fixTableReceipt'
)
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Receipts]') AND [c].[name] = N'TimeStart');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Receipts] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Receipts] DROP COLUMN [TimeStart];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241029154109_fixTableReceipt'
)
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Receipts]') AND [c].[name] = N'TotalDay');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Receipts] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Receipts] DROP COLUMN [TotalDay];
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241029154109_fixTableReceipt'
)
BEGIN
    ALTER TABLE [ReceiptDetail] ADD [TimeEnd] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241029154109_fixTableReceipt'
)
BEGIN
    ALTER TABLE [ReceiptDetail] ADD [TimeStart] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241029154109_fixTableReceipt'
)
BEGIN
    ALTER TABLE [ReceiptDetail] ADD [TotalDay] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20241029154109_fixTableReceipt'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20241029154109_fixTableReceipt', N'8.0.10');
END;
GO

COMMIT;
GO

