<template>
  <div>
    <h1>学校</h1>
    <h2>学校名称:{{ schoolName }}</h2>
    <h2>学校地址:{{ schoolAddress }}</h2>
  </div>
</template>

<script>
export default {
  // 组件名字
  name: "SchoolInfo",
  // 必须要写成函数，返回不同实例
  data() {
    return {
      schoolName: "北京大学",
      schoolAddress: "北京市海淀区",
    };
  },
};
</script>