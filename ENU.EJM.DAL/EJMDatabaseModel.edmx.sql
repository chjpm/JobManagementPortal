
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/24/2022 20:38:53
-- Generated from EDMX file: D:\WorkingZone\Microsoft Smart Web Apps Full Stack Track -1\1- ILP-001\Source Code\EngineeringJobManagement\ENU.EJM.DAL\EJMDatabaseModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EJM];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_EngineerID_AspNetUsersID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblEngineers] DROP CONSTRAINT [FK_EngineerID_AspNetUsersID];
GO
IF OBJECT_ID(N'[dbo].[FK_SupervisorID_AspNetUsersID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblEngineers] DROP CONSTRAINT [FK_SupervisorID_AspNetUsersID];
GO
IF OBJECT_ID(N'[dbo].[FK_tblJobActivity_tblEngineers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblJobActivities] DROP CONSTRAINT [FK_tblJobActivity_tblEngineers];
GO
IF OBJECT_ID(N'[dbo].[FK_tblJobActivity_tblJobRequest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblJobActivities] DROP CONSTRAINT [FK_tblJobActivity_tblJobRequest];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetRoles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetUsers];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[tblEngineers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblEngineers];
GO
IF OBJECT_ID(N'[dbo].[tblJobActivities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblJobActivities];
GO
IF OBJECT_ID(N'[dbo].[tblJobRequests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblJobRequests];
GO
IF OBJECT_ID(N'[dbo].[vwUserInRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[vwUserInRoles];
GO
IF OBJECT_ID(N'[dbo].[vwJobActivityLists]', 'U') IS NOT NULL
    DROP TABLE [dbo].[vwJobActivityLists];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'tblEngineers'
CREATE TABLE [dbo].[tblEngineers] (
    [EngineerID] nvarchar(128)  NOT NULL,
    [SupervisorID] nvarchar(128)  NOT NULL,
    [Description] varchar(max)  NULL
);
GO

-- Creating table 'tblJobActivities'
CREATE TABLE [dbo].[tblJobActivities] (
    [JobRequestID] int  NOT NULL,
    [JobStatus] varchar(50)  NOT NULL,
    [Description] varchar(max)  NULL,
    [EngineerID] nvarchar(128)  NOT NULL,
    [LastUpdated] datetime  NOT NULL
);
GO

-- Creating table 'tblJobRequests'
CREATE TABLE [dbo].[tblJobRequests] (
    [RequestID] int IDENTITY(1,1) NOT NULL,
    [CustomerName] varchar(100)  NOT NULL,
    [Address] varchar(max)  NOT NULL,
    [EmailAddress] varchar(50)  NULL,
    [PhoneNumber] varchar(50)  NULL,
    [JobItem] varchar(50)  NOT NULL,
    [JobType] varchar(50)  NOT NULL,
    [Description] varchar(max)  NULL,
    [PrefferedTime] datetime  NOT NULL,
    [LastUpdated] datetime  NULL
);
GO

-- Creating table 'vwUserInRoles'
CREATE TABLE [dbo].[vwUserInRoles] (
    [UserId] nvarchar(128)  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL,
    [RoleID] nvarchar(128)  NOT NULL,
    [RoleName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'vwJobActivityLists'
CREATE TABLE [dbo].[vwJobActivityLists] (
    [RequestID] int  NOT NULL,
    [CustomerName] varchar(100)  NOT NULL,
    [Address] varchar(max)  NOT NULL,
    [JobStatus] varchar(50)  NULL,
    [Description] varchar(max)  NULL,
    [EngineerID] nvarchar(128)  NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [AspNetRoles_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers_Id] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [EngineerID] in table 'tblEngineers'
ALTER TABLE [dbo].[tblEngineers]
ADD CONSTRAINT [PK_tblEngineers]
    PRIMARY KEY CLUSTERED ([EngineerID] ASC);
GO

-- Creating primary key on [JobRequestID] in table 'tblJobActivities'
ALTER TABLE [dbo].[tblJobActivities]
ADD CONSTRAINT [PK_tblJobActivities]
    PRIMARY KEY CLUSTERED ([JobRequestID] ASC);
GO

-- Creating primary key on [RequestID] in table 'tblJobRequests'
ALTER TABLE [dbo].[tblJobRequests]
ADD CONSTRAINT [PK_tblJobRequests]
    PRIMARY KEY CLUSTERED ([RequestID] ASC);
GO

-- Creating primary key on [UserId], [UserName], [RoleID], [RoleName] in table 'vwUserInRoles'
ALTER TABLE [dbo].[vwUserInRoles]
ADD CONSTRAINT [PK_vwUserInRoles]
    PRIMARY KEY CLUSTERED ([UserId], [UserName], [RoleID], [RoleName] ASC);
GO

-- Creating primary key on [RequestID], [CustomerName], [Address] in table 'vwJobActivityLists'
ALTER TABLE [dbo].[vwJobActivityLists]
ADD CONSTRAINT [PK_vwJobActivityLists]
    PRIMARY KEY CLUSTERED ([RequestID], [CustomerName], [Address] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EngineerID] in table 'tblEngineers'
ALTER TABLE [dbo].[tblEngineers]
ADD CONSTRAINT [FK_EngineerID_AspNetUsersID]
    FOREIGN KEY ([EngineerID])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [SupervisorID] in table 'tblEngineers'
ALTER TABLE [dbo].[tblEngineers]
ADD CONSTRAINT [FK_SupervisorID_AspNetUsersID]
    FOREIGN KEY ([SupervisorID])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SupervisorID_AspNetUsersID'
CREATE INDEX [IX_FK_SupervisorID_AspNetUsersID]
ON [dbo].[tblEngineers]
    ([SupervisorID]);
GO

-- Creating foreign key on [EngineerID] in table 'tblJobActivities'
ALTER TABLE [dbo].[tblJobActivities]
ADD CONSTRAINT [FK_tblJobActivity_tblEngineers]
    FOREIGN KEY ([EngineerID])
    REFERENCES [dbo].[tblEngineers]
        ([EngineerID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblJobActivity_tblEngineers'
CREATE INDEX [IX_FK_tblJobActivity_tblEngineers]
ON [dbo].[tblJobActivities]
    ([EngineerID]);
GO

-- Creating foreign key on [JobRequestID] in table 'tblJobActivities'
ALTER TABLE [dbo].[tblJobActivities]
ADD CONSTRAINT [FK_tblJobActivity_tblJobRequest]
    FOREIGN KEY ([JobRequestID])
    REFERENCES [dbo].[tblJobRequests]
        ([RequestID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUsers'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUsers]
ON [dbo].[AspNetUserRoles]
    ([AspNetUsers_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------