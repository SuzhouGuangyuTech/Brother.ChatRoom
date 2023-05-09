<template>
  <div id="root">
    <button @click="getSomeInfoFromServer">获取服务端接口信息</button>
    <button @click="getSomeInfoFromServerByTwo">获取服务端接口信息</button>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "App",
  components: {},
  data() {
    return {};
  },
  methods: {
    getSomeInfoFromServer() {
      // 直接请求会造成跨域失败，同源策略：协议、主机名、端口号必须相同
      // 1. cors 后端解决跨域问题
      // 2. jsonp 只能解决 get 请求跨域问题（前后端约定好，前端请求的接口返回的是 js 代码，js 代码执行的时候会执行回调函数）
      // 3. 代理服务器，让两台服务器进行交互，http 请求就完事了，没有前端技术 ajax 也可以实现跨域
      axios.get("http://localhost:8080/WeatherForecast").then(
        (res) => {
          console.log(res.data);
        },
        (err) => {
          console.log(err.message);
        }
      );
    },
    getSomeInfoFromServerByTwo() {
      axios.get("http://localhost:8080/albert1/WeatherForecast").then(
        (res) => {
          console.log(res.data);
        },
        (err) => {
          console.log(err.message);
        }
      );
    },
  },
};
</script>

<style>
/*base*/
body {
  background: #fff;
}
.btn {
  display: inline-block;
  padding: 4px 12px;
  margin-bottom: 0;
  font-size: 14px;
  line-height: 20px;
  text-align: center;
  vertical-align: middle;
  cursor: pointer;
  box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.2),
    0 1px 2px rgba(0, 0, 0, 0.05);
  border-radius: 4px;
}
.btn-danger {
  color: #fff;
  background-color: #da4f49;
  border: 1px solid #bd362f;
}
.btn-edit {
  color: #fff;
  background-color: #49da79;
  border: 1px solid #bd362f;
}
.btn-danger:hover {
  color: #fff;
  background-color: #bd362f;
}
.btn:focus {
  outline: none;
}
.todo-container {
  width: 600px;
  margin: 0 auto;
}
.todo-container .todo-wrap {
  padding: 10px;
  border: 1px solid #ddd;
  border-radius: 5px;
}
</style>
