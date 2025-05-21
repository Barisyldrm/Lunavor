// AOS (Animate On Scroll) benzeri basit animasyon sistemi
document.addEventListener('DOMContentLoaded', function() {
    const animatedElements = document.querySelectorAll('.animate-on-scroll');
    
    const observerOptions = {
        threshold: 0.1,
        rootMargin: '0px'
    };

    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                const element = entry.target;
                const animation = element.getAttribute('data-animation');
                element.classList.add('animated', animation);
                observer.unobserve(element);
            }
        });
    }, observerOptions);

    animatedElements.forEach(element => {
        observer.observe(element);
    });
});

// Sayfa yüklendiğinde hero section animasyonu
window.addEventListener('load', function() {
    const heroContent = document.querySelector('.hero-section .col-lg-6');
    if (heroContent) {
        heroContent.style.opacity = '0';
        heroContent.style.transform = 'translateY(20px)';
        heroContent.style.transition = 'all 1s ease';
        
        setTimeout(() => {
            heroContent.style.opacity = '1';
            heroContent.style.transform = 'translateY(0)';
        }, 500);
    }
});

// Feature Cards Animasyonu
const featureCards = document.querySelectorAll('.feature-card');
const featureObserver = new IntersectionObserver((entries) => {
    entries.forEach(entry => {
        if (entry.isIntersecting) {
            entry.target.classList.add('animate__animated', 'animate__fadeInUp');
            featureObserver.unobserve(entry.target);
        }
    });
}, {
    threshold: 0.2
});

featureCards.forEach(card => {
    featureObserver.observe(card);
}); 