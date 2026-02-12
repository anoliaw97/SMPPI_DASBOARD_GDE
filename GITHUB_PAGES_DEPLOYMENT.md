# 📄 GitHub Pages Deployment Guide

Deploy the SMPPI Dashboard **static demo version** to GitHub Pages for free hosting and easy demonstration.

## 🌟 What is This?

This is a **static HTML/CSS/JavaScript version** of the SMPPI Dashboard that:
- ✅ Runs entirely in the browser (no server required)
- ✅ Uses JSON files for sample data
- ✅ Has the same beautiful UI as the full ASP.NET version
- ✅ Includes interactive charts and search functionality
- ✅ Perfect for demos and showcasing features

**Note**: This is NOT the full database-backed application. For production use with real data, see the [Railway deployment guide](RAILWAY_DEPLOYMENT.md).

---

## 🚀 Quick Deploy (2 Minutes)

### Step 1: Enable GitHub Pages

1. **Go to your GitHub repository**:
   ```
   https://github.com/anoliaw97/SMPPI_DASBOARD_GDE
   ```

2. **Navigate to Settings**:
   - Click the "Settings" tab at the top
   - Scroll down to "Pages" in the left sidebar

3. **Configure GitHub Pages**:
   - **Source**: Deploy from a branch
   - **Branch**: Select `claude/aspnet-dashboard-visualization-Vah2Q`
   - **Folder**: Select `/docs`
   - Click "Save"

4. **Wait for deployment** (1-2 minutes):
   - GitHub will automatically build and deploy your site
   - You'll see a green checkmark when ready

5. **Access your site**:
   ```
   https://anoliaw97.github.io/SMPPI_DASBOARD_GDE/
   ```

That's it! Your dashboard is now live! 🎉

---

## 📂 Static Site Structure

```
docs/
├── index.html              # Dashboard homepage
├── researchers.html        # Researchers page with search
├── projects.html           # Projects page (placeholder)
├── publications.html       # Publications page (placeholder)
├── grants.html            # Grants page (placeholder)
├── _config.yml            # GitHub Pages configuration
├── css/
│   └── style.css          # Custom styles (same as ASP.NET version)
├── js/
│   ├── dashboard.js       # Dashboard charts and statistics
│   └── researchers.js     # Researchers search functionality
└── data/
    ├── researchers.json   # Sample researcher data
    └── projects.json      # Sample project data
```

---

## ✨ Features Included

### 1. Dashboard (index.html)
- ✅ Statistics cards (Total Researchers, Active Projects, etc.)
- ✅ Chart.js visualizations:
  - Projects by Phase (Bar Chart)
  - Publications by Type (Doughnut Chart)
  - Research Domain Distribution (Pie Chart)
  - Grant Spending vs Allocation (Line Chart)
- ✅ Responsive Bootstrap 5 design
- ✅ Purple-blue gradient theme

### 2. Researchers Page (researchers.html)
- ✅ Search by name, UMSPER, or email
- ✅ Filter by faculty
- ✅ Filter by research domain
- ✅ Real-time client-side filtering
- ✅ Responsive table display
- ✅ Sample data for 8 researchers

### 3. Sample Data
All data is stored in JSON files:
- **8 Academic Staff** from various faculties
- **6 Research Projects** (FRGS 2020-2024)
- **Grant Statistics** (RM 14M+ allocated)
- **Publication Stats** (221 total publications)

---

## 🎨 What's Different from Full Version?

| Feature | Full ASP.NET Version | Static Demo Version |
|---------|---------------------|---------------------|
| **Database** | SQL Server / PostgreSQL | JSON files |
| **Backend** | C# / ASP.NET Core | None (client-side only) |
| **Search** | Server-side with EF Core | Client-side JavaScript |
| **Export** | PDF/Excel/CSV | Not available |
| **Real-time Data** | Yes | No (static sample data) |
| **Authentication** | ASP.NET Identity | None |
| **Deployment** | Railway/Azure/IIS | GitHub Pages (free) |
| **Cost** | $5-10/month | FREE |
| **Best for** | Production use | Demos, showcasing UI |

