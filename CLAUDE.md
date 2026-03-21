# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is a hybrid project for specifiedbehavior.com — an AI-focused blog/educational site. It has two independent parts:

1. **VuePress frontend** (`/src/web/docs/`) — static site deployed to Netlify
2. **ASP.NET Core 6.0 backend** (`/src/specifiedbehavior.web/`) — blog management API with SQL Server

The VuePress frontend is the primary user-facing component. The ASP.NET backend is an optional admin/management layer.

## Commands

No build step required. The `claude/` folder is pure HTML/CSS/JS and can be served directly by GitHub Pages or any static host.

To preview locally, use any static server:
```bash
cd claude
npx serve .          # or: python -m http.server 8080
```

There are no automated tests in this project.

## Architecture

The active site lives in `claude/` — a zero-dependency static site for GitHub Pages.

```
claude/
├── index.html          # homepage
├── ai-basics.html      # AI fundamentals guide
├── resources.html      # curated learning resources
├── .nojekyll           # disables Jekyll on GitHub Pages
├── blog/
│   ├── index.html      # blog listing (manually maintained)
│   └── *.html          # individual blog posts
├── css/style.css       # single stylesheet, CSS custom properties for theming
├── js/main.js          # mobile nav toggle + back-to-top
└── img/blog/           # blog post images (copy from old wwwroot if needed)
```

### Adding a new blog post

1. Create `claude/blog/your-post-slug.html` — copy the header/footer/nav from an existing post
2. Add a card to `claude/blog/index.html`
3. Optionally add it to the "Recent Posts" section of `claude/index.html`

### Design system

`css/style.css` uses CSS custom properties (`--bg`, `--text`, `--accent`, etc.) for the dark theme. The palette is Tailwind-inspired grays with indigo accents. No framework or build step — just edit the CSS directly.

### Deployment

Point GitHub Pages to the `claude/` folder (Settings → Pages → Source). The `.nojekyll` file tells GitHub Pages not to process the folder with Jekyll.

The old VuePress site (`src/web/`) and ASP.NET project (`src/specifiedbehavior.web/`) are preserved but no longer the active site.
