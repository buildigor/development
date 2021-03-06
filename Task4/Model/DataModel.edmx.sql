
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/11/2017 18:21:01
-- Generated from EDMX file: g:\epam\Projects\vanovich\Task4\Model\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SalesDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ManagerSaleInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SaleInfoes] DROP CONSTRAINT [FK_ManagerSaleInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_ClientSaleInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SaleInfoes] DROP CONSTRAINT [FK_ClientSaleInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductSaleInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SaleInfoes] DROP CONSTRAINT [FK_ProductSaleInfo];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Managers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Managers];
GO
IF OBJECT_ID(N'[dbo].[Clients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clients];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO
IF OBJECT_ID(N'[dbo].[SaleInfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SaleInfoes];
GO
IF OBJECT_ID(N'[dbo].[CsvWorkerInfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CsvWorkerInfoes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Managers'
CREATE TABLE [dbo].[Managers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SecondName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FullName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SaleInfoes'
CREATE TABLE [dbo].[SaleInfoes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] datetime  NOT NULL,
    [Amount] float  NOT NULL,
    [ManagerId] int  NOT NULL,
    [ClientId] int  NOT NULL,
    [ProductId] int  NOT NULL
);
GO

-- Creating table 'CsvWorkerInfoes'
CREATE TABLE [dbo].[CsvWorkerInfoes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FileNameProcessed] nvarchar(max)  NOT NULL,
    [DateProcessed] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Managers'
ALTER TABLE [dbo].[Managers]
ADD CONSTRAINT [PK_Managers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SaleInfoes'
ALTER TABLE [dbo].[SaleInfoes]
ADD CONSTRAINT [PK_SaleInfoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CsvWorkerInfoes'
ALTER TABLE [dbo].[CsvWorkerInfoes]
ADD CONSTRAINT [PK_CsvWorkerInfoes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ManagerId] in table 'SaleInfoes'
ALTER TABLE [dbo].[SaleInfoes]
ADD CONSTRAINT [FK_ManagerSaleInfo]
    FOREIGN KEY ([ManagerId])
    REFERENCES [dbo].[Managers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ManagerSaleInfo'
CREATE INDEX [IX_FK_ManagerSaleInfo]
ON [dbo].[SaleInfoes]
    ([ManagerId]);
GO

-- Creating foreign key on [ClientId] in table 'SaleInfoes'
ALTER TABLE [dbo].[SaleInfoes]
ADD CONSTRAINT [FK_ClientSaleInfo]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[Clients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientSaleInfo'
CREATE INDEX [IX_FK_ClientSaleInfo]
ON [dbo].[SaleInfoes]
    ([ClientId]);
GO

-- Creating foreign key on [ProductId] in table 'SaleInfoes'
ALTER TABLE [dbo].[SaleInfoes]
ADD CONSTRAINT [FK_ProductSaleInfo]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductSaleInfo'
CREATE INDEX [IX_FK_ProductSaleInfo]
ON [dbo].[SaleInfoes]
    ([ProductId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------