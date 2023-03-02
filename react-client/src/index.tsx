import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import {BrowserRouter} from 'react-router-dom'
import UserProvider from './features/auth/context/authContext';
import ShoppingListProvider from './features/shoppinglists/context/shoppingListContext';
import ModalProvider from './components/modal/context/modalContext';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <React.StrictMode>
    <BrowserRouter >
      <ModalProvider>
        <UserProvider>
          <ShoppingListProvider>
            <App />
          </ShoppingListProvider>
        </UserProvider>
      </ModalProvider>
    </BrowserRouter>
  </React.StrictMode>
);