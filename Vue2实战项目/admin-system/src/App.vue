<template>
  <div id="app">
    <el-container>
      <!-- 让折叠的时候侧边栏自动适应宽度 -->
      <el-aside width="auto">
        <CommonAside />
      </el-aside>
      <el-container>
        <el-header>
          <CommonHeader />
        </el-header>
        <el-main>
          <CommonTag />
          <div class="main-border">
            <router-view></router-view>
          </div>
        </el-main>
      </el-container>
    </el-container>
  </div>
</template>

<script>
import CommonAside from "@/components/CommonAside.vue";
import CommonHeader from "@/components/CommonHeader.vue";
import CommonTag from "@/components/CommonTag.vue";

export default {
  name: "App",
  components: { CommonAside, CommonHeader, CommonTag },
};
</script>

<style lang="less">
/* 清除默认样式，防止 el-menu 有边距 html, */
html,
body {
  height: 100%;
  width: 100%;
  margin: 0;
  padding: 0;
  overflow: hidden;
  color: #fff;

  .main-border {
    border: 1px solid #ccc;
    border-radius: 5px;
    padding: 10px;
  }
}
</style>
