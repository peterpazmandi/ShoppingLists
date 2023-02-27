import { User } from "../entities/user.entity"

export type UserContextType = {
    currentUser: User;
    getCurrentUser: () => User;
    updateCurrentUser: (user: User) => void;
}