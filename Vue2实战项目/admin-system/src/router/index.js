//该文件专门用于创建整个应用的路由器
import VueRouter from "vue-router";
import Home from "@/pages/Home";
import User from '@/pages/User';
import Mall from '@/pages/Mall';
import PageOne from '@/pages/PageOne';
import PageTwo from '@/pages/PageTwo';

// 解决ElementUI导航栏中的vue-router在3.0版本以上重复点菜单报错问题
const originalPush = VueRouter.prototype.push
VueRouter.prototype.push = function push(location) {
    return originalPush.call(this, location).catch(err => err)
}


//创建并默认暴露一个路由器
export default new VueRouter({
    routes: [{
        path: '/home',
        name: 'home',
        component: Home,
    },
    {
        path: '/user',
        name: 'user',
        component: User,
    },
    {
        path: '/mall',
        name: 'mall',
        component: Mall,
    },
    {
        path: '/page1',
        name: 'pageOne',
        component: PageOne,
    },
    {
        path: '/page2',
        name: 'pageTwo',
        component: PageTwo,
    },
    ]
});