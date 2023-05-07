<template>
  <div>
    <h1>家乡信息</h1>
    <h2>家乡名称:{{ home.name }}</h2>
    <h2>家乡地址:{{ home.address }}</h2>
    <h2>家乡年龄:{{ home.age }}</h2>
    <button @click="showInfo">传递家乡信息给父组件</button>
  </div>
</template>

<script>
export default {
  // 组件名字
  name: "HomeInfo",
  // 必须要写成函数，返回不同实例
  data() {
    return {
      // 属性的优先级更高，会将 studentAge 附加在 this(vc)身上，这时候 Age 就可以拿到 this.studentAge
      home: {
        name: "xizhimen",
        address: "苏州市吴中区xxxx",
        age: 120,
      },
    };
  },
  props: ["showHomeInfo"],
  methods: {
    showInfo() {
      this.showHomeInfo(this.home);
    },
  },
};
</script>