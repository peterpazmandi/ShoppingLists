import axios from "axios";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const successToast = (message: string) => toast.success(message);
const errorToast = (message: string) => toast.error(message);

const USER_TOKEN = () => {
    localStorage.getItem('user');
}

const BASE_URL = "https://localhost:5001/api/";

export const apiClient = axios.create({
    baseURL: BASE_URL
})

apiClient.interceptors.response.use((response) => {
    return response.data;
}, (error) => {
    errorToast(error.response.data);
    throw error;
});