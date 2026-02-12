# SMPPI Dashboard - Research and Innovation Management System

A comprehensive ASP.NET Core MVC dashboard application for managing research information, projects, publications, grants, and intellectual property at Universiti Malaysia Sabah (UMS).

## 📋 Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Technology Stack](#technology-stack)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Database Setup](#database-setup)
- [Configuration](#configuration)
- [Running the Application](#running-the-application)
- [Usage Guide](#usage-guide)
- [Project Structure](#project-structure)
- [API Endpoints](#api-endpoints)
- [Export Functionality](#export-functionality)
- [Troubleshooting](#troubleshooting)
- [Contributing](#contributing)
- [License](#license)

## 🌟 Overview

SMPPI (Sistem Maklumat Pengurusan Penyelidik dan Inovasi) is a modern web-based dashboard designed to streamline research and innovation management. The system provides easy search, visualization, and data extraction capabilities for administrators who need to respond to data requests efficiently.

### Key Capabilities

- **Dashboard Analytics**: Real-time statistics and visualizations of research activities
- **Advanced Search**: Powerful filtering and search across all data entities
- **Data Export**: Export to Excel, PDF, and CSV formats
- **Grant Management**: Track FRGS and other grant schemes (2020-2024)
- **Publication Tracking**: Monitor indexed journals, conferences, and citations
- **IP Management**: Track patents, copyrights, and other intellectual property
- **Researcher Profiles**: Comprehensive academic staff information

## ✨ Features

### 1. Interactive Dashboard
- Statistical cards showing key metrics
- Chart.js visualizations:
  - Projects by Phase (Bar Chart)
  - Publications by Type (Doughnut Chart)
  - Research Domain Distribution (Pie Chart)
  - Grant Spending vs Allocation (Line Chart)
- Recent activity feed

### 2. Advanced Search & Filtering
Each module supports:
- Multiple filter criteria with AND logic
- Real-time search
- Active filter display as removable chips
- Pagination (20 items per page)
- Custom sorting options

### 3. Data Export
- **Excel**: Formatted spreadsheets with summary sheets
- **PDF**: Professional reports with UMS header
- **CSV**: Standard CSV format with UTF-8 encoding
- Audit logging of all exports

### 4. Responsive Design
- Bootstrap 5 responsive grid
- Mobile-friendly tables
- Touch-friendly controls
- Print-friendly layouts

## 🛠 Technology Stack

### Backend
- **Framework**: ASP.NET Core 8.0 (MVC)
- **Language**: C# 12
- **Database**: SQL Server (SSMS)
- **ORM**: Entity Framework Core 8.0

### Frontend
- **UI Framework**: Bootstrap 5.3
- **Icons**: Bootstrap Icons
- **Charts**: Chart.js 4.4
- **JavaScript**: jQuery 3.7

### Libraries & Packages
- **EPPlus 7.0**: Excel generation
- **DinkToPdf 1.0**: PDF generation
- **CsvHelper 30.0**: CSV export
- **Newtonsoft.Json 13.0**: JSON processing

## 📋 Prerequisites

Before installing, ensure you have:

1. **.NET 8.0 SDK** or later
   - Download: https://dotnet.microsoft.com/download
   - Verify: `dotnet --version`

2. **SQL Server 2019** or later (Express, Developer, or Standard)
   - Download: https://www.microsoft.com/sql-server/sql-server-downloads
   - Alternatives: SQL Server LocalDB, Azure SQL Database

3. **Visual Studio 2022** (recommended) or Visual Studio Code
   - VS 2022: https://visualstudio.microsoft.com/
   - VS Code: https://code.visualstudio.com/

4. **SQL Server Management Studio (SSMS)** (recommended)
   - Download: https://docs.microsoft.com/sql/ssms/download-sql-server-management-studio-ssms

## 🚀 Installation

### Step 1: Clone or Download the Repository

```bash
git clone <repository-url>
cd SMPPI_DASBOARD_GDE
```

### Step 2: Restore NuGet Packages

```bash
cd SMPPI.Dashboard
dotnet restore
```

### Step 3: Configure Connection String

Edit `appsettings.json` to match your SQL Server configuration:

```json
{
  "ConnectionStrings": {
    "SMPPIDatabase": "Server=YOUR_SERVER_NAME;Database=SMPPI_DB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
  }
}
```

**Common Server Names:**
- Local SQL Server: `localhost` or `(localdb)\\mssqllocaldb`
- SQL Server Instance: `localhost\\SQLEXPRESS`
- Remote Server: `192.168.1.100` or `server.domain.com`

## 💾 Database Setup

### Option 1: Automatic Setup (Using SQL Scripts)

1. **Open SQL Server Management Studio (SSMS)**

2. **Connect to your SQL Server instance**

3. **Run the schema creation script:**
   - File → Open → File → Navigate to `SMPPI.Dashboard/SQL/01_CreateSchema.sql`
   - Click Execute (F5)
   - Verify: "Database schema created successfully!" message

4. **Run the data seeding script:**
   - File → Open → File → Navigate to `SMPPI.Dashboard/SQL/02_SeedData.sql`
   - Click Execute (F5)
   - Verify: Statistics showing inserted records

### Option 2: Using Entity Framework Migrations (Advanced)

```bash
# Create migration
dotnet ef migrations add InitialCreate --project SMPPI.Dashboard

# Apply migration
dotnet ef database update --project SMPPI.Dashboard
```

### Verify Database Setup

Run this query in SSMS to verify:

```sql
USE SMPPI_DB;
GO

SELECT
    'AcademicStaff' AS TableName, COUNT(*) AS RecordCount FROM tblAcademicStaff
UNION ALL
SELECT 'ResearchProjects', COUNT(*) FROM tblResearchProjects
UNION ALL
SELECT 'Publications', COUNT(*) FROM tblPublications
UNION ALL
SELECT 'GrantFinancials', COUNT(*) FROM tblGrantFinancials
UNION ALL
SELECT 'IntellectualProperty', COUNT(*) FROM tblIntellectualProperty
UNION ALL
SELECT 'GraduateResearchers', COUNT(*) FROM tblGraduateResearchers;
```

Expected results:
- AcademicStaff: 15 records
- ResearchProjects: 20 records
- Publications: 17 records
- GrantFinancials: 5 records
- IntellectualProperty: 5 records
- GraduateResearchers: 8 records

## ⚙ Configuration

### Application Settings

Edit `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "SMPPIDatabase": "Server=localhost;Database=SMPPI_DB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
  },
  "DashboardSettings": {
    "ItemsPerPage": 20,              // Records per page
    "CacheDurationMinutes": 15,       // Dashboard cache duration
    "MaxExportRecords": 10000,        // Maximum records for export
    "EnableAuditLog": true,           // Enable export audit logging
    "DateTimeZone": "Singapore Standard Time",  // UTC+8
    "CurrencySymbol": "RM",           // Malaysian Ringgit
    "DecimalPlaces": 2
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning",
      "Microsoft.EntityFrameworkCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### EPPlus License

EPPlus requires license configuration. In `Program.cs`, the license is set to NonCommercial:

```csharp
OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
```

For commercial use, obtain a license from: https://epplussoftware.com/

## ▶ Running the Application

### Using Visual Studio

1. Open `SMPPI.Dashboard.sln` in Visual Studio 2022
2. Set `SMPPI.Dashboard` as the startup project
3. Press **F5** to run (or Ctrl+F5 to run without debugging)
4. Browser will open at: `https://localhost:5001` or `http://localhost:5000`

### Using Command Line

```bash
cd SMPPI.Dashboard
dotnet run
```

Access the application:
- HTTPS: https://localhost:5001
- HTTP: http://localhost:5000

### Using Visual Studio Code

```bash
cd SMPPI.Dashboard
dotnet watch run
```

The application will hot-reload on file changes.

## 🚂 Railway.app Deployment (Cloud Hosting)

**Quick Deploy to Railway.app** (5 minutes setup):

### Why Railway?
- ✅ Free $5/month credit
- ✅ Auto-deploy from GitHub
- ✅ PostgreSQL database included
- ✅ Automatic HTTPS
- ✅ Perfect for demos and production

### Quick Steps:

1. **Push to GitHub** (if not already done)
   ```bash
   git push origin claude/aspnet-dashboard-visualization-Vah2Q
   ```

2. **Deploy on Railway**:
   - Go to https://railway.app
   - Sign up with GitHub
   - Click "New Project" → "Deploy from GitHub repo"
   - Select `SMPPI_DASBOARD_GDE` repository
   - Railway auto-detects Dockerfile and deploys

3. **Add PostgreSQL Database**:
   - In Railway project: "New" → "Database" → "PostgreSQL"
   - Database URL auto-configured

4. **Set Environment Variables**:
   ```
   DatabaseProvider=PostgreSQL
   ASPNETCORE_ENVIRONMENT=Production
   ```

5. **Initialize Database**:
   ```bash
   # Install Railway CLI
   npm i -g @railway/cli
   railway login
   railway link

   # Run PostgreSQL migrations
   psql $DATABASE_URL -f SMPPI.Dashboard/SQL/PostgreSQL_01_CreateSchema.sql
   psql $DATABASE_URL -f SMPPI.Dashboard/SQL/PostgreSQL_02_SeedData.sql
   ```

6. **Generate Domain**:
   - Settings → "Generate Domain"
   - Access at: `https://your-app.railway.app`

**📖 Full Railway Guide**: See [RAILWAY_DEPLOYMENT.md](RAILWAY_DEPLOYMENT.md) for detailed instructions.

**🔄 Auto-Deploy**: Every push to your branch automatically deploys to Railway!

## 📖 Usage Guide

### Dashboard Overview

**URL**: `/Dashboard/Index`

The dashboard provides:
- Total Researchers, Active Projects, Publications, and Grant Amount
- Visual charts showing trends and distributions
- Recent activity feed

**Features**:
- Auto-refreshed statistics (15-minute cache)
- Interactive Chart.js visualizations
- Click on recent activities for details

### Researchers Module

**URL**: `/Researchers/Index`

**Search Fields**:
- Name/UMSPER/Email (text search)
- Faculty (dropdown)
- Position (dropdown)
- Research Domain (dropdown)
- Active/Inactive status

**Actions**:
- View researcher details
- Export to Excel/PDF/CSV

### Projects Module

**URL**: `/Projects/Index`

**Search Fields**:
- Project Code/Title
- Grant Scheme (FRGS, PRGS, TRGS, etc.)
- Phase/Year (2020-2024)
- Project Status (Active, Completed, etc.)
- Budget range
- Progress percentage range

**Actions**:
- View project details with linked publications and IP
- Export filtered results

### Publications Module

**URL**: `/Publications/Index`

**Search Fields**:
- Title/DOI/Keywords
- Author name
- Publication Type (Journal, Conference, etc.)
- Year
- Quartile (Q1, Q2, Q3, Q4)
- Indexed status

**Actions**:
- View publication details
- Export citation lists

### Grants Module

**URL**: `/Grants/Index`

**Features**:
- Grant financial overview
- Allocated vs Spent amount tracking
- Fiscal year filtering
- Summary statistics

### Intellectual Property Module

**URL**: `/IntellectualProperty/Index`

**Track**:
- Patents
- Copyrights
- Trademarks
- Industrial Designs

**Search by**: Type, Status, Inventor, Filing Date

### Export Functionality

**Supported Formats**:
1. **Excel (.xlsx)**
   - Formatted headers
   - Auto-sized columns
   - Summary sheet included
   - Frozen header row

2. **PDF (.pdf)**
   - Professional report format
   - UMS header/logo
   - Page numbers
   - Timestamp

3. **CSV (.csv)**
   - UTF-8 encoding
   - Standard comma-separated format
   - Header row included

**How to Export**:
1. Navigate to any module
2. Apply desired filters
3. Click Export button (Excel/PDF/CSV)
4. File downloads automatically
5. Export logged in audit table

**Audit Log**: All exports are tracked in `tblAuditLog` with user, date, format, and filter criteria.

## 📁 Project Structure

```
SMPPI.Dashboard/
├── Controllers/              # MVC Controllers
│   ├── DashboardController.cs
│   ├── ResearchersController.cs
│   ├── ProjectsController.cs
│   ├── PublicationsController.cs
│   ├── GrantsController.cs
│   ├── IntellectualPropertyController.cs
│   └── ReportsController.cs
├── Models/                   # Entity Models
│   ├── AcademicStaff.cs
│   ├── ResearchProject.cs
│   ├── Publication.cs
│   ├── GrantFinancial.cs
│   ├── IntellectualProperty.cs
│   ├── GraduateResearcher.cs
│   └── AuditLog.cs
├── ViewModels/               # View Models
│   ├── DashboardViewModel.cs
│   ├── ResearcherSearchViewModel.cs
│   ├── ProjectSearchViewModel.cs
│   ├── PublicationSearchViewModel.cs
│   ├── GrantSearchViewModel.cs
│   └── IPSearchViewModel.cs
├── Services/                 # Business Logic Layer
│   ├── IDashboardService.cs / DashboardService.cs
│   ├── IExportService.cs / ExportService.cs
│   ├── IResearcherService.cs / ResearcherService.cs
│   └── ... (other services)
├── Data/                     # Database Context
│   └── SMPPIDbContext.cs
├── Views/                    # Razor Views
│   ├── Dashboard/
│   ├── Researchers/
│   ├── Projects/
│   ├── Publications/
│   ├── Grants/
│   ├── IntellectualProperty/
│   └── Shared/
│       └── _Layout.cshtml
├── wwwroot/                  # Static Files
│   ├── css/
│   │   └── site.css
│   ├── js/
│   │   └── site.js
│   └── lib/
├── SQL/                      # Database Scripts
│   ├── 01_CreateSchema.sql
│   └── 02_SeedData.sql
├── appsettings.json          # Configuration
├── Program.cs                # Application Entry Point
└── SMPPI.Dashboard.csproj    # Project File
```

## 🔌 API Endpoints

### Dashboard
- `GET /Dashboard/Index` - Dashboard overview with statistics

### Researchers
- `GET /Researchers/Index?SearchTerm={term}&Faculty={faculty}...` - Search researchers
- `GET /Researchers/Details/{id}` - Researcher details

### Projects
- `GET /Projects/Index?GrantScheme={scheme}&Phase={phase}...` - Search projects
- `GET /Projects/Details/{id}` - Project details

### Publications
- `GET /Publications/Index?PublicationType={type}&Year={year}...` - Search publications
- `GET /Publications/Details/{id}` - Publication details

### Grants
- `GET /Grants/Index?GrantScheme={scheme}&FiscalYear={year}...` - Search grants
- `GET /Grants/Details/{id}` - Grant details

### Intellectual Property
- `GET /IntellectualProperty/Index?IPType={type}&IPStatus={status}...` - Search IP
- `GET /IntellectualProperty/Details/{id}` - IP details

### Reports (Export)
- `POST /Reports/ExportResearchers` - Export researchers
- `POST /Reports/ExportProjects` - Export projects
- `POST /Reports/ExportPublications` - Export publications
- `POST /Reports/ExportGrants` - Export grants
- `POST /Reports/ExportIP` - Export intellectual property

## 🔧 Troubleshooting

### Common Issues

#### 1. Database Connection Error

**Error**: "Cannot open database 'SMPPI_DB'"

**Solution**:
- Verify SQL Server is running
- Check connection string in `appsettings.json`
- Ensure database exists (run schema script)
- Test connection in SSMS

#### 2. Entity Framework Migration Issues

**Error**: "No DbContext was found"

**Solution**:
```bash
dotnet ef migrations add InitialCreate --project SMPPI.Dashboard --startup-project SMPPI.Dashboard
```

#### 3. EPPlus License Error

**Error**: "Please set the excelpackage.LicenseContext property"

**Solution**: Already configured in `Program.cs`. For commercial use, purchase license.

#### 4. Port Already in Use

**Error**: "Failed to bind to address https://localhost:5001"

**Solution**:
- Change port in `launchSettings.json`
- Or kill process using the port:
  ```bash
  netstat -ano | findstr :5001
  taskkill /PID <pid> /F
  ```

#### 5. Export Not Working

**Solution**:
- Check browser console for JavaScript errors
- Verify export endpoints are accessible
- Check file permissions for temp directory

### Debug Mode

Enable detailed logging in `appsettings.Development.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "Microsoft.AspNetCore": "Information",
      "Microsoft.EntityFrameworkCore": "Information"
    }
  }
}
```

## 📊 Sample Data

The seed script includes realistic data based on FRGS 2020-2024:

### Grant Statistics
- **Fasa 1/2020**: 26 projects, RM 2,600,515
- **Fasa 1/2021**: 9 projects, RM 1,118,062
- **Fasa 1/2022**: 30 projects, RM 3,941,772
- **Fasa 1/2023**: 29 projects, RM 3,486,722
- **Fasa 1/2024**: 25 projects, RM 2,913,753

### Publication Statistics
- Total: 221 publications (2020-2024)
- Indexed Journals: 122
- Non-Indexed Journals: 11
- International Conferences: 73
- National Conferences: 15

### Research Domains
- Arts and Applied Arts
- Clinical and Health Sciences
- Environment and Heritage
- ICT
- Pure and Applied Science
- Social Science
- Technology and Engineering

## 🤝 Contributing

Contributions are welcome! Please follow these guidelines:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

### Code Style
- Follow C# coding conventions
- Use meaningful variable names
- Add XML documentation for public methods
- Write unit tests for new features

## 📄 License

This project is developed for Universiti Malaysia Sabah (UMS).

Copyright © 2024 Universiti Malaysia Sabah. All rights reserved.

## 👥 Support

For support and questions:
- **Email**: support@ums.edu.my
- **Documentation**: See this README
- **Issues**: Create an issue in the repository

## 🎯 Roadmap

Planned features:
- [ ] User authentication and role-based access control
- [ ] Advanced reporting with custom report builder
- [ ] Email notifications for grant milestones
- [ ] Mobile app (React Native)
- [ ] RESTful API for third-party integrations
- [ ] Real-time collaboration features
- [ ] Advanced analytics with predictive insights

## 📝 Changelog

### Version 1.0.0 (2024)
- Initial release
- Dashboard with statistics and charts
- Advanced search and filtering
- Export to Excel, PDF, CSV
- FRGS grant tracking (2020-2024)
- Publication and IP management
- Responsive design with Bootstrap 5

---

**Built with ❤️ for Universiti Malaysia Sabah**
