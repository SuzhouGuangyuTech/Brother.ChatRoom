<template>
    <!-- 组件结构 -->
    <div class="demo">
        <h2>学校名称：{{schoolName }}</h2>
        <h2>学校地址：{{schooladdress }}</h2>
        <button @click="showName">点我提示学校名</button>
    </div>
</template>

<script>
// 默认暴露
export default {
    // 组件名称，防止别人串改（Vue开发者工具显示）
    name: 'School',
    // 组件数据
    data() {
        return {
            schoolName: '北京大学',
            schooladdress: '北京市海淀区'
        }
    },
    // 组件方法
    methods: {
        showName() {
            alert(this.schoolName);
        }
    }
}
</script>

<style>
/* 组件样式 */
.demo{
    border: 1px solid #ccc;
    padding: 10px;
    margin: 10px;
}
</style>