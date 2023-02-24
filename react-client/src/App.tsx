import { useRef } from 'react';
import './App.css';
import { register } from './services/shoppingListService'
import { RegisterRequest } from './services/types/auth/registerRequest';
import { useEffect } from 'react'
import { ToastContainer, toast } from 'react-toastify';
import AppRoutes from './routes/AppRoutes'

function App() {
  const initialized = useRef(false);

  useEffect(() => {
    if (!initialized.current) {
      initialized.current = true;
      
      // register({
      //   email: 'test@test.test',
      //   username: 'testUser',
      //   password: 'Pa$$w0rd'
      // } as RegisterRequest).then(response => {
      //   console.log(response);
      // });
    }
  });

  return (
    <div className="App">
      <AppRoutes />
      <ToastContainer />
    </div>
  );
}

export default App;
