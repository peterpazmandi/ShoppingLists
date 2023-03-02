import { User } from '../features/auth/context/entities/user.entity';
import { ShoppingList } from '../features/shoppinglists/context/entities/shoppinglist.entity';
import { apiClient } from './shoppingListApiClient';
import { LoginRequest } from './types/auth/loginRequest';
import { RegisterRequest } from './types/auth/registerRequest';
import { UpdateItemBoughtStateRequest } from './types/item/updateItemBoughtStateRequest';

const tokenConfig = {
    headers: {
        Authorization: ''
    }
  };

export const register = async (registerRequest: RegisterRequest) => {
    return await apiClient.post('/account/register', registerRequest);
}

export const login = async (loginRequest: LoginRequest) => {
    return (await apiClient.post('/account/login', loginRequest)).data as User;
}

export const getMyShoppingLists = async(token: string) => {
    tokenConfig.headers.Authorization = `Bearer ${token}`;
    return (await apiClient.get(`/shoppinglist/getmyshoppinglists`, tokenConfig)).data as ShoppingList[];
}

export const getShoppingListById = async (id: number, token: string) => {
    tokenConfig.headers.Authorization = `Bearer ${token}`;
    return (await apiClient.get(`/shoppinglist/getshoppinglistbyid?id=${id}`, tokenConfig)).data as ShoppingList;
}

export const updateItemBoughtStateById =async (updateItemBought: UpdateItemBoughtStateRequest, token: string) => {
    tokenConfig.headers.Authorization = `Bearer ${token}`;
    return (await apiClient.post('/item/updateitemboughtstatebyid', updateItemBought, tokenConfig)).data;
}