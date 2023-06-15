// // 配置代理
const {createProxyMiddleware} = require('http-proxy-middleware')

module.exports = function (app) {
    app.use(
        createProxyMiddleware('/api',{
            target: 'http://localhost:5000',  //服务器地址
            changeOrigin: true,
            pathRewrite: {
                '^/api': ''
            }
        })
    )
}