-- =============================================
-- SMPPI PostgreSQL Sample Data Seed
-- For Railway.app Deployment
-- =============================================

-- 1. Insert Academic Staff
INSERT INTO "tblAcademicStaff" ("UMSPER", "FullName", "Position", "Faculty", "Department", "Email", "ResearchDomain", "HIndex", "TotalPublications")
VALUES
('UMS001', 'Dr. Ervin Gubin Moung', 'Senior Lecturer', 'Faculty of Computing and Informatics', 'Computer Science', 'ervin@ums.edu.my', 'ICT', 12, 45),
('UMS002', 'Dr. Yew Hoe Tung', 'Associate Professor', 'Faculty of Engineering', 'Electrical Engineering', 'yew@ums.edu.my', 'Technology and Engineering', 18, 68),
('UMS003', 'Dr. Aishah Tamby Omar', 'Senior Lecturer', 'Faculty of Business and Economics', 'Management', 'aishah@ums.edu.my', 'Social Science', 8, 32),
('UMS004', 'Prof. Dr. Mohammad Teridi Mohd Ali', 'Professor', 'Faculty of Science and Natural Resources', 'Physics', 'teridi@ums.edu.my', 'Pure and Applied Science', 25, 102),
('UMS005', 'Dr. Norhayati Ahmad', 'Senior Lecturer', 'Faculty of Medicine and Health Sciences', 'Public Health', 'norhayati@ums.edu.my', 'Clinical and Health Sciences', 15, 56),
('UMS006', 'Dr. Rozaimi Jamaluddin', 'Lecturer', 'Faculty of Science and Natural Resources', 'Environmental Science', 'rozaimi@ums.edu.my', 'Environment and Heritage', 10, 38),
('UMS007', 'Dr. Nur Athirah Sumardi', 'Lecturer', 'Faculty of Social Sciences and Humanities', 'Psychology', 'athirah@ums.edu.my', 'Social Science', 6, 24),
('UMS008', 'Prof. Dr. Siti Azizah Mohd Nor', 'Professor', 'Faculty of Science and Natural Resources', 'Biotechnology', 'azizah@ums.edu.my', 'Pure and Applied Science', 30, 125)
ON CONFLICT ("UMSPER") DO NOTHING;

-- 2. Insert Grant Financials
INSERT INTO "tblGrantFinancials" ("GrantCode", "GrantScheme", "Phase", "FiscalYear", "AllocatedAmount", "SpentAmount", "BalanceAmount", "PercentageSpent", "TotalProjects", "GrantStatus")
VALUES
('FRGS/1/2020', 'FRGS', 'Fasa 1/2020', 2020, 2600515.00, 2340463.50, 260051.50, 90.00, 26, 'Completed'),
('FRGS/1/2021', 'FRGS', 'Fasa 1/2021', 2021, 1118062.00, 950752.70, 167309.30, 85.04, 9, 'Completed'),
('FRGS/1/2022', 'FRGS', 'Fasa 1/2022', 2022, 3941772.00, 3547594.80, 394177.20, 90.00, 30, 'Active'),
('FRGS/1/2023', 'FRGS', 'Fasa 1/2023', 2023, 3486722.00, 2789377.60, 697344.40, 80.00, 29, 'Active'),
('FRGS/1/2024', 'FRGS', 'Fasa 1/2024', 2024, 2913753.00, 1456876.50, 1456876.50, 50.00, 25, 'Active')
ON CONFLICT ("GrantCode") DO NOTHING;

-- 3. Insert Research Projects (Sample)
INSERT INTO "tblResearchProjects" ("ProjectCode", "ProjectTitle", "PrincipalInvestigatorID", "GrantScheme", "Phase", "ResearchDomain", "StartDate", "EndDate", "AllocatedBudget", "SpentAmount", "ProgressPercentage", "ProjectStatus")
VALUES
('FRGS/1/2020/SS01/UMS/02/1', 'Investigation of Feature-Aware Self-Supervised Learning for Speech Recognition', 1, 'FRGS', 'Fasa 1/2020', 'ICT', '2020-07-01', '2023-06-30', 100000.00, 95000.00, 100, 'Completed'),
('FRGS/1/2020/TK0/UMS/02/6', 'Handover Algorithm for Telecardiology in 5G Networks', 2, 'FRGS', 'Fasa 1/2020', 'Technology and Engineering', '2020-07-01', '2023-06-30', 100000.00, 98000.00, 100, 'Completed'),
('FRGS/1/2020/SS02/UMS/02/1', 'Model Pengurusan Integrasi Asnaf Berdasarkan Konsep Islam', 3, 'FRGS', 'Fasa 1/2020', 'Social Science', '2020-07-01', '2023-06-30', 100000.00, 92000.00, 100, 'Completed'),
('FRGS/1/2020/STG06/UMS/02/1', 'High-Performance Perovskite Solar Cells Development', 4, 'FRGS', 'Fasa 1/2020', 'Pure and Applied Science', '2020-07-01', '2023-06-30', 100000.00, 97000.00, 100, 'Completed'),
('FRGS/1/2022/TK07/UMS/02/15', 'Smart Manufacturing System Integration Using IIoT', 2, 'FRGS', 'Fasa 1/2022', 'Technology and Engineering', '2022-07-01', '2025-06-30', 131392.40, 105113.92, 80, 'OnSchedule'),
('FRGS/1/2024/SS01/UMS/02/6', 'AI and Machine Learning for Cybersecurity Applications', 1, 'FRGS', 'Fasa 1/2024', 'ICT', '2024-07-01', '2027-06-30', 116550.12, 46620.05, 40, 'Active')
ON CONFLICT ("ProjectCode") DO NOTHING;

