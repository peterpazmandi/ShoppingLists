import { Routes, Route, Navigate } from 'react-router-dom'
import Login from '../features/auth/pages/Login'
import Register from '../features/auth/pages/Register'
import Profile from '../features/profile/pages/Profile'
import ShoppingLists from '../features/shoppinglists/pages/ShoppingLists'
import ProtectedRoutes from './ProtectedRoutes'
import PublicRoutes from './PublicRoutes'

const AppRoutes = () => (
    <Routes>
        {/* Protected Routes */}
        <Route path='/' element={<ProtectedRoutes />}>
            <Route path='/' element={<Navigate replace to="shoppinglists" />} />
            <Route path='/shoppinglists' element={<ShoppingLists />} />
            <Route path='/profile' element={<Profile />} />
        </Route>

        {/* Public Routes */}
        <Route path='/' element={<PublicRoutes />}>
            <Route path="/login" element={<Login />} />
            <Route path="/register" element={<Register />} />
        </Route>
    </Routes>
)

export default AppRoutes