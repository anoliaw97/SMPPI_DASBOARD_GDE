-- =============================================
-- SMPPI Sample Data Seed Script
-- Based on FRGS 2020-2024 Data
-- =============================================

USE SMPPI_DB;
GO

-- =============================================
-- 1. Insert Academic Staff
-- =============================================
SET IDENTITY_INSERT [dbo].[tblAcademicStaff] ON;

INSERT INTO [dbo].[tblAcademicStaff] ([StaffID], [UMSPER], [FullName], [Position], [Faculty], [Department], [Email], [Phone], [ResearchDomain], [HIndex], [TotalPublications], [IsActive], [DateCreated])
VALUES
(1, 'UMS001', 'Dr. Ervin Gubin Moung', 'Senior Lecturer', 'Faculty of Computing and Informatics', 'Computer Science', 'ervin@ums.edu.my', '088-320000', 'ICT', 12, 45, 1, GETDATE()),
(2, 'UMS002', 'Dr. Yew Hoe Tung', 'Associate Professor', 'Faculty of Engineering', 'Electrical Engineering', 'yew@ums.edu.my', '088-320001', 'Technology and Engineering', 18, 68, 1, GETDATE()),
(3, 'UMS003', 'Dr. Aishah Tamby Omar', 'Senior Lecturer', 'Faculty of Business and Economics', 'Management', 'aishah@ums.edu.my', '088-320002', 'Social Science', 8, 32, 1, GETDATE()),
(4, 'UMS004', 'Prof. Dr. Mohammad Teridi Mohd Ali', 'Professor', 'Faculty of Science and Natural Resources', 'Physics', 'teridi@ums.edu.my', '088-320003', 'Pure and Applied Science', 25, 102, 1, GETDATE()),
(5, 'UMS005', 'Dr. Norhayati Ahmad', 'Senior Lecturer', 'Faculty of Medicine and Health Sciences', 'Public Health', 'norhayati@ums.edu.my', '088-320004', 'Clinical and Health Sciences', 15, 56, 1, GETDATE()),
(6, 'UMS006', 'Dr. Rozaimi Jamaluddin', 'Lecturer', 'Faculty of Science and Natural Resources', 'Environmental Science', 'rozaimi@ums.edu.my', '088-320005', 'Environment and Heritage', 10, 38, 1, GETDATE()),
(7, 'UMS007', 'Dr. Nur Athirah Sumardi', 'Lecturer', 'Faculty of Social Sciences and Humanities', 'Psychology', 'athirah@ums.edu.my', '088-320006', 'Social Science', 6, 24, 1, GETDATE()),
(8, 'UMS008', 'Prof. Dr. Siti Azizah Mohd Nor', 'Professor', 'Faculty of Science and Natural Resources', 'Biotechnology', 'azizah@ums.edu.my', '088-320007', 'Pure and Applied Science', 30, 125, 1, GETDATE()),
(9, 'UMS009', 'Dr. Ahmad Faisal Mohamad Ayob', 'Associate Professor', 'Faculty of Engineering', 'Mechanical Engineering', 'faisal@ums.edu.my', '088-320008', 'Technology and Engineering', 14, 51, 1, GETDATE()),
(10, 'UMS010', 'Dr. Noor Azreen Masdor', 'Senior Lecturer', 'Faculty of Arts and Cultural Heritage', 'Fine Arts', 'azreen@ums.edu.my', '088-320009', 'Arts and Applied Arts', 7, 28, 1, GETDATE()),
(11, 'UMS011', 'Dr. Mohd Hasmadi Ismail', 'Lecturer', 'Faculty of Science and Natural Resources', 'Forestry', 'hasmadi@ums.edu.my', '088-320010', 'Environment and Heritage', 9, 35, 1, GETDATE()),
(12, 'UMS012', 'Dr. Siti Munira Jamil', 'Senior Lecturer', 'Faculty of Computing and Informatics', 'Information Systems', 'munira@ums.edu.my', '088-320011', 'ICT', 11, 42, 1, GETDATE()),
(13, 'UMS013', 'Dr. Roslina Othman', 'Associate Professor', 'Faculty of Business and Economics', 'Accounting', 'roslina@ums.edu.my', '088-320012', 'Social Science', 13, 48, 1, GETDATE()),
(14, 'UMS014', 'Dr. Kamarul Ariffin Hambali', 'Lecturer', 'Faculty of Engineering', 'Civil Engineering', 'kamarul@ums.edu.my', '088-320013', 'Technology and Engineering', 8, 31, 1, GETDATE()),
(15, 'UMS015', 'Dr. Farah Liyana Azizan', 'Senior Lecturer', 'Faculty of Medicine and Health Sciences', 'Nursing', 'farah@ums.edu.my', '088-320014', 'Clinical and Health Sciences', 12, 44, 1, GETDATE());

