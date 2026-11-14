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
// Compare the first path segment ("blog", "experiment", "resources.html", ...)
const section = p => p.replace(/^\/+/, '').split('/')[0];
const here = section(window.location.pathname);
document.querySelectorAll('.nav-links a').forEach(link => {
  if (!link.getAttribute('href')) return;
  const target = section(new URL(link.href).pathname);
  link.classList.toggle('active', target !== '' && target === here);
});

// Back to top
const btt = document.querySelector('.back-to-top');
if (btt) {
  window.addEventListener('scroll', () => {
    btt.classList.toggle('visible', window.scrollY > 400);
  });
}
