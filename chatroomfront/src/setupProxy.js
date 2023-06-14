// // 配置代理
// const proxy = require('http-proxy-middleware')

// module.exports = function (app) {
//     app.use(
//         proxy('/api',{
//             target: '',  //服务器地址
//             changeOrigin: true,
//             pathRewrite: {
//                 '^/api': ''
//             }
//         })
//     )
// }