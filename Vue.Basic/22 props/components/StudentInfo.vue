<template>
  <div>
    <h1>学生信息</h1>
    <h2>学生名称:{{ studentName }}</h2>
    <h2>学校年龄:{{ Age }}</h2>
    <button @click="Age++">年龄+1</button>
  </div>
</template>

<script>
export default {
  // 组件名字
  name: "StudentInfo",
  // 必须要写成函数，返回不同实例
  data() {
    return {
      // 属性的优先级更高，会将 studentAge 附加在 this(vc)身上，这时候 Age 就可以拿到 this.studentAge
      Age: this.studentAge,
    };
  },
  // props 简单接收父组件传递的数据
  // props: ["studentName", "studentAge"],
  props: {
    studentName: {
      type: String,
      default: "张三", // 默认值
    },
    studentAge: {
      type: Number,
      required: true, // 必须要传递
    },
  },
};
</script>