// Researchers page functionality

let allResearchers = [];
let filteredResearchers = [];

// Load researchers data on page load
document.addEventListener('DOMContentLoaded', function() {
    loadResearchers();

    // Add event listeners for real-time search
    document.getElementById('searchInput').addEventListener('input', applyFilters);
    document.getElementById('facultyFilter').addEventListener('change', applyFilters);
    document.getElementById('domainFilter').addEventListener('change', applyFilters);
});

async function loadResearchers() {
    try {
        const response = await fetch('data/researchers.json');
        allResearchers = await response.json();
        filteredResearchers = [...allResearchers];

        // Populate filter dropdowns
        populateFilters();

        // Display all researchers initially
        displayResearchers(filteredResearchers);

    } catch (error) {
        console.error('Error loading researchers:', error);
        document.getElementById('researchersTableBody').innerHTML =
            '<tr><td colspan="7" class="text-center text-danger">Error loading data</td></tr>';
    }
}

function populateFilters() {
    // Get unique faculties
    const faculties = [...new Set(allResearchers.map(r => r.faculty))].sort();
    const facultySelect = document.getElementById('facultyFilter');
    faculties.forEach(faculty => {
        const option = document.createElement('option');
        option.value = faculty;
        option.textContent = faculty;
        facultySelect.appendChild(option);
    });

    // Get unique research domains
    const domains = [...new Set(allResearchers.map(r => r.researchDomain))].sort();
    const domainSelect = document.getElementById('domainFilter');
    domains.forEach(domain => {
        const option = document.createElement('option');
        option.value = domain;
        option.textContent = domain;
        domainSelect.appendChild(option);
    });
}

function applyFilters() {
    const searchTerm = document.getElementById('searchInput').value.toLowerCase();
    const selectedFaculty = document.getElementById('facultyFilter').value;
    const selectedDomain = document.getElementById('domainFilter').value;

    filteredResearchers = allResearchers.filter(researcher => {
        // Search term filter
        const matchesSearch = !searchTerm ||
            researcher.fullName.toLowerCase().includes(searchTerm) ||
            researcher.umsper.toLowerCase().includes(searchTerm) ||
            researcher.email.toLowerCase().includes(searchTerm);

        // Faculty filter
        const matchesFaculty = !selectedFaculty || researcher.faculty === selectedFaculty;

        // Domain filter
        const matchesDomain = !selectedDomain || researcher.researchDomain === selectedDomain;

        return matchesSearch && matchesFaculty && matchesDomain;
    });

    displayResearchers(filteredResearchers);
}

function displayResearchers(researchers) {
    const tbody = document.getElementById('researchersTableBody');
    document.getElementById('resultsCount').textContent = researchers.length;

    if (researchers.length === 0) {
        tbody.innerHTML = '<tr><td colspan="7" class="text-center py-4">No researchers found</td></tr>';
        return;
    }

    tbody.innerHTML = researchers.map(researcher => `
        <tr>
            <td><code>${researcher.umsper}</code></td>
            <td class="fw-bold">${researcher.fullName}</td>
            <td><span class="badge bg-info">${researcher.position}</span></td>
            <td><small>${researcher.faculty}</small></td>
            <td><small>${researcher.researchDomain}</small></td>
            <td class="text-center">
                <span class="badge bg-primary rounded-pill">${researcher.totalPublications}</span>
            </td>
            <td class="text-center">
                ${researcher.isActive ?
                    '<span class="badge bg-success">Active</span>' :
                    '<span class="badge bg-secondary">Inactive</span>'
                }
            </td>
        </tr>
    `).join('');
}

function clearFilters() {
    document.getElementById('searchInput').value = '';
    document.getElementById('facultyFilter').value = '';
    document.getElementById('domainFilter').value = '';
    applyFilters();
}
