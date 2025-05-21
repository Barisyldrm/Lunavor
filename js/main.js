// Navbar Scroll Effect
window.addEventListener('scroll', function() {
    const navbar = document.querySelector('.navbar');
    if (window.scrollY > 50) {
        navbar.style.padding = '0.5rem 0';
        navbar.style.backgroundColor = 'rgba(44, 62, 80, 0.95)';
    } else {
        navbar.style.padding = '1rem 0';
        navbar.style.backgroundColor = '#2c3e50';
    }
});

// Form Validation
document.addEventListener('DOMContentLoaded', function() {
    const contactForm = document.querySelector('.contact-form');
    if (contactForm) {
        contactForm.addEventListener('submit', function(e) {
            e.preventDefault();
            
            // Form validation
            const name = document.getElementById('name').value;
            const email = document.getElementById('email').value;
            const subject = document.getElementById('subject').value;
            const message = document.getElementById('message').value;
            
            if (!name || !email || !subject || !message) {
                alert('Lütfen tüm alanları doldurun.');
                return;
            }
            
            // Email validation
            const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            if (!emailRegex.test(email)) {
                alert('Lütfen geçerli bir e-posta adresi girin.');
                return;
            }
            
            // Form submission simulation
            alert('Mesajınız başarıyla gönderildi. En kısa sürede size dönüş yapacağız.');
            contactForm.reset();
        });
    }
});

// Smooth Scroll
document.querySelectorAll('a[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', function (e) {
        e.preventDefault();
        const target = document.querySelector(this.getAttribute('href'));
        if (target) {
            target.scrollIntoView({
                behavior: 'smooth',
                block: 'start'
            });
        }
    });
});

// Cookie Uyarısı
function setCookie(name, value, days) {
    let expires = "";
    if (days) {
        const date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        expires = "; expires=" + date.toUTCString();
    }
    document.cookie = name + "=" + (value || "") + expires + "; path=/";
}

function getCookie(name) {
    const nameEQ = name + "=";
    const ca = document.cookie.split(';');
    for(let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) === ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) === 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

// Cookie uyarısını göster
if (!getCookie('cookieConsent')) {
    const cookieAlert = document.createElement('div');
    cookieAlert.className = 'cookie-alert';
    cookieAlert.innerHTML = `
        <p>Bu web sitesi, size en iyi deneyimi sunmak için çerezleri kullanmaktadır.</p>
        <button onclick="acceptCookies()">Kabul Et</button>
    `;
    document.body.appendChild(cookieAlert);
}

function acceptCookies() {
    setCookie('cookieConsent', 'true', 365);
    document.querySelector('.cookie-alert').remove();
}

// Sayfa Yükleme Animasyonu
window.addEventListener('load', function() {
    document.body.classList.add('loaded');
});

// Mobile Menu Toggle
const navbarToggler = document.querySelector('.navbar-toggler');
const navbarCollapse = document.querySelector('.navbar-collapse');

if (navbarToggler && navbarCollapse) {
    navbarToggler.addEventListener('click', function() {
        navbarCollapse.classList.toggle('show');
    });

    // Close mobile menu when clicking outside
    document.addEventListener('click', function(e) {
        if (!navbarToggler.contains(e.target) && !navbarCollapse.contains(e.target)) {
            navbarCollapse.classList.remove('show');
        }
    });
} 