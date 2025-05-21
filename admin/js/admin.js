// Sidebar Toggle
document.addEventListener('DOMContentLoaded', function() {
    const menuToggle = document.querySelector('.menu-toggle');
    const sidebar = document.querySelector('.admin-sidebar');
    const mainContent = document.querySelector('.admin-main');

    if (menuToggle) {
        menuToggle.addEventListener('click', function() {
            sidebar.classList.toggle('collapsed');
            mainContent.classList.toggle('expanded');
        });
    }
});

// Responsive Sidebar
function handleResize() {
    const sidebar = document.querySelector('.admin-sidebar');
    const mainContent = document.querySelector('.admin-main');
    
    if (window.innerWidth < 992) {
        sidebar.classList.add('collapsed');
        mainContent.classList.add('expanded');
    } else {
        sidebar.classList.remove('collapsed');
        mainContent.classList.remove('expanded');
    }
}

window.addEventListener('resize', handleResize);
window.addEventListener('load', handleResize);

// Form Validation
document.addEventListener('DOMContentLoaded', function() {
    const forms = document.querySelectorAll('form');
    
    forms.forEach(form => {
        form.addEventListener('submit', function(e) {
            e.preventDefault();
            
            let isValid = true;
            const requiredFields = form.querySelectorAll('[required]');
            
            requiredFields.forEach(field => {
                if (!field.value.trim()) {
                    isValid = false;
                    field.classList.add('is-invalid');
                } else {
                    field.classList.remove('is-invalid');
                }
            });
            
            if (isValid) {
                // Form gönderimi simülasyonu
                const submitButton = form.querySelector('button[type="submit"]');
                const originalText = submitButton.innerHTML;
                
                submitButton.disabled = true;
                submitButton.innerHTML = '<i class="fas fa-spinner fa-spin"></i> Gönderiliyor...';
                
                setTimeout(() => {
                    submitButton.disabled = false;
                    submitButton.innerHTML = originalText;
                    form.reset();
                    
                    // Başarı mesajı
                    const successAlert = document.createElement('div');
                    successAlert.className = 'alert alert-success mt-3';
                    successAlert.innerHTML = 'İşlem başarıyla tamamlandı.';
                    form.appendChild(successAlert);
                    
                    setTimeout(() => {
                        successAlert.remove();
                    }, 3000);
                }, 1500);
            }
        });
    });
});

// Image Preview
function previewImage(input) {
    if (input.files && input.files[0]) {
        const reader = new FileReader();
        const preview = document.querySelector(input.dataset.preview);
        
        reader.onload = function(e) {
            preview.src = e.target.result;
        }
        
        reader.readAsDataURL(input.files[0]);
    }
}

// Data Tables
document.addEventListener('DOMContentLoaded', function() {
    const tables = document.querySelectorAll('.data-table');
    
    tables.forEach(table => {
        const searchInput = document.createElement('input');
        searchInput.type = 'text';
        searchInput.className = 'form-control mb-3';
        searchInput.placeholder = 'Ara...';
        
        table.parentNode.insertBefore(searchInput, table);
        
        searchInput.addEventListener('keyup', function() {
            const searchText = this.value.toLowerCase();
            const rows = table.querySelectorAll('tbody tr');
            
            rows.forEach(row => {
                const text = row.textContent.toLowerCase();
                row.style.display = text.includes(searchText) ? '' : 'none';
            });
        });
    });
});

// Notifications
function showNotification(message, type = 'success') {
    const notification = document.createElement('div');
    notification.className = `alert alert-${type} notification`;
    notification.innerHTML = message;
    
    document.body.appendChild(notification);
    
    setTimeout(() => {
        notification.classList.add('show');
    }, 100);
    
    setTimeout(() => {
        notification.classList.remove('show');
        setTimeout(() => {
            notification.remove();
        }, 300);
    }, 3000);
}

// Chart.js Integration
if (typeof Chart !== 'undefined') {
    // Ziyaretçi Grafiği
    const visitorChart = document.getElementById('visitorChart');
    if (visitorChart) {
        new Chart(visitorChart, {
            type: 'line',
            data: {
                labels: ['Pazartesi', 'Salı', 'Çarşamba', 'Perşembe', 'Cuma', 'Cumartesi', 'Pazar'],
                datasets: [{
                    label: 'Ziyaretçi Sayısı',
                    data: [1200, 1900, 1500, 1800, 2100, 2400, 1800],
                    borderColor: '#38BDF8',
                    tension: 0.4
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false
            }
        });
    }
    
    // Hizmet Dağılımı Grafiği
    const serviceChart = document.getElementById('serviceChart');
    if (serviceChart) {
        new Chart(serviceChart, {
            type: 'doughnut',
            data: {
                labels: ['Web Tasarım', '.NET Çözümleri', 'Startup Projeleri'],
                datasets: [{
                    data: [40, 35, 25],
                    backgroundColor: ['#38BDF8', '#00B4D8', '#0A192F']
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false
            }
        });
    }
} 