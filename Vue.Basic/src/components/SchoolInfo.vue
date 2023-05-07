<template>
  <div>
    <h1>学校信息</h1>
    <h2>学校名称:{{ school.name }}</h2>
    <h2>学校地址:{{ school.address }}</h2>
    <h2>学校年龄:{{ school.age }}</h2>
    <button @click="getSchoolInfo">获取学校信息</button>
  </div>
</template>

<script>
export default {
  // 组件名字
  name: "SchoolInfo",
  // 必须要写成函数，返回不同实例
  data() {
    return {
      // 属性的优先级更高，会将 studentAge 附加在 this(vc)身上，这时候 Age 就可以拿到 this.studentAge
      school: {
        name: "school",
        address: "苏州大学",
        age: 120,
      },
    };
  },
  methods: {
    getSchoolInfo() {
      // 1. 通过 this.$emit('事件名', 参数) 触发事件
      this.$emit("getSchoolEvent", this.school);
    },
  },
};
</script>