-- 4. Insert Publications (Sample)
INSERT INTO "tblPublications" ("Title", "PublicationType", "PublicationYear", "Authors", "VenueName", "DOI", "Quartile", "CitationCount", "LinkedProjectID", "IsIndexed", "DatePublished")
VALUES
('Feature-Aware Self-Supervised Learning for Low-Resource Speech Recognition', 'JournalIndexed', 2021, 'Ervin Gubin Moung, et al.', 'IEEE Transactions on Audio, Speech, and Language Processing', '10.1109/TASLP.2021.001', 'Q1', 24, 1, TRUE, '2021-03-15'),
('Fuzzy Logic Based Handover Algorithm for 5G Healthcare', 'JournalIndexed', 2021, 'Yew Hoe Tung, et al.', 'IEEE Access', '10.1109/ACCESS.2021.002', 'Q1', 18, 2, TRUE, '2021-05-20'),
('High-Performance Perovskite Solar Cells with Novel Materials', 'JournalIndexed', 2022, 'Mohammad Teridi Mohd Ali, et al.', 'Advanced Energy Materials', '10.1002/aenm.2022.003', 'Q1', 45, 4, TRUE, '2022-01-25'),
('Industrial IoT Integration Framework for Smart Manufacturing', 'JournalIndexed', 2023, 'Yew Hoe Tung, et al.', 'IEEE Transactions on Industrial Informatics', '10.1109/TII.2023.007', 'Q1', 15, 5, TRUE, '2023-03-08')
ON CONFLICT DO NOTHING;

-- 5. Insert Intellectual Property (Sample)
INSERT INTO "tblIntellectualProperty" ("ApplicationNumber", "IPTitle", "IPType", "Inventors", "FilingDate", "GrantedDate", "IPStatus", "LinkedProjectID")
VALUES
('PI2021001234', 'Feature Extraction System for Low-Resource Speech Recognition', 'Patent', 'Ervin Gubin Moung, Co-Inventors', '2021-06-15', '2023-12-20', 'Granted', 1),
('PI2021005678', 'Fuzzy Logic Controller for 5G Network Handover', 'Patent', 'Yew Hoe Tung, Co-Inventors', '2021-08-20', NULL, 'Pending', 2),
('CR2022009876', 'Perovskite Solar Cell Manufacturing Process', 'Copyright', 'Mohammad Teridi Mohd Ali, Co-Inventors', '2022-03-10', '2022-09-15', 'Registered', 4)
ON CONFLICT ("ApplicationNumber") DO NOTHING;

-- 6. Insert Graduate Researchers (Sample)
INSERT INTO "tblGraduateResearchers" ("StudentID", "FullName", "ProgramLevel", "SupervisorID", "LinkedProjectID", "EnrollmentDate", "ResearcherStatus", "IsLocal")
VALUES
('PHD2020001', 'Ahmad bin Abdullah', 'PhD', 1, 1, '2020-09-01', 'Graduated', TRUE),
('MST2021002', 'Nurul Aisyah binti Hassan', 'Master', 2, 2, '2021-09-01', 'Active', TRUE),
('PHD2021003', 'John Wei Chen', 'PhD', 4, 4, '2021-09-01', 'Active', FALSE),
('MST2022004', 'Siti Nor Hana binti Ismail', 'Master', 3, 3, '2022-09-01', 'Active', TRUE)
ON CONFLICT ("StudentID") DO NOTHING;

-- Success message
DO $$
DECLARE
    staff_count INT;
    project_count INT;
    pub_count INT;
BEGIN
    SELECT COUNT(*) INTO staff_count FROM "tblAcademicStaff";
    SELECT COUNT(*) INTO project_count FROM "tblResearchProjects";
    SELECT COUNT(*) INTO pub_count FROM "tblPublications";

    RAISE NOTICE 'Sample data seeded successfully!';
    RAISE NOTICE 'Academic Staff: %', staff_count;
    RAISE NOTICE 'Research Projects: %', project_count;
    RAISE NOTICE 'Publications: %', pub_count;
END $$;
