import './App.css';
import { ToastContainer } from 'react-toastify';
import AppRoutes from './routes/AppRoutes'
import { UserContext } from './features/auth/context/authContext'
import Navbar from './components/Navbar';
import { useContext } from 'react';
import { UserContextType } from './features/auth/context/types/userContext.type';
import Modal from './components/modal/Modal';
import { ModalContext } from './components/modal/context/modalContext';
import { ModalContextType } from './components/modal/type/modelContext.type';

export default function App() {
  const { currentUser } = useContext(UserContext) as UserContextType;
  const { showModal } = useContext(ModalContext) as ModalContextType;
  
  return (
    <div className="App">
      { currentUser && <Navbar /> }
      <AppRoutes />
      <ToastContainer />
      { showModal && <Modal /> }
    </div>
  );
}