-- =============================================
-- SMPPI PostgreSQL Database Schema
-- For Railway.app Deployment
-- =============================================

-- 1. Academic Staff Table
CREATE TABLE IF NOT EXISTS "tblAcademicStaff" (
    "StaffID" SERIAL PRIMARY KEY,
    "UMSPER" VARCHAR(20) NOT NULL UNIQUE,
    "FullName" VARCHAR(200) NOT NULL,
    "Position" VARCHAR(100),
    "Faculty" VARCHAR(100),
    "Department" VARCHAR(100),
    "Email" VARCHAR(100),
    "Phone" VARCHAR(50),
    "ResearchDomain" VARCHAR(100),
    "HIndex" INTEGER,
    "TotalPublications" INTEGER DEFAULT 0,
    "IsActive" BOOLEAN DEFAULT TRUE,
    "DateCreated" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    "DateUpdated" TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE INDEX IF NOT EXISTS idx_academicstaff_faculty ON "tblAcademicStaff"("Faculty");
CREATE INDEX IF NOT EXISTS idx_academicstaff_position ON "tblAcademicStaff"("Position");
CREATE INDEX IF NOT EXISTS idx_academicstaff_domain ON "tblAcademicStaff"("ResearchDomain");
CREATE INDEX IF NOT EXISTS idx_academicstaff_active ON "tblAcademicStaff"("IsActive");

-- 2. Research Projects Table
CREATE TABLE IF NOT EXISTS "tblResearchProjects" (
    "ProjectID" SERIAL PRIMARY KEY,
    "ProjectCode" VARCHAR(50) NOT NULL UNIQUE,
    "ProjectTitle" VARCHAR(500) NOT NULL,
    "PrincipalInvestigatorID" INTEGER NOT NULL,
    "GrantScheme" VARCHAR(50),
    "Phase" VARCHAR(20),
    "ResearchDomain" VARCHAR(100),
    "StartDate" DATE,
    "EndDate" DATE,
    "ExtensionDate" DATE,
    "AllocatedBudget" DECIMAL(18,2) DEFAULT 0,
    "SpentAmount" DECIMAL(18,2) DEFAULT 0,
    "ProgressPercentage" INTEGER DEFAULT 0,
    "ProjectStatus" VARCHAR(50) DEFAULT 'Active',
    "MilestonePercentage" INTEGER DEFAULT 0,
    "IsActive" BOOLEAN DEFAULT TRUE,
    "DateCreated" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    "DateUpdated" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT fk_projects_staff FOREIGN KEY ("PrincipalInvestigatorID")
        REFERENCES "tblAcademicStaff"("StaffID") ON DELETE RESTRICT
);

CREATE INDEX IF NOT EXISTS idx_projects_scheme ON "tblResearchProjects"("GrantScheme");
CREATE INDEX IF NOT EXISTS idx_projects_phase ON "tblResearchProjects"("Phase");
CREATE INDEX IF NOT EXISTS idx_projects_status ON "tblResearchProjects"("ProjectStatus");
CREATE INDEX IF NOT EXISTS idx_projects_domain ON "tblResearchProjects"("ResearchDomain");
CREATE INDEX IF NOT EXISTS idx_projects_pi ON "tblResearchProjects"("PrincipalInvestigatorID");

-- 3. Publications Table
CREATE TABLE IF NOT EXISTS "tblPublications" (
    "PublicationID" SERIAL PRIMARY KEY,
    "Title" VARCHAR(500) NOT NULL,
    "PublicationType" VARCHAR(50) NOT NULL,
    "PublicationYear" INTEGER NOT NULL,
    "Authors" VARCHAR(1000),
    "VenueName" VARCHAR(300),
    "DOI" VARCHAR(100),
    "Quartile" VARCHAR(10),
    "CitationCount" INTEGER DEFAULT 0,
    "LinkedProjectID" INTEGER,
    "GrantCode" VARCHAR(50),
    "IsIndexed" BOOLEAN DEFAULT FALSE,
    "DatePublished" DATE,
    "DateCreated" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT fk_publications_projects FOREIGN KEY ("LinkedProjectID")
        REFERENCES "tblResearchProjects"("ProjectID") ON DELETE SET NULL
);

CREATE INDEX IF NOT EXISTS idx_publications_type ON "tblPublications"("PublicationType");
CREATE INDEX IF NOT EXISTS idx_publications_year ON "tblPublications"("PublicationYear");
CREATE INDEX IF NOT EXISTS idx_publications_quartile ON "tblPublications"("Quartile");
CREATE INDEX IF NOT EXISTS idx_publications_indexed ON "tblPublications"("IsIndexed");
CREATE INDEX IF NOT EXISTS idx_publications_project ON "tblPublications"("LinkedProjectID");

-- 4. Grant Financials Table
CREATE TABLE IF NOT EXISTS "tblGrantFinancials" (
    "GrantID" SERIAL PRIMARY KEY,
    "GrantCode" VARCHAR(50) NOT NULL UNIQUE,
    "GrantScheme" VARCHAR(50) NOT NULL,
    "Phase" VARCHAR(20) NOT NULL,
    "FiscalYear" INTEGER NOT NULL,
    "AllocatedAmount" DECIMAL(18,2) DEFAULT 0,
    "SpentAmount" DECIMAL(18,2) DEFAULT 0,
    "BalanceAmount" DECIMAL(18,2) DEFAULT 0,
    "PercentageSpent" DECIMAL(5,2) DEFAULT 0,
    "TotalProjects" INTEGER DEFAULT 0,
    "GrantStatus" VARCHAR(50) DEFAULT 'Active',
    "DateCreated" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    "DateUpdated" TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE INDEX IF NOT EXISTS idx_grants_scheme ON "tblGrantFinancials"("GrantScheme");
CREATE INDEX IF NOT EXISTS idx_grants_phase ON "tblGrantFinancials"("Phase");
CREATE INDEX IF NOT EXISTS idx_grants_year ON "tblGrantFinancials"("FiscalYear");
CREATE INDEX IF NOT EXISTS idx_grants_status ON "tblGrantFinancials"("GrantStatus");

-- 5. Intellectual Property Table
CREATE TABLE IF NOT EXISTS "tblIntellectualProperty" (
    "IPID" SERIAL PRIMARY KEY,
    "ApplicationNumber" VARCHAR(50) NOT NULL UNIQUE,
    "IPTitle" VARCHAR(500) NOT NULL,
    "IPType" VARCHAR(50) NOT NULL,
    "Inventors" VARCHAR(1000),
    "FilingDate" DATE NOT NULL,
    "GrantedDate" DATE,
    "IPStatus" VARCHAR(50) DEFAULT 'Filed',
    "LinkedProjectID" INTEGER,
    "DateCreated" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    "DateUpdated" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT fk_ip_projects FOREIGN KEY ("LinkedProjectID")
        REFERENCES "tblResearchProjects"("ProjectID") ON DELETE SET NULL
);

CREATE INDEX IF NOT EXISTS idx_ip_type ON "tblIntellectualProperty"("IPType");
CREATE INDEX IF NOT EXISTS idx_ip_status ON "tblIntellectualProperty"("IPStatus");
CREATE INDEX IF NOT EXISTS idx_ip_project ON "tblIntellectualProperty"("LinkedProjectID");

-- 6. Graduate Researchers Table
CREATE TABLE IF NOT EXISTS "tblGraduateResearchers" (
    "ResearcherID" SERIAL PRIMARY KEY,
    "StudentID" VARCHAR(20) NOT NULL UNIQUE,
    "FullName" VARCHAR(200) NOT NULL,
    "ProgramLevel" VARCHAR(50) NOT NULL,
    "SupervisorID" INTEGER NOT NULL,
    "LinkedProjectID" INTEGER,
    "EnrollmentDate" DATE NOT NULL,
    "CompletionDate" DATE,
    "ResearcherStatus" VARCHAR(50) DEFAULT 'Active',
    "IsLocal" BOOLEAN DEFAULT TRUE,
    "DateCreated" TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT fk_researchers_supervisor FOREIGN KEY ("SupervisorID")
        REFERENCES "tblAcademicStaff"("StaffID") ON DELETE RESTRICT,
    CONSTRAINT fk_researchers_projects FOREIGN KEY ("LinkedProjectID")
        REFERENCES "tblResearchProjects"("ProjectID") ON DELETE SET NULL
);

CREATE INDEX IF NOT EXISTS idx_researchers_level ON "tblGraduateResearchers"("ProgramLevel");
CREATE INDEX IF NOT EXISTS idx_researchers_status ON "tblGraduateResearchers"("ResearcherStatus");
CREATE INDEX IF NOT EXISTS idx_researchers_supervisor ON "tblGraduateResearchers"("SupervisorID");
CREATE INDEX IF NOT EXISTS idx_researchers_local ON "tblGraduateResearchers"("IsLocal");

-- 7. Audit Log Table
CREATE TABLE IF NOT EXISTS "tblAuditLog" (
    "AuditID" SERIAL PRIMARY KEY,
    "UserName" VARCHAR(100) NOT NULL,
    "ActionType" VARCHAR(50) NOT NULL,
    "EntityType" VARCHAR(50) NOT NULL,
    "ExportFormat" VARCHAR(20),
    "RecordCount" INTEGER DEFAULT 0,
    "FilterCriteria" TEXT,
    "IPAddress" VARCHAR(50),
    "DatePerformed" TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE INDEX IF NOT EXISTS idx_audit_user ON "tblAuditLog"("UserName");
CREATE INDEX IF NOT EXISTS idx_audit_action ON "tblAuditLog"("ActionType");
CREATE INDEX IF NOT EXISTS idx_audit_date ON "tblAuditLog"("DatePerformed");

-- Success message
DO $$
BEGIN
    RAISE NOTICE 'PostgreSQL schema created successfully!';
END $$;
