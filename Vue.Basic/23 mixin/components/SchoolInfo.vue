<template>
  <div>
    <h2 @click="showName">学校名称:{{ Name }}</h2>
    <h2>学校年龄:{{ schoolAge }}</h2>
  </div>
</template>

<script>
// 分别暴露，这波需要加 {}，不然会报错
import { mixinForVertion } from "../mixin.js";

export default {
  // 组件名字
  name: "StudentInfo",
  // 必须要写成函数，返回不同实例
  data() {
    return {
      // 属性的优先级更高，会将 studentAge 附加在 this(vc)身上，这时候 Age 就可以拿到 this.studentAge
      Name: "清华大学",
      schoolAge: 110,
    };
  },
  methods: {
    showName() {
      console.log(this.Name);
    },
  },
  mixins: [mixinForVertion],
};
</script>