SET IDENTITY_INSERT [dbo].[tblAcademicStaff] OFF;
GO

-- =============================================
-- 2. Insert Grant Financials (FRGS 2020-2024)
-- =============================================
SET IDENTITY_INSERT [dbo].[tblGrantFinancials] ON;

INSERT INTO [dbo].[tblGrantFinancials] ([GrantID], [GrantCode], [GrantScheme], [Phase], [FiscalYear], [AllocatedAmount], [SpentAmount], [BalanceAmount], [PercentageSpent], [TotalProjects], [GrantStatus])
VALUES
(1, 'FRGS/1/2020', 'FRGS', 'Fasa 1/2020', 2020, 2600515.00, 2340463.50, 260051.50, 90.00, 26, 'Completed'),
(2, 'FRGS/1/2021', 'FRGS', 'Fasa 1/2021', 2021, 1118062.00, 950752.70, 167309.30, 85.04, 9, 'Completed'),
(3, 'FRGS/1/2022', 'FRGS', 'Fasa 1/2022', 2022, 3941772.00, 3547594.80, 394177.20, 90.00, 30, 'Active'),
(4, 'FRGS/1/2023', 'FRGS', 'Fasa 1/2023', 2023, 3486722.00, 2789377.60, 697344.40, 80.00, 29, 'Active'),
(5, 'FRGS/1/2024', 'FRGS', 'Fasa 1/2024', 2024, 2913753.00, 1456876.50, 1456876.50, 50.00, 25, 'Active');

SET IDENTITY_INSERT [dbo].[tblGrantFinancials] OFF;
GO

-- =============================================
-- 3. Insert Research Projects (Sample from FRGS 2020-2024)
-- =============================================
SET IDENTITY_INSERT [dbo].[tblResearchProjects] ON;

INSERT INTO [dbo].[tblResearchProjects] ([ProjectID], [ProjectCode], [ProjectTitle], [PrincipalInvestigatorID], [GrantScheme], [Phase], [ResearchDomain], [StartDate], [EndDate], [AllocatedBudget], [SpentAmount], [ProgressPercentage], [ProjectStatus], [MilestonePercentage])
VALUES
-- FRGS 2020 Projects
(1, 'FRGS/1/2020/SS01/UMS/02/1', 'Investigation of Feature-Aware Self-Supervised Learning for Automatic Speech Recognition in Low-Resource Languages', 1, 'FRGS', 'Fasa 1/2020', 'ICT', '2020-07-01', '2023-06-30', 100000.00, 95000.00, 100, 'Completed', 100),
(2, 'FRGS/1/2020/TK0/UMS/02/6', 'Handover Algorithm for Telecardiology in 5G Networks Based on Fuzzy Logic and Software Defined Network', 2, 'FRGS', 'Fasa 1/2020', 'Technology and Engineering', '2020-07-01', '2023-06-30', 100000.00, 98000.00, 100, 'Completed', 100),
(3, 'FRGS/1/2020/SS02/UMS/02/1', 'Model Pengurusan Integrasi Asnaf Berdasarkan Konsep Pembangunan Manusia dalam Islam', 3, 'FRGS', 'Fasa 1/2020', 'Social Science', '2020-07-01', '2023-06-30', 100000.00, 92000.00, 100, 'Completed', 100),
(4, 'FRGS/1/2020/STG06/UMS/02/1', 'Development of High-Performance Perovskite Solar Cells Using Novel Charge Transport Materials', 4, 'FRGS', 'Fasa 1/2020', 'Pure and Applied Science', '2020-07-01', '2023-06-30', 100000.00, 97000.00, 100, 'Completed', 100),
(5, 'FRGS/1/2020/SKK06/UMS/02/3', 'Mental Health Literacy and Help-Seeking Behavior Among University Students in Sabah', 5, 'FRGS', 'Fasa 1/2020', 'Clinical and Health Sciences', '2020-07-01', '2023-06-30', 100000.00, 94000.00, 100, 'Completed', 100),

