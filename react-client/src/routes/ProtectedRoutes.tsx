import { Navigate, Outlet } from 'react-router-dom'
import { USER } from '../utils/globalConsts'

const useAuth = () => {
    let user: any;

    const _user = localStorage.getItem(USER);

    if (_user) {
        user = JSON.parse(_user);
        console.log(user);
    }

    if(user) {
        return {
            auth: true,
            role: null
        }
    } else {
        return {
            auth: false,
            role: null
        }
    }
}

type ProtectedRouteType = {
    roleRequired?: "ADMIN" | "USER"
}

const ProtectedRoutes = (props: ProtectedRouteType) => {
    const { auth, role } = useAuth();
    if(props.roleRequired) {
        return auth ? (
            props.roleRequired === role ? <Outlet /> : <Navigate to="/denied" />
        ) : (
            <Navigate to="/login" />
        )
    } else {
        return auth ? <Outlet /> : <Navigate to="/login" />
    }
}

export default ProtectedRoutes