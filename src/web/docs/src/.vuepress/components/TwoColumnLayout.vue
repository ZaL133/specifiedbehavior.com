<template>
  <div class="two-column-layout">
    <div class="column">
      <slot name="left"></slot>
    </div>
    <div class="column">
      <slot name="right"></slot>
    </div>
  </div>
</template>

<style scoped>
  .two-column-layout {
    display: flex;
    flex-direction: row;
  }
  .column {
    padding: 4px;
  }
</style>