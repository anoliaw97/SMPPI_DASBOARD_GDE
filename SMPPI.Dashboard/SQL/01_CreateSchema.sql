-- =============================================
-- SMPPI Database Schema Creation Script
-- Sistem Maklumat Pengurusan Penyelidik dan Inovasi
-- Research and Innovation Management Information System
-- =============================================

USE master;
GO

-- Create database if not exists
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'SMPPI_DB')
BEGIN
    CREATE DATABASE SMPPI_DB;
END
GO

USE SMPPI_DB;
GO

-- =============================================
-- 1. Academic Staff Table
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblAcademicStaff]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[tblAcademicStaff] (
        [StaffID] INT PRIMARY KEY IDENTITY(1,1),
        [UMSPER] NVARCHAR(20) NOT NULL UNIQUE,
        [FullName] NVARCHAR(200) NOT NULL,
        [Position] NVARCHAR(100) NULL,
        [Faculty] NVARCHAR(100) NULL,
        [Department] NVARCHAR(100) NULL,
        [Email] NVARCHAR(100) NULL,
        [Phone] NVARCHAR(50) NULL,
        [ResearchDomain] NVARCHAR(100) NULL,
        [HIndex] INT NULL,
        [TotalPublications] INT DEFAULT 0,
        [IsActive] BIT DEFAULT 1,
        [DateCreated] DATETIME DEFAULT GETDATE(),
        [DateUpdated] DATETIME DEFAULT GETDATE()
    );

    CREATE INDEX IX_AcademicStaff_Faculty ON [dbo].[tblAcademicStaff]([Faculty]);
    CREATE INDEX IX_AcademicStaff_Position ON [dbo].[tblAcademicStaff]([Position]);
    CREATE INDEX IX_AcademicStaff_ResearchDomain ON [dbo].[tblAcademicStaff]([ResearchDomain]);
    CREATE INDEX IX_AcademicStaff_IsActive ON [dbo].[tblAcademicStaff]([IsActive]);
END
GO

-- =============================================
-- 2. Research Projects Table
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblResearchProjects]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[tblResearchProjects] (
        [ProjectID] INT PRIMARY KEY IDENTITY(1,1),
        [ProjectCode] NVARCHAR(50) NOT NULL UNIQUE,
        [ProjectTitle] NVARCHAR(500) NOT NULL,
        [PrincipalInvestigatorID] INT NOT NULL,
        [GrantScheme] NVARCHAR(50) NULL,
        [Phase] NVARCHAR(20) NULL,
        [ResearchDomain] NVARCHAR(100) NULL,
        [StartDate] DATE NULL,
        [EndDate] DATE NULL,
        [ExtensionDate] DATE NULL,
        [AllocatedBudget] DECIMAL(18,2) DEFAULT 0,
        [SpentAmount] DECIMAL(18,2) DEFAULT 0,
        [ProgressPercentage] INT DEFAULT 0,
        [ProjectStatus] NVARCHAR(50) DEFAULT 'Active',
        [MilestonePercentage] INT DEFAULT 0,
        [IsActive] BIT DEFAULT 1,
        [DateCreated] DATETIME DEFAULT GETDATE(),
        [DateUpdated] DATETIME DEFAULT GETDATE(),

        CONSTRAINT FK_Projects_Staff FOREIGN KEY ([PrincipalInvestigatorID])
            REFERENCES [dbo].[tblAcademicStaff]([StaffID])
    );

    CREATE INDEX IX_ResearchProjects_GrantScheme ON [dbo].[tblResearchProjects]([GrantScheme]);
    CREATE INDEX IX_ResearchProjects_Phase ON [dbo].[tblResearchProjects]([Phase]);
    CREATE INDEX IX_ResearchProjects_Status ON [dbo].[tblResearchProjects]([ProjectStatus]);
    CREATE INDEX IX_ResearchProjects_ResearchDomain ON [dbo].[tblResearchProjects]([ResearchDomain]);
    CREATE INDEX IX_ResearchProjects_PI ON [dbo].[tblResearchProjects]([PrincipalInvestigatorID]);
END
GO

-- =============================================
-- 3. Publications Table
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblPublications]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[tblPublications] (
        [PublicationID] INT PRIMARY KEY IDENTITY(1,1),
        [Title] NVARCHAR(500) NOT NULL,
        [PublicationType] NVARCHAR(50) NOT NULL,
        [PublicationYear] INT NOT NULL,
        [Authors] NVARCHAR(1000) NULL,
        [VenueName] NVARCHAR(300) NULL,
        [DOI] NVARCHAR(100) NULL,
        [Quartile] NVARCHAR(10) NULL,
        [CitationCount] INT DEFAULT 0,
        [LinkedProjectID] INT NULL,
        [GrantCode] NVARCHAR(50) NULL,
        [IsIndexed] BIT DEFAULT 0,
        [DatePublished] DATE NULL,
        [DateCreated] DATETIME DEFAULT GETDATE(),

        CONSTRAINT FK_Publications_Projects FOREIGN KEY ([LinkedProjectID])
            REFERENCES [dbo].[tblResearchProjects]([ProjectID])
    );

    CREATE INDEX IX_Publications_Type ON [dbo].[tblPublications]([PublicationType]);
    CREATE INDEX IX_Publications_Year ON [dbo].[tblPublications]([PublicationYear]);
    CREATE INDEX IX_Publications_Quartile ON [dbo].[tblPublications]([Quartile]);
    CREATE INDEX IX_Publications_IsIndexed ON [dbo].[tblPublications]([IsIndexed]);
    CREATE INDEX IX_Publications_LinkedProject ON [dbo].[tblPublications]([LinkedProjectID]);
END
GO

