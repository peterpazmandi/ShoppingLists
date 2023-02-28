import './App.css';
import { ToastContainer } from 'react-toastify';
import AppRoutes from './routes/AppRoutes'
import { UserContext } from './features/auth/context/authContext'
import Navbar from './components/Navbar';
import { useContext } from 'react';
import { UserContextType } from './features/auth/context/types/userContext.type';

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