import { Routes, Route } from 'react-router-dom'
import Login from '../pages/auth/Login'
import Register from '../pages/auth/Register'
import ShoppingLists from '../pages/ShoppingLists'
import ProtectedRoutes from './ProtectedRoutes'
import PublicRoutes from './PublicRoutes'

const AppRoutes = () => (
    <Routes>
        {/* Protected Routes */}
        <Route path='/' element={<ProtectedRoutes />}>
            <Route path='/shoppinglists' element={<ShoppingLists />} />
        </Route>

        {/* Public Routes */}
        <Route path='/' element={<PublicRoutes />}>
            <Route path="/login" element={<Login />} />
            <Route path="/register" element={<Register />} />
        </Route>
    </Routes>
)

export default AppRoutes