<template>
  <div id="app">
    <h2>自定义事件--{{ schoolValue.name }}</h2>
    第一种写法 @定义事件名="回调函数" 回调函数可以写成 getSchoolInfo(firstValue,...params)
    这边的 params 会自动变为数组，可以通过解构赋值的方式拿到
    <SchoolInfo @getSchoolEvent="getSchoolInfo" />
    <hr />
    第二种写法 ref="组件标识"，在挂载的时候挂接事件 this.refs.组件标识.$on/once('事件名', 回调函数),
    这边的回调函数如果写在 methos 中，需要使用 this.回调函数。
    <StudentInfo ref="studentInfoVc" />
    以上这两种写法，子组件都有一个 @click 事件，调用点击方法，在点击方法中，通过 this.$emit('事件名', 参数) 触发事件
    <hr />
    第三种写法 在父组件写一个方法 showHomeInfo(homeValue) 通过属性绑定的方式传递给 HomeInfo props:['showHomeInfo'],子组件调用这个方法就可以将值传递回来。
    <HomeInfo :showHomeInfo="showHomeInfo" />
    <hr />
    使用原生事件，在原生修饰符上添加 native
    <StudentInfo @click.native="showNativeAlert" />
  </div>
</template>

<script>
import SchoolInfo from "./components/SchoolInfo";
import StudentInfo from "./components/StudentInfo";
import HomeInfo from "./components/HomeInfo";

export default {
  name: "App",
  components: {
    SchoolInfo,
    StudentInfo,
    HomeInfo,
  },
  // 必须要写成函数式的，返回不同实例
  data() {
    return {
      msg: "welcome to vue",
      schoolValue: {},
    };
  },
  methods: {
    getSchoolInfo(schoolValue) {
      this.schoolValue = schoolValue;
      console.log(JSON.stringify(schoolValue));
    },
    showHomeInfo(homeValue) {
      console.log(JSON.stringify(homeValue));
    },
    showNativeAlert() {
      alert(123);
    },
  },
  // 在挂载的时候挂接事件
  mounted() {
    // 2. 通过 this.$refs.组件名.$on('事件名', 回调函数) 监听事件
    this.$refs.studentInfoVc.$on("getStudentEvent", (value) => {
      // 如果这块写成完成函数，this 指的是 StudentInfo Vc
      // 如果写成箭头函数则会向上查找，查找到的是 App Vc
      console.log(this);
      console.log(JSON.stringify(value));
    });
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
