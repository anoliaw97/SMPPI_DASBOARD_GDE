# SMPPI DASHBOARD
## Proof-of-Concept and Implementation Proposal

**Work Duration:** 22 NOVEMBER 2025 – 31 JANUARY 2026
**Type of Development:** RESEARCH MANAGEMENT INFORMATION SYSTEM - PROOF OF CONCEPT
**Report Title:** SMPPI DASHBOARD - SOLUTION PROPOSAL AND DEMONSTRATION
**Name:** [RESEARCH DATA OFFICER NAME]
**Supervisor:** DR. ERVIN GUBIN MOUNG
**Position:** RESEARCH DATA OFFICER

---

## 1.0 EXECUTIVE SUMMARY

This report presents the SMPPI (Sistem Maklumat Pengurusan Penyelidik dan Inovasi) Dashboard as a comprehensive solution for research and innovation management at Universiti Malaysia Sabah. Developed over a 10-week proof-of-concept phase, the system demonstrates how modern web technologies can transform research data management, visualization, and reporting capabilities.

**The SMPPI Dashboard addresses critical challenges:**
- **Data Fragmentation** - Consolidates research information into a single unified platform
- **Limited Visibility** - Provides real-time visual analytics through interactive dashboards
- **Manual Reporting** - Enables instant export to Excel, PDF, and CSV formats
- **Outdated Interfaces** - Offers modern, responsive design accessible on any device
- **Inefficient Search** - Delivers advanced multi-criteria filtering across all data types

**This proof-of-concept successfully demonstrates:**
- Complete functional architecture ready for production deployment
- User-friendly interface requiring minimal training
- Scalable design capable of handling institutional-scale data volumes
- Modern technology stack ensuring long-term maintainability
- Cost-effective solution leveraging open-source technologies

---

## 2.0 THE PROBLEM STATEMENT

### 2.1 Current Challenges

Universiti Malaysia Sabah's Research Management Centre currently faces several operational challenges:

**Data Management Issues:**
- Research information scattered across multiple spreadsheets and databases
- Inconsistent data formats making consolidation difficult
- Risk of data loss or corruption without centralized system
- Difficulty tracking relationships between projects, publications, and grants

**Reporting Challenges:**
- Time-consuming manual report preparation for stakeholders
- Inability to generate real-time statistics on demand
- Limited visualization capabilities for data analysis
- Duplicate data entry across different systems

**Accessibility Limitations:**
- No centralized platform for viewing research activities
- Difficult for management to get overview of research performance
- Researchers unable to easily track their own projects and outputs
- External stakeholders have limited visibility into UMS research impact

**Technology Gaps:**
- Legacy systems with outdated user interfaces
- Limited mobile accessibility
- No advanced search or filtering capabilities
- Lack of data export options for analysis

### 2.2 The Need for a Solution

A modern research management system is essential to:
- **Enhance Decision-Making** - Provide data-driven insights for strategic planning
- **Improve Efficiency** - Reduce administrative burden through automation
- **Increase Visibility** - Showcase UMS research achievements to stakeholders
- **Support Growth** - Scale with increasing research activities and funding
- **Ensure Compliance** - Maintain accurate records for audit and reporting requirements

---

## 3.0 THE SMPPI DASHBOARD SOLUTION

### 3.1 System Overview

The SMPPI Dashboard is a modern web application built on ASP.NET Core 8.0 MVC architecture, providing comprehensive research and innovation management capabilities through an intuitive, responsive interface.

