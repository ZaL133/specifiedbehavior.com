<template>
    <div class="post-container">
      <router-link v-for="page in pages" :to="page.path">
        <div class="post-card custom">
          <img class="article-image" v-bind:src="page.frontmatter.thumbnail" v-bind:alt="page.frontmatter.thumbnail_description" />
          <div class="page-detail">
            <div class="page-title">{{ page.title }}</div>
            <div class="page-description">{{ page.frontmatter.description }}</div>
            <div class="page-author">Author: {{ page.frontmatter.author }}</div>
            <div class="page-date">{{ new Date(page.frontmatter.date).toLocaleDateString() }}</div>
          </div>
        </div>
      </router-link>
    </div>
  </template>
  <style scoped>
  .post-container {
    display: flex;
    flex-wrap: wrap;
    width: 100%;
  }
  .post-card {
    width: 600px;
    height: 150px;
    margin: 10px;
    border: 1px solid #ccc;
    border-radius: 3px;
    padding: 10px;
    display: flex;
    align-items: center;
    position: relative;
    font-size: .95em;
    color:black;
    text-decoration: none;
  }
  .page-title {
    font-size: 1.25em;
    margin-bottom: 4px;
  }
  .article-image {
    height: 100%;
    max-width: 25%;
    position: absolute;
  }
  .description {
    width: 100%;
    display: flex;
    justify-content: center;
  }

  .page-detail {
    margin-left: 33%;
  }

  @media (max-width: 991px) {
    .post-card {
      max-width: unset;
      width: unset;
      height: unset;
      flex-direction: column;
    }
    .page-detail {
      margin-left: unset;
    }
    .article-image, .theme-default-content:not(.custom) img, .page-detail {
      position: relative;
      max-width: 80vw;
    }
  }
  </style>
  <script>
  export default {
    data() {
      return {
        pages: [],
        thumbnail: ""
      }
    },
    mounted() {
      let p = [];
      this.$site.pages.forEach(page => {
        if (page.frontmatter.type === 'blogpost') {
          p.push(page)
        }
      });
      this.pages = p.sort((x, y) => x.frontmatter.date < y.frontmatter.date ? 1 : (x.frontmatter.date > y.frontmatter.date ? -1 : 0));
    }
  }
  </script>