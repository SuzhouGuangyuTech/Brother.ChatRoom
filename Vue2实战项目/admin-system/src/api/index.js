import http from '@/utils/request'

// 请求首页数据
export const getData = function getHomeData() {
    // 返回一个 Promise 对象
    return http.get('/home/getData')
}