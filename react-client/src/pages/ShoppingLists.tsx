import { useContext } from "react";
import { UserContext } from "./auth/authContext";
import { UserContextType } from "./auth/types/user.type";

const ShoppingLists = () => {
    const { currentUser } = useContext(UserContext) as UserContextType;

    return (
        <div>
            { currentUser.username }
        </div>
    )
}

export default ShoppingLists;