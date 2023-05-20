<template>
    <div class="post-container">hi
      <router-link v-for="page in pages" :to="page.path">
        <div class="post-card">
          <img class="article-image" src="../public/images/comparing-google-bard-and-chatgpt.png" />
          <div class="page-detail">
            <div class="page-title">{{ page.title }}</div>
            <div class="page-description">{{ page.frontmatter.description }}</div>
            <div class="page-author">Author: {{ page.frontmatter.author }}</div>
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
  }
  .article-image {
    height: 100%;
  }
  .description {
    width: 100%;
    display: flex;
    justify-content: center;
  }
  </style>
  <script>
  export default {
    data() {
      return {
        pages: []
      }
    },
    mounted() {
      this.$site.pages.forEach(page => {
        if (page.frontmatter.type === 'blogpost') {
          this.pages.push(page)
        }
      })
    }
  }
  </script>