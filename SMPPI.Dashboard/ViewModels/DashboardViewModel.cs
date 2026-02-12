namespace SMPPI.Dashboard.ViewModels
{
    public class DashboardViewModel
    {
        // Statistics Cards
        public int TotalResearchers { get; set; }
        public int ActiveProjects { get; set; }
        public int CurrentYearPublications { get; set; }
        public decimal TotalGrantAmount { get; set; }

        // Chart Data for Projects by Phase
        public Dictionary<string, int> ProjectsByPhase { get; set; } = new();

        // Chart Data for Publications by Type
        public Dictionary<string, int> PublicationsByType { get; set; } = new();

        // Chart Data for Research Domains
        public Dictionary<string, int> ResearchDomainDistribution { get; set; } = new();

        // Chart Data for Grant Spending
        public List<GrantSpendingData> GrantSpendingData { get; set; } = new();

        // Recent Activity
        public List<RecentActivityItem> RecentActivities { get; set; } = new();
    }

    public class GrantSpendingData
    {
        public string Phase { get; set; } = string.Empty;
        public decimal AllocatedAmount { get; set; }
        public decimal SpentAmount { get; set; }
    }

    public class RecentActivityItem
    {
        public string ActivityType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Icon { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
    }
}
