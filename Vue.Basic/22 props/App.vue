<template>
  <div id="app">
    <img alt="Vue logo" src="./assets/logo.png">
    <h1 v-text="msg" ref="showTitle"></h1>
    <button @click="showDom">点我输出上方的 DOM 元素</button>
    <StudentInfo studentName="lisi" :studentAge="19" />
  </div>
</template>

<script>
import StudentInfo from "./components/StudentInfo";

export default {
  name: "App",
  components: {
    StudentInfo,
  },
  // 必须要写成函数式的，返回不同实例
  data() {
    return {
      msg: "welcome to vue",
    };
  },
  methods: {
    showDom() {
      console.log(this.$refs.showTitle);
    },
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
