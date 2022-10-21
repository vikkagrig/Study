
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/20/2022 14:50:11
-- Generated from EDMX file: C:\Users\Виктория Григорьева\Desktop\Study\Основы алгоритмизации и программирования\Приемная_комиссия\EntityModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [C:\Users\Виктория Григорьева\Desktop\Study\Основы алгоритмизации и программирования\Приемная_комиссия\LR12.MDF];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_EntrantList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ListSet] DROP CONSTRAINT [FK_EntrantList];
GO
IF OBJECT_ID(N'[dbo].[FK_FacultySpecialty]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SpecialtySet] DROP CONSTRAINT [FK_FacultySpecialty];
GO
IF OBJECT_ID(N'[dbo].[FK_ListSpecialty]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ListSet] DROP CONSTRAINT [FK_ListSpecialty];
GO
IF OBJECT_ID(N'[dbo].[FK_UserEntrant]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EntrantSet] DROP CONSTRAINT [FK_UserEntrant];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[EntrantSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EntrantSet];
GO
IF OBJECT_ID(N'[dbo].[FacultySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FacultySet];
GO
IF OBJECT_ID(N'[dbo].[ListSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ListSet];
GO
IF OBJECT_ID(N'[dbo].[SpecialtySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SpecialtySet];
GO
IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Role] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EntrantSet'
CREATE TABLE [dbo].[EntrantSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Point] int  NOT NULL,
    [Photo] varbinary(max)  NOT NULL,
    [PersonalyData] nvarchar(max)  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'ListSet'
CREATE TABLE [dbo].[ListSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Point] nvarchar(max)  NOT NULL,
    [Prioritet] int  NOT NULL,
    [Entrant_Id] int  NULL,
    [Specialty_Id] int  NULL
);
GO

-- Creating table 'FacultySet'
CREATE TABLE [dbo].[FacultySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SpecialtySet'
CREATE TABLE [dbo].[SpecialtySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Place] int  NOT NULL,
    [Faculty_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EntrantSet'
ALTER TABLE [dbo].[EntrantSet]
ADD CONSTRAINT [PK_EntrantSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ListSet'
ALTER TABLE [dbo].[ListSet]
ADD CONSTRAINT [PK_ListSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FacultySet'
ALTER TABLE [dbo].[FacultySet]
ADD CONSTRAINT [PK_FacultySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SpecialtySet'
ALTER TABLE [dbo].[SpecialtySet]
ADD CONSTRAINT [PK_SpecialtySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User_Id] in table 'EntrantSet'
ALTER TABLE [dbo].[EntrantSet]
ADD CONSTRAINT [FK_UserEntrant]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserEntrant'
CREATE INDEX [IX_FK_UserEntrant]
ON [dbo].[EntrantSet]
    ([User_Id]);
GO

-- Creating foreign key on [Entrant_Id] in table 'ListSet'
ALTER TABLE [dbo].[ListSet]
ADD CONSTRAINT [FK_EntrantList]
    FOREIGN KEY ([Entrant_Id])
    REFERENCES [dbo].[EntrantSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EntrantList'
CREATE INDEX [IX_FK_EntrantList]
ON [dbo].[ListSet]
    ([Entrant_Id]);
GO

-- Creating foreign key on [Specialty_Id] in table 'ListSet'
ALTER TABLE [dbo].[ListSet]
ADD CONSTRAINT [FK_ListSpecialty]
    FOREIGN KEY ([Specialty_Id])
    REFERENCES [dbo].[SpecialtySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ListSpecialty'
CREATE INDEX [IX_FK_ListSpecialty]
ON [dbo].[ListSet]
    ([Specialty_Id]);
GO

-- Creating foreign key on [Faculty_Id] in table 'SpecialtySet'
ALTER TABLE [dbo].[SpecialtySet]
ADD CONSTRAINT [FK_FacultySpecialty]
    FOREIGN KEY ([Faculty_Id])
    REFERENCES [dbo].[FacultySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FacultySpecialty'
CREATE INDEX [IX_FK_FacultySpecialty]
ON [dbo].[SpecialtySet]
    ([Faculty_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------