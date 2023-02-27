import { useContext } from "react";
import { UserContext } from "./auth/authContext";
import { UserContextType } from "./auth/types/userContext.type";

const Profile = () => {
    const { currentUser } = useContext(UserContext) as UserContextType;
    
    return (
        <div>
            Logged in as {currentUser.username}
        </div>
    )
}

export default Profile;