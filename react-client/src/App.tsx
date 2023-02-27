import './App.css';
import { ToastContainer, toast } from 'react-toastify';
import AppRoutes from './routes/AppRoutes'
import { UserProvider } from './pages/auth/authContext'

export default function App() {
  return (
    <UserProvider>
      <div className="App">
        <AppRoutes />
        <ToastContainer />
      </div>
    </UserProvider>
  );
}