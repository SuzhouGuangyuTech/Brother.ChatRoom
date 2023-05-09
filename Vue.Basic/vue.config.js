const { defineConfig } = require('@vue/cli-service')
module.exports = defineConfig({
  transpileDependencies: true,
  // 方式一：开启代理服务，转到后端服务器【优先匹配前端资源】
  // devServer: {
  //   proxy: 'http://localhost:5280'
  // }

  // 方式二：开启代理服务，转到后端服务器【加前缀方式】
  devServer: {
    proxy: {
      '/albert1': { // 匹配所有以 '/albert1'开头的请求路径
        target: 'http://localhost:5280', // 代理目标的基础路径
        pathRewrite: { '^/albert1': '' }, // 代理往后端服务器的请求去掉 /albert1 前缀
        // ws: true,												// WebSocket 默认为 false
        // changeOrigin: true,							// 用于控制请求头中的 host 值，如果是 true 就关闭自己服务器端口来源，和最终请求的服务器保持一直（说谎），改为 false 则如实回答，不说谎。

      },
      '/demo': {
        target: 'http://localhost:5281',
        pathRewrite: { '^/demo': '' },
        changeOrigin: true
      }
    }
  }

})