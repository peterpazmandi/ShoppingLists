import { Suspense } from 'react'
import { Routes, Route, Navigate } from 'react-router-dom'
import Login from '../pages/Login'
import ShoppingLists from '../pages/ShoppingLists'
import ProtectedRoutes from './ProtectedRoutes'
import PublicRoutes from './PublicRoutes'

const AppRoutes = () => (
    <Routes>
        {/* Protected Routes */}
        <Route path='/' element={<ProtectedRoutes />}>
            <Route path='/' element={<ShoppingLists />} />
        </Route>

        {/* Public Routes */}
        <Route path='login' element={<PublicRoutes />}>
            <Route path="/login" element={<Login />} />
        </Route>
    </Routes>
)

export default AppRoutes