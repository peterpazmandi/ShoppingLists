import { LoginEntity } from "../entities/login.entity";
import { User } from "../entities/user.entity"

export type UserContextType = {
    isLoading: boolean;
    currentUser: User;
    getCurrentUser: () => User;
    login: (data: LoginEntity) => Promise<boolean>;
    logOut: () => void;
}