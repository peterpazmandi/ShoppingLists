import { createContext, FC, useState } from "react";
import { USER } from "../../utils/globalConsts";
import { User } from "./entities/user.entity";

type UserContextProps = {
    children: React.ReactNode; //👈 children prop typr
  };
  

export const UserContext = createContext({});

export const UserProvider: FC<UserContextProps> = ( children: UserContextProps) => {
    const [currentUser, setCurrentUser] = useState<User>(localStorage.getItem(USER) ? JSON.parse(localStorage.getItem(USER)!) : null);

    const updateCurrentUser = (user: User) => {
        localStorage.setItem(USER, JSON.stringify(user));
        setCurrentUser(user);
    }

    return <UserContext.Provider value={{
                currentUser, updateCurrentUser }}>
            {children.children}
        </UserContext.Provider>
}

export default UserProvider;