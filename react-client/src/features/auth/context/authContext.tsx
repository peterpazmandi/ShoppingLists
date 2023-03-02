import { createContext, FC, useState } from "react";
import { USER } from "../../../utils/globalConsts";
import { User } from "./entities/user.entity";
import { login as loginUser } from '../../../services/shoppingListService'
import { LoginRequest } from "../../../services/types/auth/loginRequest";

type UserContextProps = {
    children: React.ReactNode; //👈 children prop typr
  };
  

export const UserContext = createContext({});

export const UserProvider: FC<UserContextProps> = ( children: UserContextProps) => {
    const [isLoading, setIsLoading] = useState(false);

    const [currentUser, setCurrentUser] = useState<User | null>(
        localStorage.getItem(USER) 
            ? JSON.parse(localStorage.getItem(USER)!) 
            : null);

    const login = (data: LoginRequest) => {
        setIsLoading(true);
        return loginUser(data).then(user => {
            setIsLoading(false);
            updateCurrentUser(user);
            return true;
        }, (error) => {
            return false;
        });
    }
    
    const logOut = () => {
        localStorage.removeItem(USER);
        setCurrentUser(null);
    }

    const updateCurrentUser = (user: User) => {
        localStorage.setItem(USER, JSON.stringify(user));
        setCurrentUser(user);
    }

    return <UserContext.Provider value={{
                isLoading,
                login, logOut,
                currentUser }}>
            {children.children}
        </UserContext.Provider>
}

export default UserProvider;