-- =============================================
-- 4. Grant Financial Records Table
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblGrantFinancials]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[tblGrantFinancials] (
        [GrantID] INT PRIMARY KEY IDENTITY(1,1),
        [GrantCode] NVARCHAR(50) NOT NULL UNIQUE,
        [GrantScheme] NVARCHAR(50) NOT NULL,
        [Phase] NVARCHAR(20) NOT NULL,
        [FiscalYear] INT NOT NULL,
        [AllocatedAmount] DECIMAL(18,2) DEFAULT 0,
        [SpentAmount] DECIMAL(18,2) DEFAULT 0,
        [BalanceAmount] DECIMAL(18,2) DEFAULT 0,
        [PercentageSpent] DECIMAL(5,2) DEFAULT 0,
        [TotalProjects] INT DEFAULT 0,
        [GrantStatus] NVARCHAR(50) DEFAULT 'Active',
        [DateCreated] DATETIME DEFAULT GETDATE(),
        [DateUpdated] DATETIME DEFAULT GETDATE()
    );

    CREATE INDEX IX_GrantFinancials_Scheme ON [dbo].[tblGrantFinancials]([GrantScheme]);
    CREATE INDEX IX_GrantFinancials_Phase ON [dbo].[tblGrantFinancials]([Phase]);
    CREATE INDEX IX_GrantFinancials_FiscalYear ON [dbo].[tblGrantFinancials]([FiscalYear]);
    CREATE INDEX IX_GrantFinancials_Status ON [dbo].[tblGrantFinancials]([GrantStatus]);
END
GO

-- =============================================
-- 5. Intellectual Property Table
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblIntellectualProperty]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[tblIntellectualProperty] (
        [IPID] INT PRIMARY KEY IDENTITY(1,1),
        [ApplicationNumber] NVARCHAR(50) NOT NULL UNIQUE,
        [IPTitle] NVARCHAR(500) NOT NULL,
        [IPType] NVARCHAR(50) NOT NULL,
        [Inventors] NVARCHAR(1000) NULL,
        [FilingDate] DATE NOT NULL,
        [GrantedDate] DATE NULL,
        [IPStatus] NVARCHAR(50) DEFAULT 'Filed',
        [LinkedProjectID] INT NULL,
        [DateCreated] DATETIME DEFAULT GETDATE(),
        [DateUpdated] DATETIME DEFAULT GETDATE(),

        CONSTRAINT FK_IP_Projects FOREIGN KEY ([LinkedProjectID])
            REFERENCES [dbo].[tblResearchProjects]([ProjectID])
    );

    CREATE INDEX IX_IP_Type ON [dbo].[tblIntellectualProperty]([IPType]);
    CREATE INDEX IX_IP_Status ON [dbo].[tblIntellectualProperty]([IPStatus]);
    CREATE INDEX IX_IP_LinkedProject ON [dbo].[tblIntellectualProperty]([LinkedProjectID]);
END
GO

-- =============================================
-- 6. Graduate Researchers Table
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblGraduateResearchers]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[tblGraduateResearchers] (
        [ResearcherID] INT PRIMARY KEY IDENTITY(1,1),
        [StudentID] NVARCHAR(20) NOT NULL UNIQUE,
        [FullName] NVARCHAR(200) NOT NULL,
        [ProgramLevel] NVARCHAR(50) NOT NULL,
        [SupervisorID] INT NOT NULL,
        [LinkedProjectID] INT NULL,
        [EnrollmentDate] DATE NOT NULL,
        [CompletionDate] DATE NULL,
        [ResearcherStatus] NVARCHAR(50) DEFAULT 'Active',
        [IsLocal] BIT DEFAULT 1,
        [DateCreated] DATETIME DEFAULT GETDATE(),

        CONSTRAINT FK_Researchers_Supervisor FOREIGN KEY ([SupervisorID])
            REFERENCES [dbo].[tblAcademicStaff]([StaffID]),
        CONSTRAINT FK_Researchers_Projects FOREIGN KEY ([LinkedProjectID])
            REFERENCES [dbo].[tblResearchProjects]([ProjectID])
    );

    CREATE INDEX IX_GraduateResearchers_ProgramLevel ON [dbo].[tblGraduateResearchers]([ProgramLevel]);
    CREATE INDEX IX_GraduateResearchers_Status ON [dbo].[tblGraduateResearchers]([ResearcherStatus]);
    CREATE INDEX IX_GraduateResearchers_Supervisor ON [dbo].[tblGraduateResearchers]([SupervisorID]);
    CREATE INDEX IX_GraduateResearchers_IsLocal ON [dbo].[tblGraduateResearchers]([IsLocal]);
END
GO

-- =============================================
-- 7. Audit Log Table for Exports
-- =============================================
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblAuditLog]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[tblAuditLog] (
        [AuditID] INT PRIMARY KEY IDENTITY(1,1),
        [UserName] NVARCHAR(100) NOT NULL,
        [ActionType] NVARCHAR(50) NOT NULL,
        [EntityType] NVARCHAR(50) NOT NULL,
        [ExportFormat] NVARCHAR(20) NULL,
        [RecordCount] INT DEFAULT 0,
        [FilterCriteria] NVARCHAR(MAX) NULL,
        [IPAddress] NVARCHAR(50) NULL,
        [DatePerformed] DATETIME DEFAULT GETDATE()
    );

    CREATE INDEX IX_AuditLog_UserName ON [dbo].[tblAuditLog]([UserName]);
    CREATE INDEX IX_AuditLog_ActionType ON [dbo].[tblAuditLog]([ActionType]);
    CREATE INDEX IX_AuditLog_DatePerformed ON [dbo].[tblAuditLog]([DatePerformed]);
END
GO

PRINT 'Database schema created successfully!';
GO