-- FRGS 2021 Projects
(6, 'FRGS/1/2021/WAB13/UMS/02/1', 'Biodiversity Assessment and Conservation Strategies for Mangrove Forests in Sabah', 6, 'FRGS', 'Fasa 1/2021', 'Environment and Heritage', '2021-07-01', '2024-06-30', 124229.00, 105394.65, 85, 'Active', 85),
(7, 'FRGS/1/2021/SS01/UMS/02/2', 'Cultural Identity and Social Integration of Indigenous Communities in Digital Era', 7, 'FRGS', 'Fasa 1/2021', 'Social Science', '2021-07-01', '2024-06-30', 124229.00, 99383.20, 80, 'Active', 80),
(8, 'FRGS/1/2021/STG06/UMS/02/3', 'Novel Biopolymer-Based Materials for Environmental Remediation Applications', 8, 'FRGS', 'Fasa 1/2021', 'Pure and Applied Science', '2021-07-01', '2024-06-30', 124229.00, 111806.10, 90, 'Active', 90),

-- FRGS 2022 Projects
(9, 'FRGS/1/2022/TK07/UMS/02/15', 'Smart Manufacturing System Integration Using Industrial Internet of Things', 9, 'FRGS', 'Fasa 1/2022', 'Technology and Engineering', '2022-07-01', '2025-06-30', 131392.40, 105113.92, 80, 'OnSchedule', 75),
(10, 'FRGS/1/2022/SSI16/UMS/02/1', 'Traditional Arts and Digital Preservation: Case Study of Sabah Indigenous Crafts', 10, 'FRGS', 'Fasa 1/2022', 'Arts and Applied Arts', '2022-07-01', '2025-06-30', 131392.40, 91975.68, 70, 'OnSchedule', 65),
(11, 'FRGS/1/2022/WAB13/UMS/02/5', 'Sustainable Forest Management Practices for Climate Change Mitigation', 11, 'FRGS', 'Fasa 1/2022', 'Environment and Heritage', '2022-07-01', '2025-06-30', 131392.40, 118253.16, 90, 'OnSchedule', 85),
(12, 'FRGS/1/2022/SS01/UMS/02/4', 'Big Data Analytics for Business Intelligence in Small and Medium Enterprises', 12, 'FRGS', 'Fasa 1/2022', 'ICT', '2022-07-01', '2025-06-30', 131392.40, 105113.92, 80, 'OnSchedule', 78),

-- FRGS 2023 Projects
(13, 'FRGS/1/2023/SS02/UMS/02/3', 'Financial Inclusion and Digital Banking Adoption in Rural Communities', 13, 'FRGS', 'Fasa 1/2023', 'Social Science', '2023-07-01', '2026-06-30', 120232.48, 72139.49, 60, 'OnSchedule', 55),
(14, 'FRGS/1/2023/TK07/UMS/02/8', 'Advanced Materials for Green Building Construction in Tropical Climate', 14, 'FRGS', 'Fasa 1/2023', 'Technology and Engineering', '2023-07-01', '2026-06-30', 120232.48, 84162.74, 70, 'OnSchedule', 68),
(15, 'FRGS/1/2023/SKK06/UMS/02/5', 'Community-Based Health Promotion for Non-Communicable Disease Prevention', 15, 'FRGS', 'Fasa 1/2023', 'Clinical and Health Sciences', '2023-07-01', '2026-06-30', 120232.48, 96185.98, 80, 'OnSchedule', 75),

