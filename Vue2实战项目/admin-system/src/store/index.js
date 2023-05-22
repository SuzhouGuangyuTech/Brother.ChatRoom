import Vue from 'vue'
import Vuex from 'vuex' // 引入Vuex
import tab from './tab'

Vue.use(Vuex) // 应用Vuex插件

// 创建并暴露store
export default new Vuex.Store({
    modules: {
        tab
    }
})