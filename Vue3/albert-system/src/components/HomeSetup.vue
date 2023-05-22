<template>
  <div>
    <h1>{{ name }}</h1>
    <h1>{{ count }}</h1>
    <h1>{{ ageAdd }}</h1>
    <button @click="ChangeName">改变</button>
  </div>
</template>
 
<script lang='ts'>
import { defineComponent, reactive, toRefs, ref, computed } from "vue";

interface IPerson {
  name: string;
  age: number;
}

export default defineComponent({
  name: "HomeSetup",
  setup() {
    // 实现接口-第一种写法
    // let user: IPerson = reactive({
    //   name: "张三",
    //   age: 18,
    // });

    // 实现接口-第二种写法
    // let user = reactive<IPerson>({
    //   name: "张三",
    //   age: 18,
    // });

    // 实现接口-第二种写法
    let user = reactive({
      name: "张三",
      age: 18,
    }) as IPerson;

    let count = ref<number>(0);

    function ChangeName() {
      user.name = "李四";
    }

    let ageAdd = computed((): number => {
      return user.age + 1;
    });

    return {
      // 可以直接使用 user 中的对象
      ...toRefs(user),
      ChangeName,
      count,
      ageAdd,
    };
  },
});
</script>
 
<style scoped>
</style>