-- FRGS 2024 Projects
(16, 'FRGS/1/2024/SS01/UMS/02/6', 'Artificial Intelligence and Machine Learning Applications in Cybersecurity', 1, 'FRGS', 'Fasa 1/2024', 'ICT', '2024-07-01', '2027-06-30', 116550.12, 46620.05, 40, 'Active', 35),
(17, 'FRGS/1/2024/TK07/UMS/02/12', 'Renewable Energy Integration in Microgrids for Rural Electrification', 2, 'FRGS', 'Fasa 1/2024', 'Technology and Engineering', '2024-07-01', '2027-06-30', 116550.12, 58275.06, 50, 'Active', 48),
(18, 'FRGS/1/2024/STG06/UMS/02/8', 'Nanotechnology Applications in Drug Delivery Systems', 4, 'FRGS', 'Fasa 1/2024', 'Pure and Applied Science', '2024-07-01', '2027-06-30', 116550.12, 40992.54, 35, 'Active', 32),
(19, 'FRGS/1/2024/WAB13/UMS/02/9', 'Ecosystem Services Valuation for Sustainable Tourism Development', 6, 'FRGS', 'Fasa 1/2024', 'Environment and Heritage', '2024-07-01', '2027-06-30', 116550.12, 52447.55, 45, 'Active', 42),
(20, 'FRGS/1/2024/SS02/UMS/02/7', 'Social Entrepreneurship and Community Development in Post-Pandemic Era', 3, 'FRGS', 'Fasa 1/2024', 'Social Science', '2024-07-01', '2027-06-30', 116550.12, 34965.04, 30, 'Active', 28);

SET IDENTITY_INSERT [dbo].[tblResearchProjects] OFF;
GO

-- =============================================
-- 4. Insert Publications (Sample data)
-- =============================================
SET IDENTITY_INSERT [dbo].[tblPublications] ON;

INSERT INTO [dbo].[tblPublications] ([PublicationID], [Title], [PublicationType], [PublicationYear], [Authors], [VenueName], [DOI], [Quartile], [CitationCount], [LinkedProjectID], [GrantCode], [IsIndexed], [DatePublished])
VALUES
-- 2020 Publications
(1, 'Feature-Aware Self-Supervised Learning for Low-Resource Speech Recognition', 'JournalIndexed', 2021, 'Ervin Gubin Moung, et al.', 'IEEE Transactions on Audio, Speech, and Language Processing', '10.1109/TASLP.2021.001', 'Q1', 24, 1, 'FRGS/1/2020/SS01/UMS/02/1', 1, '2021-03-15'),
(2, 'Fuzzy Logic Based Handover Algorithm for 5G Networks in Healthcare Applications', 'JournalIndexed', 2021, 'Yew Hoe Tung, et al.', 'IEEE Access', '10.1109/ACCESS.2021.002', 'Q1', 18, 2, 'FRGS/1/2020/TK0/UMS/02/6', 1, '2021-05-20'),
(3, 'Islamic Human Development Model for Asnaf Management Integration', 'JournalNonIndexed', 2021, 'Aishah Tamby Omar, et al.', 'Journal of Islamic Social Sciences', NULL, NULL, 5, 3, 'FRGS/1/2020/SS02/UMS/02/1', 0, '2021-08-10'),
(4, 'High-Performance Perovskite Solar Cells with Novel Charge Transport Layers', 'JournalIndexed', 2022, 'Mohammad Teridi Mohd Ali, et al.', 'Advanced Energy Materials', '10.1002/aenm.2022.003', 'Q1', 45, 4, 'FRGS/1/2020/STG06/UMS/02/1', 1, '2022-01-25'),
(5, 'Mental Health Literacy Among University Students: A Cross-Sectional Study', 'JournalIndexed', 2021, 'Norhayati Ahmad, et al.', 'BMC Public Health', '10.1186/s12889-021-004', 'Q2', 32, 5, 'FRGS/1/2020/SKK06/UMS/02/3', 1, '2021-11-12'),

