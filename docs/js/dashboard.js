// SMPPI Dashboard Static Demo

// Load data and initialize dashboard
document.addEventListener('DOMContentLoaded', function() {
    loadDashboardData();
});

async function loadDashboardData() {
    try {
        // Load all data
        const [researchers, projects] = await Promise.all([
            fetch('data/researchers.json').then(r => r.json()),
            fetch('data/projects.json').then(r => r.json())
        ]);

        // Update statistics
        updateStatistics(researchers, projects);

        // Render charts
        renderProjectsByPhaseChart(projects);
        renderPublicationsByTypeChart();
        renderResearchDomainChart(projects);
        renderGrantSpendingChart();

    } catch (error) {
        console.error('Error loading dashboard data:', error);
    }
}

function updateStatistics(researchers, projects) {
    // Total Researchers
    document.getElementById('totalResearchers').textContent = researchers.length;

    // Active Projects
    const activeProjects = projects.filter(p =>
        p.projectStatus === 'Active' || p.projectStatus === 'OnSchedule'
    ).length;
    document.getElementById('activeProjects').textContent = activeProjects;

    // Current Year Publications (placeholder)
    document.getElementById('currentYearPubs').textContent = '17';

    // Total Grant Amount
    const totalGrants = [2600515, 1118062, 3941772, 3486722, 2913753]
        .reduce((a, b) => a + b, 0);
    document.getElementById('totalGrants').textContent =
        'RM ' + totalGrants.toLocaleString('en-MY');
}

function renderProjectsByPhaseChart(projects) {
    const phases = {};
    projects.forEach(p => {
        phases[p.phase] = (phases[p.phase] || 0) + 1;
    });

    const ctx = document.getElementById('projectsByPhaseChart').getContext('2d');
    new Chart(ctx, {
        type: 'bar',
        data: {
            labels: Object.keys(phases),
            datasets: [{
                label: 'Number of Projects',
                data: Object.values(phases),
                backgroundColor: 'rgba(54, 162, 235, 0.6)',
                borderColor: 'rgba(54, 162, 235, 1)',
                borderWidth: 2
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: { display: false }
            },
            scales: {
                y: { beginAtZero: true }
            }
        }
    });
}

function renderPublicationsByTypeChart() {
    const publicationTypes = {
        'Indexed Journals': 122,
        'Non-Indexed Journals': 11,
        'Int. Conferences': 73,
        'Nat. Conferences': 15
    };

    const ctx = document.getElementById('publicationsByTypeChart').getContext('2d');
    new Chart(ctx, {
        type: 'doughnut',
        data: {
            labels: Object.keys(publicationTypes),
            datasets: [{
                data: Object.values(publicationTypes),
                backgroundColor: [
                    'rgba(255, 99, 132, 0.7)',
                    'rgba(54, 162, 235, 0.7)',
                    'rgba(255, 206, 86, 0.7)',
                    'rgba(75, 192, 192, 0.7)'
                ]
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: { position: 'bottom' }
            }
        }
    });
}

function renderResearchDomainChart(projects) {
    const domains = {};
    projects.forEach(p => {
        domains[p.researchDomain] = (domains[p.researchDomain] || 0) + 1;
    });

    const ctx = document.getElementById('researchDomainChart').getContext('2d');
    new Chart(ctx, {
        type: 'pie',
        data: {
            labels: Object.keys(domains),
            datasets: [{
                data: Object.values(domains),
                backgroundColor: [
                    'rgba(255, 99, 132, 0.7)',
                    'rgba(54, 162, 235, 0.7)',
                    'rgba(255, 206, 86, 0.7)',
                    'rgba(75, 192, 192, 0.7)',
                    'rgba(153, 102, 255, 0.7)'
                ]
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: { position: 'bottom' }
            }
        }
    });
}

function renderGrantSpendingChart() {
    const grantData = [
        { phase: 'Fasa 1/2020', allocated: 2600515, spent: 2340464 },
        { phase: 'Fasa 1/2021', allocated: 1118062, spent: 950753 },
        { phase: 'Fasa 1/2022', allocated: 3941772, spent: 3547595 },
        { phase: 'Fasa 1/2023', allocated: 3486722, spent: 2789378 },
        { phase: 'Fasa 1/2024', allocated: 2913753, spent: 1456877 }
    ];

    const ctx = document.getElementById('grantSpendingChart').getContext('2d');
    new Chart(ctx, {
        type: 'line',
        data: {
            labels: grantData.map(g => g.phase),
            datasets: [{
                label: 'Allocated Amount (RM)',
                data: grantData.map(g => g.allocated),
                borderColor: 'rgba(75, 192, 192, 1)',
                backgroundColor: 'rgba(75, 192, 192, 0.2)',
                borderWidth: 2,
                fill: true
            }, {
                label: 'Spent Amount (RM)',
                data: grantData.map(g => g.spent),
                borderColor: 'rgba(255, 99, 132, 1)',
                backgroundColor: 'rgba(255, 99, 132, 0.2)',
                borderWidth: 2,
                fill: true
            }]
        },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            interaction: {
                mode: 'index',
                intersect: false
            },
            plugins: {
                legend: { position: 'bottom' }
            },
            scales: {
                y: { beginAtZero: true }
            }
        }
    });
}

// Format currency
function formatCurrency(amount) {
    return 'RM ' + parseFloat(amount).toLocaleString('en-MY', {
        minimumFractionDigits: 2,
        maximumFractionDigits: 2
    });
}
