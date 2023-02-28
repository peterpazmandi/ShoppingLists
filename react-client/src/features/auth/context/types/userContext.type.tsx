import { LoginRequest } from "../entities/loginRequest.entity";
import { User } from "../entities/user.entity"

export type UserContextType = {
    isLoading: boolean;
    currentUser: User;
    getCurrentUser: () => User;
    login: (data: LoginRequest) => Promise<boolean>;
    logOut: () => void;
}