-- 2021-2022 Publications
(6, 'Mangrove Biodiversity and Carbon Sequestration in Sabah Coastal Areas', 'JournalIndexed', 2022, 'Rozaimi Jamaluddin, et al.', 'Estuarine, Coastal and Shelf Science', '10.1016/j.ecss.2022.005', 'Q1', 28, 6, 'FRGS/1/2021/WAB13/UMS/02/1', 1, '2022-06-18'),
(7, 'Digital Transformation and Cultural Identity of Indigenous Communities', 'ConfInternational', 2022, 'Nur Athirah Sumardi, et al.', 'International Conference on Social Sciences', NULL, NULL, 8, 7, 'FRGS/1/2021/SS01/UMS/02/2', 0, '2022-09-05'),
(8, 'Biopolymer-Based Adsorbents for Heavy Metal Removal from Wastewater', 'JournalIndexed', 2022, 'Siti Azizah Mohd Nor, et al.', 'Journal of Hazardous Materials', '10.1016/j.jhazmat.2022.006', 'Q1', 38, 8, 'FRGS/1/2021/STG06/UMS/02/3', 1, '2022-11-22'),

-- 2023 Publications
(9, 'Industrial IoT Integration Framework for Smart Manufacturing Systems', 'JournalIndexed', 2023, 'Ahmad Faisal Mohamad Ayob, et al.', 'IEEE Transactions on Industrial Informatics', '10.1109/TII.2023.007', 'Q1', 15, 9, 'FRGS/1/2022/TK07/UMS/02/15', 1, '2023-03-08'),
(10, 'Digital Preservation of Sabah Indigenous Crafts Using 3D Scanning Technology', 'ConfInternational', 2023, 'Noor Azreen Masdor, et al.', 'International Conference on Digital Heritage', NULL, NULL, 6, 10, 'FRGS/1/2022/SSI16/UMS/02/1', 0, '2023-05-15'),
(11, 'Climate Change Mitigation Through Sustainable Forest Management Practices', 'JournalIndexed', 2023, 'Mohd Hasmadi Ismail, et al.', 'Forest Ecology and Management', '10.1016/j.foreco.2023.008', 'Q1', 22, 11, 'FRGS/1/2022/WAB13/UMS/02/5', 1, '2023-07-20'),
(12, 'Big Data Analytics Framework for SME Business Intelligence', 'JournalIndexed', 2023, 'Siti Munira Jamil, et al.', 'Information Systems Frontiers', '10.1007/s10796-023-009', 'Q2', 12, 12, 'FRGS/1/2022/SS01/UMS/02/4', 1, '2023-09-10'),

-- 2024 Publications
(13, 'Digital Banking Adoption and Financial Inclusion in Rural Malaysia', 'JournalIndexed', 2024, 'Roslina Othman, et al.', 'Journal of Banking & Finance', '10.1016/j.jbankfin.2024.010', 'Q1', 8, 13, 'FRGS/1/2023/SS02/UMS/02/3', 1, '2024-02-14'),
(14, 'Green Building Materials for Tropical Climate: Performance Evaluation', 'JournalIndexed', 2024, 'Kamarul Ariffin Hambali, et al.', 'Building and Environment', '10.1016/j.buildenv.2024.011', 'Q1', 10, 14, 'FRGS/1/2023/TK07/UMS/02/8', 1, '2024-04-22'),
(15, 'Community-Based Interventions for NCD Prevention: A Systematic Review', 'JournalIndexed', 2024, 'Farah Liyana Azizan, et al.', 'Preventive Medicine', '10.1016/j.ypmed.2024.012', 'Q2', 7, 15, 'FRGS/1/2023/SKK06/UMS/02/5', 1, '2024-06-18'),

-- Conference Papers
(16, 'Machine Learning Approaches for Network Intrusion Detection', 'ConfInternational', 2024, 'Ervin Gubin Moung, et al.', 'IEEE International Conference on Cybersecurity', NULL, NULL, 3, 16, 'FRGS/1/2024/SS01/UMS/02/6', 0, '2024-10-15'),
(17, 'Microgrid Optimization for Rural Electrification Using Renewable Energy', 'ConfInternational', 2024, 'Yew Hoe Tung, et al.', 'International Conference on Renewable Energy', NULL, NULL, 4, 17, 'FRGS/1/2024/TK07/UMS/02/12', 0, '2024-11-08');

SET IDENTITY_INSERT [dbo].[tblPublications] OFF;
GO

-- =============================================
-- 5. Insert Intellectual Property
-- =============================================
SET IDENTITY_INSERT [dbo].[tblIntellectualProperty] ON;

