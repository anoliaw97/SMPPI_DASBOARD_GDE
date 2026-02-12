using Microsoft.EntityFrameworkCore;
using SMPPI.Dashboard.Data;
using SMPPI.Dashboard.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure Database (supports both SQL Server and PostgreSQL)
var databaseProvider = builder.Configuration.GetValue<string>("DatabaseProvider") ?? "SqlServer";
var connectionString = builder.Configuration.GetConnectionString("SMPPIDatabase")
    ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<SMPPIDbContext>(options =>
{
    if (databaseProvider.Equals("PostgreSQL", StringComparison.OrdinalIgnoreCase))
    {
        options.UseNpgsql(connectionString);
    }
    else
    {
        options.UseSqlServer(connectionString);
    }
});

// Configure Session for filters
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Register Services
builder.Services.AddScoped<IExportService, ExportService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IResearcherService, ResearcherService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IPublicationService, PublicationService>();
builder.Services.AddScoped<IGrantService, GrantService>();
builder.Services.AddScoped<IIntellectualPropertyService, IntellectualPropertyService>();

// Configure Memory Cache
builder.Services.AddMemoryCache();

// Configure EPPlus License (Non-Commercial)
OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
