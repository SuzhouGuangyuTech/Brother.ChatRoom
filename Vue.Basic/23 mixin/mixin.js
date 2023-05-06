// 分别暴露
export const mixinForVertion = {
    data() {
        return {
            version: '1.0.0'
        }
    },
    methods: {
        showName() {
            console.log(this.Name);
        },
    },
    mounted() {
        console.log('mounted');
    },
}

// export default const mixinForVertion = {} ,调用处不需要加 {} , 但是只能有一个