INSERT INTO [dbo].[tblIntellectualProperty] ([IPID], [ApplicationNumber], [IPTitle], [IPType], [Inventors], [FilingDate], [GrantedDate], [IPStatus], [LinkedProjectID])
VALUES
(1, 'PI2021001234', 'Feature Extraction System for Low-Resource Speech Recognition', 'Patent', 'Ervin Gubin Moung, Co-Inventors', '2021-06-15', '2023-12-20', 'Granted', 1),
(2, 'PI2021005678', 'Fuzzy Logic Controller for 5G Network Handover', 'Patent', 'Yew Hoe Tung, Co-Inventors', '2021-08-20', NULL, 'Pending', 2),
(3, 'CR2022009876', 'Perovskite Solar Cell Manufacturing Process', 'Copyright', 'Mohammad Teridi Mohd Ali, Co-Inventors', '2022-03-10', '2022-09-15', 'Registered', 4),
(4, 'PI2023002345', 'Biopolymer-Based Water Filtration System', 'Patent', 'Siti Azizah Mohd Nor, Co-Inventors', '2023-02-18', NULL, 'Filed', 8),
(5, 'ID2023006789', '3D Scanning System for Cultural Heritage Preservation', 'IndustrialDesign', 'Noor Azreen Masdor, Co-Inventors', '2023-07-25', '2024-01-30', 'Granted', 10);

SET IDENTITY_INSERT [dbo].[tblIntellectualProperty] OFF;
GO

-- =============================================
-- 6. Insert Graduate Researchers
-- =============================================
SET IDENTITY_INSERT [dbo].[tblGraduateResearchers] ON;

INSERT INTO [dbo].[tblGraduateResearchers] ([ResearcherID], [StudentID], [FullName], [ProgramLevel], [SupervisorID], [LinkedProjectID], [EnrollmentDate], [CompletionDate], [ResearcherStatus], [IsLocal])
VALUES
(1, 'PHD2020001', 'Ahmad bin Abdullah', 'PhD', 1, 1, '2020-09-01', '2024-08-31', 'Graduated', 1),
(2, 'MST2021002', 'Nurul Aisyah binti Hassan', 'Master', 2, 2, '2021-09-01', NULL, 'Active', 1),
(3, 'PHD2021003', 'John Wei Chen', 'PhD', 4, 4, '2021-09-01', NULL, 'Active', 0),
(4, 'MST2022004', 'Siti Nor Hana binti Ismail', 'Master', 5, 5, '2022-09-01', NULL, 'Active', 1),
(5, 'PHD2022005', 'Muhammad Firdaus bin Ramli', 'PhD', 6, 6, '2022-09-01', NULL, 'Active', 1),
(6, 'MST2023006', 'Lily Tan Mei Ling', 'Master', 8, 8, '2023-09-01', NULL, 'Active', 1),
(7, 'PHD2023007', 'Abdul Rahman bin Yusof', 'PhD', 9, 9, '2023-09-01', NULL, 'Active', 1),
(8, 'MST2024008', 'Priya Devi Kumar', 'Master', 12, 12, '2024-09-01', NULL, 'Active', 0);

SET IDENTITY_INSERT [dbo].[tblGraduateResearchers] OFF;
GO

-- =============================================
-- Update Statistics
-- =============================================
UPDATE s
SET TotalPublications = (
    SELECT COUNT(*)
    FROM tblPublications p
    INNER JOIN tblResearchProjects pr ON p.LinkedProjectID = pr.ProjectID
    WHERE pr.PrincipalInvestigatorID = s.StaffID
)
FROM tblAcademicStaff s;
GO

PRINT 'Sample data seeded successfully!';
PRINT 'Total Academic Staff: ' + CAST((SELECT COUNT(*) FROM tblAcademicStaff) AS VARCHAR);
PRINT 'Total Research Projects: ' + CAST((SELECT COUNT(*) FROM tblResearchProjects) AS VARCHAR);
PRINT 'Total Publications: ' + CAST((SELECT COUNT(*) FROM tblPublications) AS VARCHAR);
PRINT 'Total IP Records: ' + CAST((SELECT COUNT(*) FROM tblIntellectualProperty) AS VARCHAR);
PRINT 'Total Graduate Researchers: ' + CAST((SELECT COUNT(*) FROM tblGraduateResearchers) AS VARCHAR);
GO
