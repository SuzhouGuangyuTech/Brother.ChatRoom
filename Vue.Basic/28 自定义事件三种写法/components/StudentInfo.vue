<template>
  <div>
    <h1>学生信息</h1>
    <h2>学生名称:{{ student.name }}</h2>
    <h2>学生地址:{{ student.address }}</h2>
    <h2>学生年龄:{{ student.age }}</h2>
    <button @click="getStudentInfo">获取学生信息</button>
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
      student: {
        name: "张三",
        address: "fadfasf",
        age: 10,
      },
    };
  },
  methods: {
    getStudentInfo() {
      console.log("getStudentInfo");
      this.$emit("getStudentEvent", this.student);
    },
  },
};
</script>