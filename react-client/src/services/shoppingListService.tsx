import {apiClient} from './shoppingListApiClient';
import { RegisterRequest } from './types/auth/registerRequest';

export const register = async (registerRequest: RegisterRequest) => {
    return await apiClient.post('/account/register', registerRequest);
}