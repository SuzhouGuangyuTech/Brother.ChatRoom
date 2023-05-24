<!--
  功能：功能描述
  作者：albertzhao
  邮箱：szdxzhy@outlook.com
  时间：2023年05月20日 15:05:54
  版本：v1.0
  修改记录：
  修改内容：
  修改人员：
  修改时间：
-->
<template>
  <div class="header">
    <div class="l-content">
      <el-button @click="changeCollapse" icon="el-icon-menu" size="mini"></el-button>
      <!-- 面包屑 -->
      <el-breadcrumb separator="/">
        <el-breadcrumb-item v-for="item in tabList" :key="item.path" :to="{ path: item.path }" :class="{ 'is-active': currentPath === item.path }">{{item.label}}
        </el-breadcrumb-item>
      </el-breadcrumb>
    </div>
    <div class="r-content">
      <el-dropdown>
        <span class="el-dropdown-link">
          <img src="../assets/logo.png" alt="" />
        </span>
        <el-dropdown-menu slot="dropdown">
          <el-dropdown-item>个人中心</el-dropdown-item>
          <el-dropdown-item>设备管理</el-dropdown-item>
          <el-dropdown-item>退出</el-dropdown-item>
        </el-dropdown-menu>
      </el-dropdown>
    </div>
  </div>
</template>

<script>
import { mapState } from "vuex";

export default {
  // 组件名称
  name: "CommonHeader",
  // 组件参数 接收来自父组件的数据
  props: {},
  // 局部注册的组件
  components: {},
  // 组件状态值
  data() {
    return {};
  },
  // 计算属性
  computed: {
    ...mapState("tab", ["isCollapse", "tabList"]),
    currentPath() {
      return this.$route.path;
    },
  },
  // 侦听器
  watch: {},
  // 组件方法
  methods: {
    changeCollapse() {
      this.$store.commit("tab/changeCollapse");
    },
  },
  mounted() {},
};
</script> 

<!-- Add "scoped" attribute to limit CSS to this component only -->
<!--使用了scoped属性之后，父组件的style样式将不会渗透到子组件中，-->
<!--然而子组件的根节点元素会同时被设置了scoped的父css样式和设置了scoped的子css样式影响，-->
<!--这么设计的目的是父组件可以对子组件根元素进行布局。-->
<style scoped lang="less">
.header {
  background-color: black;
  height: 60px;
  margin: 0px;
  padding: 0px 20px;
  // 容器内部内容两端显示
  display: flex;
  justify-content: space-between;
  // 纵轴垂直居中
  align-items: center;
  .text {
    color: white;
    font-size: 14px;
    margin-left: 10px;
  }
  .l-content {
    display: flex;
    align-items: center;
    .el-button {
      margin-right: 10px;
    }
    // 一般情况下，组件库为了避免组件之间的样式冲突，会将组件内部的元素作用域限定在组件内部，因此只有组件内部的样式才能影响到组件内部的元素。如果我们需要修改子组件内部的某个元素，就需要使用 CSS 样式穿透。样式穿透可以通过运用 >>> 或 /deep/ 操作符来实现。
    /deep/.el-breadcrumb__item {
      .el-breadcrumb__inner {
        font-weight: normal;
        &.is-link {
          color: #666;
        }
      }
      // 修改这里，如果当前路由路径与当前面包屑项路径相同，则添加'is-active'类名
      &.is-active {
        .el-breadcrumb__inner {
          color: #409eff;
        }
      }
      // &:last-child {
      //   .el-breadcrumb__inner {
      //     color: #409eff;
      //   }
      // }
    }
  }
  .r-content {
    img {
      width: 40px;
      height: 30px;
      border-radius: 50%;
    }
  }
}
</style>
