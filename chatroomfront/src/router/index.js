import { Navigate,useRoutes } from 'react-router-dom'
import Login from '../views/login'
function RouterView() {
    const routes = useRoutes([
        {
            path: '/',
            element: <Navigate to='/login'/>
        },
        {
            path: '/login',
            element: <Login/>
        }
    ])
    return (<>{routes}</>)
}
export default RouterView