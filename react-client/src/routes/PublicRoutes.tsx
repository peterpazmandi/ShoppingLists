import { Navigate, Outlet } from 'react-router-dom';
import { USER } from '../utils/globalConsts';

const useAuth = () => {
    const user = localStorage.getItem(USER);

    return user ? true : false;
}

const PublicRoutes = () => {
    const auth = useAuth();

    return auth ? <Navigate to="/shoppinglists" /> : <Outlet />
}

export default PublicRoutes;