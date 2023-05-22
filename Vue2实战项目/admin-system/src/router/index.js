//该文件专门用于创建整个应用的路由器
import VueRouter from "vue-router";
import Main from "@/pages/Main";
import Home from "@/pages/Home";
import User from '@/pages/User';
import Mall from '@/pages/Mall';
import PageOne from '@/pages/PageOne';
import PageTwo from '@/pages/PageTwo';

//创建并默认暴露一个路由器
export default new VueRouter({
    routes: [{
        path: '/',
        component: Main,
        children: [{
            path: 'home',
            component: Home
        }, {
            path: 'user',
            component: User
        }, {
            path: 'mall',
            component: Mall
        }, {
            path: 'page1',
            component: PageOne
        }, {
            path: 'page2',
            component: PageTwo
        }]
    }

    ]
});