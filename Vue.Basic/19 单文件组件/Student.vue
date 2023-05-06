<template>
    <!-- 组件结构 -->
    <div class="demo">
        <h2>学校名称：{{studentName }}</h2>
        <h2>学校地址：{{studentaddress }}</h2>
    </div>
</template>

<script>
// 默认暴露
export default {
    // 组件名称，防止别人串改（Vue开发者工具显示）
    name: 'Student',
    // 组件数据
    data() {
        return {
            studentName: '张三',
            studentaddress: '北京市海淀区'
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