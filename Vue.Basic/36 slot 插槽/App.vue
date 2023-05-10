<template>
  <div class="container">
    <el-container>
      <el-header>
        Welcome to use vue
      </el-header>
      <el-main>
        <Category title="美食" :listData="foods">
          <template v-slot:header>
            <h3>美食</h3>
          </template>
        </Category>
        <Category title="游戏" :listData="games" />
        <Category title="电影" :listData="films" />
      </el-main>
    </el-container>
  </div>
</template>

<script>
import Category from "./components/Category.vue";

export default {
  name: "App",
  components: { Category },
  data() {
    return {
      foods: ["火锅", "烧烤", "小龙虾", "牛排"],
      games: ["红色警戒", "穿越火线", "劲舞团", "超级玛丽"],
      films: ["《教父》", "《拆弹专家》", "《你好，李焕英》", "《投资征途》"],
    };
  },
  methods: {},
};
</script>

<style>
.el-header {
  background-color: #b3c0d1;
  color: #333;
  text-align: center;
  line-height: 30%;
  padding-bottom: 30px;
}
.el-main {
  background-color: #e9eef3;
  color: #333;
  text-align: center;
  line-height: 70%;
}
</style>