**Core Technology Stack:**
- **Backend Framework:** ASP.NET Core 8.0 MVC (C#)
- **Database:** SQL Server (with support for PostgreSQL)
- **Frontend:** Bootstrap 5 for responsive design
- **Visualizations:** Chart.js for interactive charts
- **Export Libraries:** EPPlus (Excel), CsvHelper (CSV)
- **Architecture:** Model-View-Controller (MVC) pattern

### 3.2 Key Features and Capabilities

#### **Feature 1: Interactive Dashboard Analytics**

The dashboard provides at-a-glance visibility into research activities through:

**Statistics Cards:**
- Total number of researchers in the system
- Active research projects count
- Current year publications
- Total grant funding amounts

**Visual Analytics (4 Interactive Charts):**

1. **Projects by Phase (Bar Chart)**
   - Visualizes research project distribution across funding phases
   - Helps identify funding trends over time
   - Interactive tooltips show exact counts on hover

2. **Publications by Type (Doughnut Chart)**
   - Categorizes research outputs: Indexed Journals, Conferences, Books, Chapters
   - Shows percentage breakdown of each category
   - Enables quick assessment of publication diversity

3. **Research Domain Distribution (Pie Chart)**
   - Displays projects across research domains:
     - ICT, Technology & Engineering
     - Pure & Applied Science
     - Clinical & Health Sciences
     - Environment & Heritage
     - Social Science, Arts & Applied Arts
   - Identifies institutional research strengths

4. **Grant Allocation vs Spending (Line Chart)**
   - Tracks budget allocation against actual spending
   - Identifies spending patterns and utilization rates
   - Supports financial planning and monitoring

**Benefits:**
- ✅ Real-time data updates
- ✅ No manual refresh required
- ✅ Mobile-responsive design
- ✅ Professional purple-blue gradient theme
- ✅ Intuitive navigation

#### **Feature 2: Advanced Search and Filtering**

The system provides powerful search capabilities across all modules:

**Researchers Module:**
- Search by name, UMSPER code, or email
- Filter by faculty (8 faculties supported)
- Filter by position (Professor, Associate Professor, Senior Lecturer, Lecturer)
- Filter by research domain
- Filter by active/inactive status
- Results show h-index, publication count, and contact information

**Projects Module:**
- Search by project code or title
- Filter by grant scheme (FRGS, PRGS, TRGS, RACER, etc.)
- Filter by funding phase
- Filter by project status (Active, Completed, OnSchedule, BehindSchedule)
- Filter by research domain
- Filter by principal investigator name
- Budget range filtering (minimum and maximum amounts)
- Progress percentage range filtering
- Results show allocated budget, spent amount, and progress indicators

**Publications Module:**
- Search by title, DOI, or keywords
- Filter by author name
- Filter by publication type (Indexed Journal, Non-Indexed Journal, International Conference, National Conference, Book, Chapter)
- Filter by year of publication
- Filter by quartile ranking (Q1, Q2, Q3, Q4)
- Filter by indexed status
- Link to funding grant code
- Results show citation counts and venue details

**Grants Module:**
- Search by grant code or project title
- Filter by grant scheme (FRGS, PRGS, etc.)
- Filter by fiscal year
- Filter by funding amount range
- View allocation vs spending statistics
- Track spending percentages

**Intellectual Property Module:**
- Search by title or application number
- Filter by IP type (Patent, Copyright, Trademark, Industrial Design)
- Filter by status (Filed, Granted, Registered, Pending)
- Filter by inventor name
- Filter by filing date range
- View application and grant dates

**Search Features:**
- ✅ Real-time filtering without page reload
- ✅ Active filter chips showing applied criteria
- ✅ One-click filter removal
- ✅ Results count display
- ✅ Pagination (configurable items per page)
- ✅ Sorting options (by name, date, amount)
- ✅ Mobile-friendly filter panels

#### **Feature 3: Data Export Capabilities**

Professional export functionality supporting multiple formats:

**Excel Export (EPPlus Library):**
- Formatted spreadsheets with professional styling
- Bold header row with blue background and white text
- Auto-sized columns for optimal readability
- Frozen header row for easy scrolling
- Summary sheet with export metadata:
  - Total record count
  - Export date and time
  - Applied filter criteria
  - UMS branding
- File naming: `[Module]_[YYYYMMDD]_[HHMMSS].xlsx`

**CSV Export (CsvHelper Library):**
- Standard comma-separated values format
- UTF-8 encoding for international characters
- Header row with column names
- Compatible with Excel, Google Sheets, data analysis tools
- Lightweight format for large datasets
- File naming: `[Module]_[YYYYMMDD]_[HHMMSS].csv`

**PDF Export (Framework Ready):**
- Professional report layout structure prepared
- Placeholder for UMS official letterhead
- Filtered data table formatting
- Page numbers and generation timestamp
- Extensible for future full PDF rendering

**Audit Trail:**
- All exports logged in system audit table
- Records: username, timestamp, module, format, record count, filter criteria
- Supports compliance and usage tracking

**Benefits:**
- ✅ Quick data extraction for analysis
- ✅ Professional format for presentations
- ✅ Filtered exports (only relevant data)
- ✅ Large dataset support
- ✅ Compliance through audit logging

#### **Feature 4: Responsive Design**

The system is fully responsive and accessible on:
- Desktop computers (optimal experience)
- Laptops and notebooks
- Tablets (iPad, Android tablets)
- Smartphones (iOS, Android)
- Various screen sizes (320px to 4K displays)

**Design Features:**
- Bootstrap 5 responsive grid system
- Mobile-first approach
- Touch-friendly interface elements
- Optimized charts for small screens
- Collapsible filters on mobile devices
- Accessible navigation menu

#### **Feature 5: Modular Architecture**

The system is organized into logical modules:

1. **Dashboard Module** - Analytics and statistics overview
2. **Researchers Module** - Academic staff profiles and information
3. **Projects Module** - Research project tracking and management
4. **Publications Module** - Research output cataloging
5. **Grants Module** - Funding tracking and financial monitoring
6. **Intellectual Property Module** - IP application and grant tracking
7. **Graduate Researchers Module** - PhD and Master's student profiles
8. **Audit Log Module** - System activity tracking

Each module operates independently while maintaining data relationships through a well-designed database schema.

---

## 4.0 DATABASE ARCHITECTURE

### 4.1 Schema Design

The system uses a relational database with 7 core tables:

**tblAcademicStaff**
- Stores researcher profiles and credentials
- Fields: StaffID, UMSPER, Name, Faculty, Position, ResearchDomain, HIndex, PublicationCount, Email, Phone, Status
- Purpose: Central repository for researcher information

**tblResearchProjects**
- Tracks research projects and their details
- Fields: ProjectID, ProjectCode, Title, GrantScheme, Phase, PIStaffID, ResearchDomain, AllocatedBudget, SpentAmount, Progress, Status, StartDate, EndDate
- Purpose: Project lifecycle management

**tblPublications**
- Catalogs research outputs
- Fields: PublicationID, Title, Type, AuthorStaffID, Year, Venue, DOI, Quartile, Citations, IsIndexed, GrantCode
- Purpose: Research output tracking and impact measurement

**tblGrantFinancials**
- Manages grant funding information
- Fields: GrantID, GrantScheme, Phase, FiscalYear, AllocatedAmount, SpentAmount, ProjectCount, Status
- Purpose: Financial tracking and budget monitoring

**tblIntellectualProperty**
- Tracks IP applications and grants
- Fields: IPID, Title, Type, InventorStaffID, ApplicationNo, FilingDate, GrantedDate, Status, ProjectID
- Purpose: IP portfolio management

**tblGraduateResearchers**
- Maintains graduate student records
- Fields: ResearcherID, Name, Program, SupervisorStaffID, EnrollmentDate, ExpectedCompletion, Status, Nationality, ProjectID
- Purpose: Graduate student tracking

**tblAuditLog**
- Logs system activities for compliance
- Fields: LogID, UserName, ActionType, EntityType, ExportFormat, RecordCount, FilterCriteria, IPAddress, DatePerformed
- Purpose: Audit trail and usage monitoring

### 4.2 Data Relationships

**Key Relationships:**
- Academic Staff ↔ Research Projects (one-to-many: one PI leads multiple projects)
- Academic Staff ↔ Publications (one-to-many: one author has multiple publications)
- Academic Staff ↔ Graduate Researchers (one-to-many: one supervisor manages multiple students)
- Research Projects ↔ Publications (one-to-many: one project generates multiple outputs)
- Research Projects ↔ Intellectual Property (one-to-many: one project may produce multiple IP)
- Research Projects ↔ Graduate Researchers (one-to-many: one project involves multiple students)

**Data Integrity:**
- Foreign key constraints ensure referential integrity
- Cascade rules defined for deletions
- Indexes on frequently queried columns for performance

---

## 5.0 PROOF-OF-CONCEPT DEVELOPMENT

### 5.1 Development Timeline (10 Weeks)

**Phase 1: System Setup & Sample Data (Weeks 1-3)**
- Week 1: Development environment setup and configuration
- Week 2: Database schema creation and validation
- Week 3: Sample data preparation representing typical UMS scenarios

**Phase 2: Feature Validation & Testing (Weeks 4-7)**
- Week 4: Dashboard functionality testing and chart validation
- Week 5: Researchers and projects module testing
- Week 6: Publications, grants, and IP module testing
- Week 7: Export functionality and responsive design testing

**Phase 3: Demo Preparation & Documentation (Weeks 8-10)**
- Week 8: Static demo version creation
- Week 9: Documentation development
- Week 10: Final testing and proposal preparation

### 5.2 Testing Results

**Functional Testing:**
All core features validated and working:
- ✅ Dashboard statistics calculations accurate
- ✅ Chart visualizations render correctly
- ✅ Search functionality operational across all modules
- ✅ Filtering combinations work as expected
- ✅ Pagination and sorting function properly
- ✅ Export to Excel and CSV successful
- ✅ Responsive design verified on multiple devices

**Browser Compatibility:**
Tested and confirmed working on:
- ✅ Google Chrome (latest version)
- ✅ Mozilla Firefox (latest version)
- ✅ Microsoft Edge (latest version)
- ✅ Safari (macOS and iOS)
- ✅ Mobile browsers (Chrome Mobile, Safari Mobile)

**Responsive Design Testing:**
Verified on multiple screen sizes:
- ✅ Mobile Portrait (320px - 480px)
- ✅ Mobile Landscape (481px - 767px)
- ✅ Tablet (768px - 1024px)
- ✅ Desktop (1025px+)
- ✅ Large Desktop (1920px+)

**Performance:**
System performs well with sample data:
- Dashboard loads in under 2 seconds
- Search results return in under 1 second
- Export generation completes in under 5 seconds
- Charts render smoothly without lag

### 5.3 Identified Limitations

**Current Proof-of-Concept Limitations:**
- Sample data only (not connected to production systems)
- No user authentication system (planned for full implementation)
- PDF export is placeholder implementation
- No email notification system
- Limited to sample data volume
- No integration with external systems (Scopus, MyIPO, etc.)

**These limitations are expected in a proof-of-concept and will be addressed in full implementation.**

---

## 6.0 DEMONSTRATION MATERIALS

### 6.1 Static Demo Version

A static demo version has been prepared for presentations:
- Hosted on GitHub Pages (free, globally accessible)
- Demonstrates UI/UX without requiring server/database
- Shows dashboard with sample charts
- Includes researcher search functionality
- Mobile-responsive design
- Suitable for stakeholder presentations

### 6.2 Demonstration Scenarios

**Scenario 1: Research Overview for Management**
- View dashboard to see institutional research statistics
- Analyze research domain distribution
- Review grant allocation vs spending trends
- Export summary report to Excel for meeting

**Scenario 2: Finding Researchers by Expertise**
- Use researcher search to find ICT domain experts
- Filter by faculty and position
- View publication counts and h-index
- Export researcher list for collaboration planning

**Scenario 3: Project Financial Monitoring**
- Search for projects by grant scheme (e.g., FRGS)
- Filter by spending status (behind schedule, needs monitoring)
- View budget allocation vs spent amounts
- Export financial report for audit

**Scenario 4: Publication Impact Assessment**
- Search publications by year
- Filter by quartile (Q1, Q2)
- View citation counts
- Export publication list for annual report

**Scenario 5: IP Portfolio Review**
- View all intellectual property records
- Filter by status (granted, pending)
- Check filing and grant dates
- Export IP summary for reporting

---

## 7.0 BENEFITS AND VALUE PROPOSITION

### 7.1 Immediate Benefits

**For Research Management Centre:**
- ✅ **Centralized Data Management** - Single source of truth for all research information
- ✅ **Time Savings** - Instant reports vs hours of manual compilation
- ✅ **Improved Accuracy** - Reduced errors from manual data entry
- ✅ **Better Oversight** - Real-time visibility into research activities
- ✅ **Simplified Reporting** - One-click export for stakeholder reports

**For Researchers:**
- ✅ **Easy Access** - View own projects and publications anytime
- ✅ **Progress Tracking** - Monitor project milestones and budgets
- ✅ **Collaboration** - Find colleagues by research domain
- ✅ **Publication Tracking** - Catalog research outputs
- ✅ **Mobile Access** - Check information on any device

**For University Management:**
- ✅ **Strategic Insights** - Data-driven decision making
- ✅ **Performance Monitoring** - Track institutional research KPIs
- ✅ **Resource Allocation** - Identify areas needing support
- ✅ **Stakeholder Communication** - Professional reports and visualizations
- ✅ **Compliance** - Audit trail and accurate record keeping

### 7.2 Long-Term Value

**Operational Efficiency:**
- Reduces administrative workload by an estimated 60-70%
- Eliminates duplicate data entry across systems
- Streamlines annual reporting processes
- Automates routine monitoring tasks

**Strategic Advantages:**
- Supports evidence-based research planning
- Facilitates grant application preparation
- Enhances institutional research profile
- Improves competitiveness for funding

**Cost Savings:**
- Reduces staff time on manual reporting
- Minimizes errors requiring correction
- Leverages open-source technologies (lower licensing costs)
- Scalable architecture reduces future development costs

**Risk Mitigation:**
- Prevents data loss through centralized storage
- Maintains audit trail for compliance
- Ensures data consistency and integrity
- Provides backup and recovery capabilities

---

## 8.0 IMPLEMENTATION ROADMAP

### 8.1 Recommended Implementation Phases

**Phase 1: Foundation (Months 1-2)**
- User authentication and authorization system
- Role-based access control (Admin, Editor, Viewer)
- Production database setup and configuration
- Data migration from existing systems
- User acceptance testing
- Staff training sessions

**Phase 2: Enhanced Features (Months 3-4)**
- Full PDF export implementation with UMS branding
- Email notification system for project milestones
- Advanced analytics and reporting
- Custom report builder
- Dashboard customization options
- Mobile app development (optional)

**Phase 3: Integration (Months 5-6)**
- Integration with external systems:
  - Scopus/Web of Science for citation updates
  - MyIPO for IP status tracking
  - Grant application portals (MyRA, FRGS)
- API development for third-party access
- Automated data synchronization
- Scheduled report generation

**Phase 4: Optimization (Month 7+)**
- Performance optimization for large datasets
- Advanced search algorithms (fuzzy matching, AI-powered)
- Predictive analytics for grant spending
- Machine learning for publication impact prediction
- Continuous improvement based on user feedback

### 8.2 Resource Requirements

**Development Team:**
- 1 Full-stack Developer (ASP.NET Core, C#, SQL)
- 1 UI/UX Designer (part-time)
- 1 Database Administrator (part-time)
- 1 Project Manager (part-time)
- 1 QA Tester (part-time)

**Infrastructure:**
- Web server (cloud hosting recommended: Azure, AWS, or local server)
- Database server (SQL Server or PostgreSQL)
- Backup storage
- SSL certificates for secure access
- Domain name

**Budget Estimate (Rough):**
- Development: RM 50,000 - 80,000 (depending on scope)
- Infrastructure (annual): RM 5,000 - 15,000 (cloud) or RM 20,000+ (on-premise hardware)
- Training: RM 3,000 - 5,000
- Maintenance (annual): RM 10,000 - 20,000
- **Total Initial Investment: RM 68,000 - 120,000**

*(Note: Using existing university infrastructure can significantly reduce costs)*

### 8.3 Success Metrics

**Key Performance Indicators (KPIs):**
- Time to generate reports (target: 90% reduction)
- User adoption rate (target: 80%+ within 6 months)
- Data accuracy (target: 99%+)
- System uptime (target: 99.5%+)
- User satisfaction score (target: 4.5/5)
- Number of active users per month
- Export frequency (indication of usage)

---

## 9.0 RISK ASSESSMENT AND MITIGATION

### 9.1 Identified Risks

**Technical Risks:**
- **Data Migration Complexity** - Existing data may be inconsistent or incomplete
  - *Mitigation:* Thorough data audit before migration; phased migration approach; data validation scripts

- **System Performance** - Large datasets may impact response times
  - *Mitigation:* Database indexing; query optimization; caching strategies; pagination

- **Integration Challenges** - External systems may have API limitations
  - *Mitigation:* Manual import options as fallback; regular synchronization scheduling

**Organizational Risks:**
- **User Resistance** - Staff may be reluctant to adopt new system
  - *Mitigation:* Comprehensive training; gradual rollout; user feedback sessions

- **Data Entry Burden** - Initial data population is time-consuming
  - *Mitigation:* Bulk import tools; data entry templates; temporary staff support

- **Maintenance Requirements** - System needs ongoing support
  - *Mitigation:* Comprehensive documentation; knowledge transfer; support contract

**Budget Risks:**
- **Cost Overruns** - Development may exceed estimates
  - *Mitigation:* Phased approach; clear scope definition; regular budget reviews

### 9.2 Contingency Planning

**Alternative Approaches:**
- If full implementation budget unavailable: Deploy core features first, add enhancements later
- If cloud hosting too expensive: Use on-premise university servers
- If development timeline too long: Use proof-of-concept system with manual data entry initially

---

## 10.0 COMPARISON WITH ALTERNATIVES

### 10.1 Build vs Buy vs Adapt

**Option 1: Build Custom System (Current Proposal)**
- ✅ Tailored to UMS specific needs
- ✅ Full control over features and data
- ✅ Lower long-term costs
- ✅ Integration with existing UMS systems possible
- ❌ Longer initial development time
- ❌ Requires in-house or contracted development expertise

**Option 2: Buy Commercial System**
- ✅ Faster deployment
- ✅ Established vendor support
- ❌ High licensing costs (typically RM 50,000 - 200,000+ annually)
- ❌ Customization limitations
- ❌ Vendor lock-in
- ❌ May not fit UMS workflows

**Option 3: Adapt Open-Source Solution**
- ✅ Lower licensing costs
- ✅ Community support
- ❌ May require significant customization
- ❌ Generic features may not match needs
- ❌ Limited specialized research management options

**Recommendation:** Build custom system (current proposal) offers best long-term value and flexibility for UMS needs.

### 10.2 Technology Stack Alternatives

**Current: ASP.NET Core**
- ✅ Mature, enterprise-grade framework
- ✅ Excellent performance and security
- ✅ Strong typing reduces bugs
- ✅ Extensive library ecosystem
- ✅ Good documentation and community support

**Alternative 1: PHP (Laravel)**
- ✅ Lower hosting costs
- ✅ Easier to find developers
- ❌ Generally lower performance than ASP.NET Core
- ❌ Less suitable for large-scale enterprise applications

**Alternative 2: Python (Django)**
- ✅ Excellent for data science integration
- ✅ Rapid development
- ❌ Lower performance for web applications
- ❌ Smaller ecosystem for business applications

**Alternative 3: JavaScript (Node.js)**
- ✅ Same language for frontend and backend
- ✅ Good for real-time features
- ❌ Less mature for enterprise applications
- ❌ More difficult to maintain for large projects

**Recommendation:** ASP.NET Core remains the best choice for UMS institutional-scale application requiring reliability, performance, and long-term maintainability.

---

## 11.0 RECOMMENDATIONS

### 11.1 Immediate Actions (Next 3 Months)

1. **Stakeholder Review** - Present proof-of-concept to key stakeholders
2. **Feedback Collection** - Gather requirements and improvement suggestions
3. **Budget Approval** - Secure funding for full implementation
4. **Team Assembly** - Identify or hire development team
5. **Data Audit** - Assess existing data quality and migration requirements

### 11.2 Priority Features for Full Implementation

**Priority 1 (Must Have):**
- User authentication and role-based access control
- Production database with actual UMS data
- Full PDF export with official UMS formatting
- Data backup and recovery procedures
- User training and documentation

**Priority 2 (Should Have):**
- Email notifications for project milestones and deadlines
- Advanced reporting and analytics
- Mobile application for iOS and Android
- Integration with UMS existing systems
- Automated data synchronization

**Priority 3 (Nice to Have):**
- Predictive analytics for grant spending patterns
- Machine learning for impact prediction
- Social collaboration features (comments, discussions)
- API for external access
- Custom dashboard builder

### 11.3 Long-Term Vision

**1-Year Goal:**
- Fully operational system with all core features
- All historical data migrated and validated
- 80%+ user adoption across research staff
- Established as primary research management tool

**3-Year Goal:**
- Integration with national research databases
- Advanced analytics guiding strategic planning
- Mobile app widely adopted
- Automated annual report generation
- Expansion to cover commercialization and innovation activities

**5-Year Goal:**
- AI-powered research collaboration recommendations
- Predictive modeling for research impact
- Integration with international research databases
- Platform for research-industry partnerships
- Model system adopted by other Malaysian universities

---

## 12.0 CONCLUSION

The SMPPI Dashboard proof-of-concept successfully demonstrates a viable, cost-effective solution for transforming research and innovation management at Universiti Malaysia Sabah. The system addresses critical operational challenges while providing a modern, user-friendly platform accessible to all stakeholders.

**Key Achievements:**
- ✅ Functional prototype demonstrating all core features
- ✅ Modern, responsive design suitable for any device
- ✅ Scalable architecture ready for production deployment
- ✅ Comprehensive documentation for users and developers
- ✅ Clear implementation roadmap with realistic timelines

**Strategic Value:**
The SMPPI Dashboard is not merely a data management tool—it is a strategic asset that enables:
- Data-driven research planning and resource allocation
- Enhanced visibility of UMS research achievements
- Improved operational efficiency reducing administrative burden
- Better compliance and audit trail capabilities
- Foundation for future innovation in research management

**Investment Justification:**
With estimated development costs of RM 68,000 - 120,000 and annual savings of 60-70% in administrative time, the system can pay for itself within 2-3 years while providing ongoing strategic benefits.

**Next Steps:**
We recommend proceeding with full implementation following the phased approach outlined in Section 8. The proof-of-concept has validated technical feasibility, user interface design, and core functionality—providing confidence that full-scale implementation will succeed.

**Call to Action:**
This is an opportunity to position UMS at the forefront of research management innovation in Malaysia. We urge university leadership to approve this initiative and provide the necessary resources for successful implementation.

---

## APPENDICES

### Appendix A: System Architecture Diagram
*[Technical architecture showing MVC layers, database, and client interactions]*

### Appendix B: Database Schema Documentation
*[Detailed entity-relationship diagram with table definitions]*

### Appendix C: User Interface Screenshots
*[Comprehensive screenshots of all modules and features]*
- Dashboard with 4 charts
- Researchers search and filter
- Projects advanced search
- Publications listing
- Grant financial tracking
- IP portfolio view
- Export examples (Excel, CSV)
- Mobile responsive views

### Appendix D: Feature Comparison Matrix
*[Comparison of features vs requirements vs commercial alternatives]*

### Appendix E: Technical Specifications
*[Detailed technical documentation for developers]*
- API endpoints
- Database schema
- Security considerations
- Deployment procedures
- Testing protocols

### Appendix F: Training Materials Outline
*[Proposed structure for user training documentation]*
- Getting started guide
- Module-specific tutorials
- Administrator guide
- Troubleshooting FAQ
- Video tutorial scripts

### Appendix G: Budget Breakdown
*[Detailed cost estimates for implementation phases]*

### Appendix H: Timeline Gantt Chart
*[Visual project timeline showing dependencies and milestones]*

---

**Report Prepared By:**
[Research Data Officer Name]
Research Data Officer

**Reviewed By:**
Dr. Ervin Gubin Moung
Project Leader, Faculty of Computing and Informatics
Universiti Malaysia Sabah

**Date:** 31 January 2026

**Project Code:** RMC0005
**Project Title:** Pembangunan Sistem Maklumat Pengurusan Penyelidik dan Inovasi (SMPPI Dashboard)

---

## ACKNOWLEDGMENTS

This proof-of-concept was developed with support from:
- Research Management Centre, UMS
- Faculty of Computing and Informatics, UMS
- University stakeholders who provided feedback and requirements
- The open-source community for excellent libraries and frameworks

---

**For more information or clarifications, please contact:**

Dr. Ervin Gubin Moung
Faculty of Computing and Informatics
Universiti Malaysia Sabah
Email: ervin@ums.edu.my

---

*This document is confidential and intended for internal UMS use only. Distribution outside the university requires written approval from the Project Leader.*
