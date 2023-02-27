import './App.css';
import { ToastContainer } from 'react-toastify';
import AppRoutes from './routes/AppRoutes'
import { UserContext, UserProvider } from './pages/auth/authContext'
import Navbar from './components/Navbar';
import { useContext, useEffect, useState } from 'react';
import { UserContextType } from './pages/auth/types/userContext.type';

export default function App() {
  const { currentUser } = useContext(UserContext) as UserContextType;
  
  return (
    <div className="App">
      { currentUser && <Navbar /> }
      <AppRoutes />
      <ToastContainer />
    </div>
  );
}