import { Navigate,useRoutes } from 'react-router-dom'
import Login from '../views/login/login'
import ChatRoom from '../views/chatroom'
function RouterView() {
    const routes = useRoutes([
        {
            path: '/',
            element: <Navigate to='/login'/>
        },
        {
            path: '/login',
            element: <Login/>
        },
        {
            path: '/chatroom',
            element: <ChatRoom/>
        }
    ])
    return (<>{routes}</>)
}
export default RouterView