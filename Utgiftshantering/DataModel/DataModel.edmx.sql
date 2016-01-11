
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 08/26/2011 22:23:02
-- Generated from EDMX file: C:\Micke\Applikationer\UHSEF\branches\Utgiftshantering\Utgiftshantering\DataModel\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [UHS];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PersonEntity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvoiceRowSet] DROP CONSTRAINT [FK_PersonEntity];
GO
IF OBJECT_ID(N'[dbo].[FK_CompanyEntity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvoiceRowSet] DROP CONSTRAINT [FK_CompanyEntity];
GO
IF OBJECT_ID(N'[dbo].[FK_InvoiceRows]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvoiceRowSet] DROP CONSTRAINT [FK_InvoiceRows];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CompanySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CompanySet];
GO
IF OBJECT_ID(N'[dbo].[InvoiceSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvoiceSet];
GO
IF OBJECT_ID(N'[dbo].[InvoiceRowSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvoiceRowSet];
GO
IF OBJECT_ID(N'[dbo].[PersonSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonSet];
GO
IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CompanySet'
CREATE TABLE [dbo].[CompanySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'InvoiceSet'
CREATE TABLE [dbo].[InvoiceSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [InvoiceName] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL
);
GO

-- Creating table 'InvoiceRowSet'
CREATE TABLE [dbo].[InvoiceRowSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Sum] float  NOT NULL,
    [Comments] nvarchar(max)  NOT NULL,
    [InvoiceId] int  NULL,
    [Person_Id] int  NULL,
    [Company_Id] int  NULL
);
GO

-- Creating table 'PersonSet'
CREATE TABLE [dbo].[PersonSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CompanySet'
ALTER TABLE [dbo].[CompanySet]
ADD CONSTRAINT [PK_CompanySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InvoiceSet'
ALTER TABLE [dbo].[InvoiceSet]
ADD CONSTRAINT [PK_InvoiceSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'InvoiceRowSet'
ALTER TABLE [dbo].[InvoiceRowSet]
ADD CONSTRAINT [PK_InvoiceRowSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonSet'
ALTER TABLE [dbo].[PersonSet]
ADD CONSTRAINT [PK_PersonSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Person_Id] in table 'InvoiceRowSet'
ALTER TABLE [dbo].[InvoiceRowSet]
ADD CONSTRAINT [FK_PersonEntity]
    FOREIGN KEY ([Person_Id])
    REFERENCES [dbo].[PersonSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonEntity'
CREATE INDEX [IX_FK_PersonEntity]
ON [dbo].[InvoiceRowSet]
    ([Person_Id]);
GO

-- Creating foreign key on [Company_Id] in table 'InvoiceRowSet'
ALTER TABLE [dbo].[InvoiceRowSet]
ADD CONSTRAINT [FK_CompanyEntity]
    FOREIGN KEY ([Company_Id])
    REFERENCES [dbo].[CompanySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyEntity'
CREATE INDEX [IX_FK_CompanyEntity]
ON [dbo].[InvoiceRowSet]
    ([Company_Id]);
GO

-- Creating foreign key on [InvoiceId] in table 'InvoiceRowSet'
ALTER TABLE [dbo].[InvoiceRowSet]
ADD CONSTRAINT [FK_InvoiceRows]
    FOREIGN KEY ([InvoiceId])
    REFERENCES [dbo].[InvoiceSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvoiceRows'
CREATE INDEX [IX_FK_InvoiceRows]
ON [dbo].[InvoiceRowSet]
    ([InvoiceId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

-- INSERT INTO UserSet VALUES ("Tomas","Tomas")
-- SELECT * FROM UserSet