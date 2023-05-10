// 导入Vue和Vuex
import Vue from 'vue'
import Vuex from 'vuex'

// 应用插件
Vue.use(Vuex)

// 准备actions——用于响应组件中的动作
const actions = {
    // 这边的 context 上下文 miniStore
    increment(context, value) {
        console.log('actions中的increment被调用了', context, value)
        // 提交到 Mutations 中去
        context.commit('INCREMENT', value)
    }
}

// 准备mutations——用于操作数据（state）,一般都是大写
const mutations = {
    // INCREMENT
}

// 准备state——用于存储数据
const state = {
    sum: 0, // 当前的和
}

// 创建并暴露store
export default new Vuex.Store({
    actions, // 响应组件中的动作
    mutations, // 操作数据
    state, // 存储数据
})