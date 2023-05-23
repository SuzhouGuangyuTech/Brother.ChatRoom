export default {
    // 想用命名空间的写法，必须开启命名空间
    namespaced: true,
    // state 用于共享的数据
    state: {
        // 侧边栏是否折叠
        isCollapse: false,
        //面包屑数组
        tabList: [{
            path: '/home',
            name: 'home',
            label: '首页',
            icon: 's-home',
            url: 'Home/Home'
        }],
    },
    mutations: {
        // 修改侧边栏折叠状态
        changeCollapse(state) {
            state.isCollapse = !state.isCollapse;
        },
        // 更新面包屑
        updateTab(state, item) {
            console.log('进来了');
            // 判断更新的数据是否是首页
            if (item.name !== 'home') {
                // 判断数组中是否存在该数据
                let result = state.tabList.findIndex(value => value.name === item.name);
                if (result === -1) {
                    state.tabList.push(item);
                    console.log(state.tabList);
                }
            }
        }
    },
    actions: {},
    getters: {}
}