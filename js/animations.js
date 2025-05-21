// Scroll Animasyonları
const animateOnScroll = () => {
    const elements = document.querySelectorAll('.animate-on-scroll');
    
    elements.forEach(element => {
        const elementPosition = element.getBoundingClientRect().top;
        const screenPosition = window.innerHeight / 1.3;
        
        if(elementPosition < screenPosition) {
            element.classList.add('animate-fade-in');
        }
    });
}

window.addEventListener('scroll', animateOnScroll);

// Sayfa yüklendiğinde ilk animasyonları tetikle
window.addEventListener('load', animateOnScroll);

// Hero Section Parallax Efekti
const heroSection = document.querySelector('.hero-section');
if (heroSection) {
    window.addEventListener('scroll', () => {
        const scrollPosition = window.pageYOffset;
        heroSection.style.backgroundPositionY = scrollPosition * 0.5 + 'px';
    });
}

// Hizmet Kartları Hover Efekti
const serviceCards = document.querySelectorAll('.service-card');
serviceCards.forEach(card => {
    card.addEventListener('mouseenter', () => {
        card.style.transform = 'translateY(-10px)';
    });
    
    card.addEventListener('mouseleave', () => {
        card.style.transform = 'translateY(0)';
    });
});

// Sayfa Geçiş Animasyonları
document.addEventListener('DOMContentLoaded', () => {
    const links = document.querySelectorAll('a[href^="#"]');
    
    links.forEach(link => {
        link.addEventListener('click', (e) => {
            e.preventDefault();
            
            const targetId = link.getAttribute('href');
            const targetElement = document.querySelector(targetId);
            
            if (targetElement) {
                // Mevcut scroll pozisyonunu kaydet
                const currentScroll = window.pageYOffset;
                
                // Hedef elemente scroll
                targetElement.scrollIntoView({
                    behavior: 'smooth',
                    block: 'start'
                });
                
                // Scroll tamamlandığında animasyonu tetikle
                setTimeout(() => {
                    targetElement.classList.add('animate-fade-in');
                }, 500);
            }
        });
    });
});

// Loading Animasyonu
const loadingAnimation = () => {
    const loader = document.createElement('div');
    loader.className = 'page-loader';
    loader.innerHTML = `
        <div class="spinner"></div>
    `;
    document.body.appendChild(loader);
    
    window.addEventListener('load', () => {
        loader.classList.add('fade-out');
        setTimeout(() => {
            loader.remove();
        }, 500);
    });
}

loadingAnimation();

// Scroll Progress Bar
const createScrollProgress = () => {
    const progressBar = document.createElement('div');
    progressBar.className = 'scroll-progress';
    document.body.appendChild(progressBar);
    
    window.addEventListener('scroll', () => {
        const windowHeight = document.documentElement.scrollHeight - document.documentElement.clientHeight;
        const progress = (window.scrollY / windowHeight) * 100;
        progressBar.style.width = progress + '%';
    });
}

createScrollProgress();

// Scroll Animasyonları
document.addEventListener('DOMContentLoaded', function() {
    // AOS (Animate On Scroll) benzeri basit bir animasyon sistemi
    const animatedElements = document.querySelectorAll('.service-card, .portfolio-item, .blog-card');
    
    const observerOptions = {
        root: null,
        rootMargin: '0px',
        threshold: 0.1
    };
    
    const observer = new IntersectionObserver((entries, observer) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.classList.add('animate__animated', 'animate__fadeInUp');
                observer.unobserve(entry.target);
            }
        });
    }, observerOptions);
    
    animatedElements.forEach(element => {
        observer.observe(element);
    });
});

// Hover Efektleri
document.addEventListener('DOMContentLoaded', function() {
    const portfolioItems = document.querySelectorAll('.portfolio-item');
    
    portfolioItems.forEach(item => {
        item.addEventListener('mouseenter', function() {
            this.querySelector('.portfolio-overlay').style.opacity = '1';
        });
        
        item.addEventListener('mouseleave', function() {
            this.querySelector('.portfolio-overlay').style.opacity = '0';
        });
    });
});

// Sayfa Yükleme Animasyonu
window.addEventListener('load', function() {
    document.body.classList.add('loaded');
});

// Smooth Scroll için Ek Animasyonlar
document.querySelectorAll('a[href^="#"]').forEach(anchor => {
    anchor.addEventListener('click', function (e) {
        e.preventDefault();
        const target = document.querySelector(this.getAttribute('href'));
        if (target) {
            const headerOffset = 80;
            const elementPosition = target.getBoundingClientRect().top;
            const offsetPosition = elementPosition + window.pageYOffset - headerOffset;

            window.scrollTo({
                top: offsetPosition,
                behavior: 'smooth'
            });
        }
    });
}); 