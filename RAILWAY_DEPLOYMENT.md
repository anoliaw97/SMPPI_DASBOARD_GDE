# 🚂 Railway.app Deployment Guide

Complete guide to deploy SMPPI Dashboard on Railway.app with PostgreSQL database.

## 📋 Prerequisites

- GitHub account
- Railway.app account (sign up at https://railway.app)
- Git installed locally

---

## 🚀 Quick Deploy (5 Minutes)

### Step 1: Push Code to GitHub

```bash
# Ensure all changes are committed
git add .
git commit -m "Add Railway deployment configuration"
git push origin claude/aspnet-dashboard-visualization-Vah2Q
```

### Step 2: Deploy on Railway

1. **Go to Railway**: https://railway.app
2. **Sign up/Login** with your GitHub account
3. **Create New Project**:
   - Click "New Project"
   - Select "Deploy from GitHub repo"
   - Authorize Railway to access your repositories
   - Select `SMPPI_DASBOARD_GDE` repository
   - Select branch: `claude/aspnet-dashboard-visualization-Vah2Q`

4. **Railway Auto-Detection**:
   - Railway will detect the Dockerfile
   - Build will start automatically
   - Wait ~2-3 minutes for build to complete

### Step 3: Add PostgreSQL Database

1. **In your Railway project**:
   - Click "New" → "Database" → "Add PostgreSQL"
   - Railway provisions database automatically
   - Database URL is auto-configured as `DATABASE_URL`

2. **Set Environment Variables**:
   - Click on your service (SMPPI.Dashboard)
   - Go to "Variables" tab
   - Add these variables:

```
DatabaseProvider=PostgreSQL
ASPNETCORE_ENVIRONMENT=Production
```

### Step 4: Initialize Database

**Option A: Using Railway CLI** (Recommended)

```bash
# Install Railway CLI
npm i -g @railway/cli

# Login
railway login

# Link to your project
railway link

# Run database migrations
railway run dotnet ef database update --project SMPPI.Dashboard
```

**Option B: Using PostgreSQL Client**

1. Get database credentials from Railway:
   - Click PostgreSQL service
   - Go to "Connect" tab
   - Copy connection string

2. Connect using pgAdmin or psql:
```bash
psql "postgresql://user:password@host:port/database"
```

3. Create tables manually or use migration scripts

### Step 5: Generate Public URL

1. In Railway project:
   - Click your service (SMPPI.Dashboard)
   - Go to "Settings" tab
   - Click "Generate Domain"
   - Your app will be available at: `https://your-app.railway.app`

### Step 6: Test Your Deployment

Visit your Railway URL:
- Dashboard: `https://your-app.railway.app/Dashboard/Index`
- Researchers: `https://your-app.railway.app/Researchers/Index`

---

## 🗄️ Database Migration

Since we're switching from SQL Server to PostgreSQL, you have two options:

### Option A: Use PostgreSQL Migration Scripts

Create PostgreSQL-compatible schema:

```sql
-- PostgreSQL Schema (simplified example)
CREATE TABLE "tblAcademicStaff" (
    "StaffID" SERIAL PRIMARY KEY,
    "UMSPER" VARCHAR(20) UNIQUE NOT NULL,
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

-- Create indexes
CREATE INDEX idx_academicstaff_faculty ON "tblAcademicStaff"("Faculty");
CREATE INDEX idx_academicstaff_position ON "tblAcademicStaff"("Position");
-- ... add other tables and indexes
```

### Option B: Use Entity Framework Migrations

```bash
# Create migration for PostgreSQL
dotnet ef migrations add InitialCreate --project SMPPI.Dashboard

# Apply to Railway database
railway run dotnet ef database update --project SMPPI.Dashboard
```

---

## ⚙️ Environment Variables Reference

| Variable | Value | Description |
|----------|-------|-------------|
| `DATABASE_URL` | Auto-set by Railway | PostgreSQL connection string |
| `DatabaseProvider` | `PostgreSQL` | Database type |
| `ASPNETCORE_ENVIRONMENT` | `Production` | Environment |
| `ASPNETCORE_URLS` | `http://+:8080` | Auto-set |

---

## 📊 Railway Free Tier Limits

Railway provides:
- ✅ **$5 free credit/month** (renews monthly)
- ✅ **500 hours** of usage
- ✅ **100 GB** bandwidth
- ✅ **PostgreSQL database** included
- ✅ **Automatic HTTPS**
- ✅ **GitHub auto-deploy**

This is **sufficient for demo/testing** but you'll need to upgrade for production.

---

## 🔧 Troubleshooting

### Build Fails

**Error**: "No Dockerfile found"
```bash
# Ensure Dockerfile is in repository root
git add Dockerfile
git commit -m "Add Dockerfile"
git push
```

**Error**: "Build timeout"
- Railway has 10-minute build timeout
- Optimize Dockerfile by caching dependencies

### Database Connection Issues

**Error**: "Cannot connect to database"

1. Verify `DATABASE_URL` is set:
   ```bash
   railway variables
   ```

2. Check database is running:
   - Go to Railway dashboard
   - PostgreSQL service should be "Active"

3. Test connection:
   ```bash
   railway run dotnet ef database update
   ```

### Application Crashes

**Check logs**:
```bash
railway logs
```

Common issues:
- Missing environment variables
- Database not initialized
- Port configuration (must use port 8080)

### Port Issues

Railway expects app to listen on `PORT` environment variable (defaults to 8080).

Verify in Dockerfile:
```dockerfile
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
```

---

## 🔄 Continuous Deployment

Railway automatically deploys on every push to your branch:

```bash
# Make changes
git add .
git commit -m "Update feature"
git push

# Railway automatically:
# 1. Detects push
# 2. Builds new Docker image
# 3. Deploys with zero downtime
# 4. Rolls back if deployment fails
```

---

## 💰 Cost Estimation

### Free Tier (Hobby Plan)
- **Cost**: $5 credit/month
- **Good for**: Demo, testing, low-traffic apps
- **Limits**: ~$5 worth of usage

### Paid Plan (Developer)
- **Cost**: Pay-as-you-go (starts at ~$5/month)
- **Includes**:
  - Unlimited projects
  - Priority support
  - More resources

**Estimated monthly cost for SMPPI Dashboard**:
- App service: ~$5-10
- PostgreSQL: Included
- **Total**: ~$5-10/month

---

## 🌐 Custom Domain (Optional)

1. In Railway project settings:
   - Go to "Settings" → "Domains"
   - Click "Custom Domain"
   - Add your domain: `dashboard.ums.edu.my`

2. Add DNS records:
   ```
   Type: CNAME
   Name: dashboard
   Value: your-app.railway.app
   ```

3. Railway auto-configures SSL certificate

---

## 📈 Monitoring

### View Logs
```bash
# Real-time logs
railway logs --follow

# Last 100 lines
railway logs --tail 100
```

### Metrics
- Railway dashboard shows:
  - CPU usage
  - Memory usage
  - Network traffic
  - Response times

---

## 🔐 Security Best Practices

1. **Never commit secrets**:
   ```bash
   # Add to .gitignore
   appsettings.Production.json
   *.env
   ```

2. **Use Railway environment variables** for:
   - Database credentials
   - API keys
   - Connection strings

3. **Enable HTTPS** (automatic on Railway)

4. **Restrict CORS** if needed:
   ```csharp
   builder.Services.AddCors(options =>
   {
       options.AddPolicy("Production", policy =>
       {
           policy.WithOrigins("https://your-domain.com")
                 .AllowAnyMethod()
                 .AllowAnyHeader();
       });
   });
   ```

---

## 📱 Mobile Access

Your Railway app is mobile-responsive thanks to Bootstrap 5:
- Access from any device
- Touch-friendly interface
- Responsive tables

---

## 🆘 Support

### Railway Support
- Docs: https://docs.railway.app
- Discord: https://discord.gg/railway
- Twitter: @Railway

### Project Issues
- Create issue in GitHub repository
- Check deployment logs: `railway logs`

---

## ✅ Deployment Checklist

Before deploying:

- [ ] Code pushed to GitHub
- [ ] Dockerfile exists in repository root
- [ ] `.dockerignore` configured
- [ ] Railway project created
- [ ] PostgreSQL database added
- [ ] Environment variables set
- [ ] Database initialized/migrated
- [ ] Public domain generated
- [ ] Application tested

---

## 🎉 Success!

Your SMPPI Dashboard should now be live at:
**https://your-app.railway.app**

Access these URLs:
- Dashboard: `/Dashboard/Index`
- Researchers: `/Researchers/Index`
- Projects: `/Projects/Index`
- Publications: `/Publications/Index`
- Grants: `/Grants/Index`
- IP: `/IntellectualProperty/Index`

---

## 🔄 Next Steps

1. **Initialize sample data** in PostgreSQL
2. **Test all features** (search, filter, export)
3. **Monitor performance** in Railway dashboard
4. **Set up custom domain** (optional)
5. **Configure backups** for database

---

**Need help?** Check the troubleshooting section or contact support.

Happy deploying! 🚀
