// Mobile nav toggle
const toggle = document.querySelector('.nav-toggle');
const navLinks = document.querySelector('.nav-links');
if (toggle && navLinks) {
  toggle.addEventListener('click', () => navLinks.classList.toggle('open'));
  document.addEventListener('click', e => {
    if (!e.target.closest('.site-nav')) navLinks.classList.remove('open');
  });
}

// Active nav link
const path = window.location.pathname;
document.querySelectorAll('.nav-links a').forEach(link => {
  const href = link.getAttribute('href');
  if (!href) return;
  // Match blog section
  if (href.includes('blog') && path.includes('blog')) {
    link.classList.add('active');
  } else if (!href.includes('blog') && path.endsWith(href.split('/').pop())) {
    link.classList.add('active');
  }
});

// Back to top
const btt = document.querySelector('.back-to-top');
if (btt) {
  window.addEventListener('scroll', () => {
    btt.classList.toggle('visible', window.scrollY > 400);
  });
}
