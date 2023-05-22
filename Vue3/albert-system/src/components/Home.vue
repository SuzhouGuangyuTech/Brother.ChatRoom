<template>
  <div>
    <h1>{{ newsData.title }}</h1>
    <button @click="ChangeTitle">改变</button>
  </div>
</template>
 
<script lang='ts'>
import { defineComponent } from "vue";

interface News {
  title: string;
  description: string;
  count: number | string;
  content?: string;
}

let newsData = {
  title: "我是标题",
  description: "标题描述",
  count: 12,
  content: "我是内容",
} as News;

export default defineComponent({
  // eslint-disable-next-line vue/multi-word-component-names
  name: "Home",
  data() {
    return {
      newsData,
    };
  },
  methods: {
    ChangeTitle() {
      this.newsData.title = "我是改变后的标题";
    },
  },
});
</script>
 
<style scoped>
</style>