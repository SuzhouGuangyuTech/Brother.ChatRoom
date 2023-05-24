import Mock from 'mockjs'
import homeData from './mockData/home.js'
// 定义 mock 请求拦截
Mock.mock("/api/home/getData", 'get', homeData.getStatisticalData);