---

## 🔧 Customization

### Adding More Pages

To add a new page (e.g., Projects):

1. **Create HTML file**:
   ```html
   <!-- docs/projects.html -->
   <!DOCTYPE html>
   <html>
   <!-- Copy structure from researchers.html -->
   </html>
   ```

2. **Create data file**:
   ```json
   // docs/data/projects.json
   [
     {
       "projectCode": "FRGS/1/2024/...",
       "projectTitle": "..."
     }
   ]
   ```

3. **Create JavaScript**:
   ```javascript
   // docs/js/projects.js
   // Add load and display logic
   ```

### Updating Data

Simply edit the JSON files in `docs/data/`:

```javascript
// docs/data/researchers.json
[
  {
    "staffID": 9,
    "umsper": "UMS009",
    "fullName": "Your Name",
    "position": "Lecturer",
    "faculty": "Your Faculty",
    // ... add more fields
  }
]
```

Push changes and GitHub Pages will auto-update in ~1 minute.

### Changing Colors

Edit `docs/css/style.css`:

```css
:root {
    --primary-blue: #667eea;    /* Change this */
    --primary-purple: #764ba2;  /* And this */
}
```

---

## 🔄 Continuous Deployment

Every push to your branch automatically updates GitHub Pages:

```bash
# Make changes
cd docs
# Edit HTML, CSS, or JSON files

# Commit and push
git add docs/
git commit -m "Update static demo"
git push

# GitHub Pages auto-deploys in ~1 minute
```

---

## 📊 Analytics (Optional)

Add Google Analytics to track visitors:

1. **Get tracking ID** from Google Analytics

2. **Add to HTML** (before `</head>`):
   ```html
   <!-- Google Analytics -->
   <script async src="https://www.googletagmanager.com/gtag/js?id=G-XXXXXXXXXX"></script>
   <script>
     window.dataLayer = window.dataLayer || [];
     function gtag(){dataLayer.push(arguments);}
     gtag('js', new Date());
     gtag('config', 'G-XXXXXXXXXX');
   </script>
   ```

---

## 🌐 Custom Domain (Optional)

### Using Your Own Domain

1. **Add CNAME file** in `docs/`:
   ```
   dashboard.ums.edu.my
   ```

2. **Configure DNS** at your domain provider:
   ```
   Type: CNAME
   Name: dashboard
   Value: anoliaw97.github.io
   ```

3. **Enable in GitHub**:
   - Settings → Pages
   - Custom domain: `dashboard.ums.edu.my`
   - Check "Enforce HTTPS"

**Note**: May take 24-48 hours for DNS propagation.

---

## 🐛 Troubleshooting

### Page Not Found (404)

**Problem**: Site shows 404 error

**Solutions**:
1. Check Settings → Pages is configured correctly
2. Ensure branch is `claude/aspnet-dashboard-visualization-Vah2Q`
3. Ensure folder is `/docs`
4. Wait 2-3 minutes for initial deployment
5. Check Actions tab for build status

### Charts Not Showing

**Problem**: Dashboard loads but charts are empty

**Solutions**:
1. Open browser console (F12) for errors
2. Check if Chart.js CDN is loading:
   ```html
   <script src="https://cdn.jsdelivr.net/npm/chart.js@4.4.0/dist/chart.umd.min.js"></script>
   ```
3. Verify JSON data files are accessible:
   ```
   https://your-site.github.io/SMPPI_DASBOARD_GDE/data/researchers.json
   ```

### Search Not Working

**Problem**: Researchers page search doesn't filter

**Solutions**:
1. Check browser console for JavaScript errors
2. Verify `researchers.js` is loading
3. Check JSON data format is correct
4. Clear browser cache (Ctrl+Shift+R)

### Styling Issues

