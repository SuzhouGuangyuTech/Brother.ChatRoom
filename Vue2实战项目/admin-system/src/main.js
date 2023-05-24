import Vue from 'vue'
import App from './App.vue'

// 引入 element-ui
import ElementUI from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css';
//引入vue-router
import VueRouter from "vue-router";
import router from './router';
// 引入 store，这边可以不写 index.js，vue 脚手架会默认解析文件夹下的 index.js 文件
import store from './store'
import './api/mock'

// 全局配置element-ui 弹窗移除遮罩层不关闭
ElementUI.Dialog.props.closeOnClickModal.default = false;

Vue.use(ElementUI);
Vue.use(VueRouter);

Vue.config.productionTip = false

new Vue({
  render: h => h(App),
  router,
  store
}).$mount('#app')