import { useContext } from 'react';
import { Navigate, Outlet } from 'react-router-dom'
import { UserContext } from '../pages/auth/authContext';
import { UserContextType } from '../pages/auth/types/user.type';

const useAuth = () => {
    const { currentUser } = useContext(UserContext) as UserContextType;

    if(currentUser) {
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