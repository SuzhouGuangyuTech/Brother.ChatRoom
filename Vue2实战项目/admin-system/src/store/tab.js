export default {
    // state 用于共享的数据
    state: {
        isCollapse: false // 侧边栏是否折叠
    },
    mutations: {
        // 修改侧边栏折叠状态
        changeCollapse(state) {
            state.isCollapse = !state.isCollapse;
        }
    },
    actions: {},
    getters: {}
}