<template>
  <div>
    <h1>学校信息</h1>
    <h2>学校名称:{{ school.name }}</h2>
    <h2>学校地址:{{ school.address }}</h2>
    <h2>学校年龄:{{ school.age }}</h2>
    <button @click="getSchoolInfo">获取学校信息</button>
    <button @click="stopGetSchoolInfo">取消绑定事件触发</button>
    <button @click="destroyVc">销毁当前组件实例 Vc</button>
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
        name: "苏州大学",
        address: "东环路 1 号",
        age: 120,
      },
    };
  },
  methods: {
    getSchoolInfo() {
      // 1. 通过 this.$emit('事件名', 参数) 触发事件
      this.$emit("getSchoolEvent", this.school);
    },
    stopGetSchoolInfo() {
      // 解绑事件，解绑一个自定义事件，如果想要解绑所有的自定义事件，需要写成数组的形式 ['事件名1', '事件名2']
      // this.$off() 直接解绑所有的自定义事件
      this.$off("getSchoolEvent");
    },
    destroyVc() {
      this.$destroy();
    },
  },
};
</script>