**Problem**: Page looks broken or unstyled

**Solutions**:
1. Verify Bootstrap CDN is loading
2. Check `style.css` is in `docs/css/` folder
3. Clear browser cache
4. Check browser console for CSS errors

---

## 📱 Mobile Testing

GitHub Pages site is fully responsive. Test on:

- **Mobile**: iOS Safari, Chrome Mobile
- **Tablet**: iPad, Android tablets
- **Desktop**: Chrome, Firefox, Edge, Safari

Use browser DevTools (F12) → Toggle Device Toolbar for responsive testing.

---

## 🔒 Security

### What's Safe:
- ✅ All data is static JSON files
- ✅ No server-side code execution
- ✅ No database or user input
- ✅ Automatic HTTPS from GitHub
- ✅ No authentication needed (public demo)

### Considerations:
- ⚠️ All data is publicly visible
- ⚠️ Don't include sensitive information in JSON files
- ⚠️ No user authentication on static pages

---

## 💰 Cost

**GitHub Pages is 100% FREE** for public repositories:

- ✅ Unlimited bandwidth
- ✅ Automatic HTTPS
- ✅ Custom domain support
- ✅ Automatic deployments
- ✅ Global CDN

**Limitations**:
- 1 GB repository size
- 100 GB bandwidth/month (more than enough)
- 10 builds/hour

---

## 🎯 Use Cases

Perfect for:
- ✅ Demonstrating dashboard features
- ✅ Showcasing UI/UX design
- ✅ Portfolio projects
- ✅ Sharing with stakeholders
- ✅ User testing and feedback
- ✅ Documentation and tutorials

Not suitable for:
- ❌ Production with real data
- ❌ User authentication
- ❌ Database operations
- ❌ Server-side processing
- ❌ File uploads

For production, use the [Railway deployment](RAILWAY_DEPLOYMENT.md).

---

## 📚 Additional Resources

### GitHub Pages Documentation
- Official Docs: https://pages.github.com/
- Custom Domains: https://docs.github.com/pages/configuring-a-custom-domain-for-your-github-pages-site
- Troubleshooting: https://docs.github.com/pages/setting-up-a-github-pages-site-with-jekyll/troubleshooting-jekyll-build-errors-for-github-pages-sites

### Frontend Libraries Used
- Bootstrap 5: https://getbootstrap.com/
- Chart.js: https://www.chartjs.org/
- Bootstrap Icons: https://icons.getbootstrap.com/

---

## ✅ Checklist

Before sharing your GitHub Pages site:

- [ ] GitHub Pages is enabled in Settings
- [ ] Site is accessible at the URL
- [ ] All pages load correctly (Dashboard, Researchers)
- [ ] Charts are displaying on Dashboard
- [ ] Search works on Researchers page
- [ ] Mobile responsive on phone/tablet
- [ ] No console errors in browser
- [ ] Data is appropriate for public viewing
- [ ] Custom domain configured (if needed)

---

## 🆘 Need Help?

### GitHub Pages Issues
- Check: https://www.githubstatus.com/
- Docs: https://docs.github.com/pages

### Project Issues
- Create issue: https://github.com/anoliaw97/SMPPI_DASBOARD_GDE/issues
- Check existing issues first

### For Full Application
- See [README.md](README.md) for local development
- See [RAILWAY_DEPLOYMENT.md](RAILWAY_DEPLOYMENT.md) for cloud deployment

---

## 🎉 Success!

Your SMPPI Dashboard demo is now live on GitHub Pages!

**Share your link**:
```
https://anoliaw97.github.io/SMPPI_DASBOARD_GDE/
```

**Pages available**:
- Dashboard: `/index.html`
- Researchers: `/researchers.html`

---

**Next Steps**:
1. ✅ Share the link with stakeholders
2. ✅ Gather feedback on UI/UX
3. ✅ Add more sample data if needed
4. ✅ Deploy full version to Railway for production

Happy demoing! 🚀
