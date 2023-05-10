<template>
  <div class="container">
    <el-container>
      <el-header>
        <Search />
      </el-header>
      <el-main>
        <UserInfoPage />
      </el-main>
    </el-container>
  </div>
</template>

<script>
import Search from "./components/Search.vue";
import UserInfoPage from "./components/UserInfoPage.vue";

export default {
  name: "App",
  components: { Search, UserInfoPage },
  data() {
    return {};
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
