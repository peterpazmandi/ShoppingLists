import {apiClient} from './shoppingListApiClient';
import { LoginRequest } from './types/auth/loginRequest';
import { RegisterRequest } from './types/auth/registerRequest';

export const register = async (registerRequest: RegisterRequest) => {
    return await apiClient.post('/account/register', registerRequest);
}

export const login =async (loginRequest: LoginRequest) => {
    return await apiClient.post('/account/login', loginRequest);
}