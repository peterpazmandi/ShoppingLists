import { useContext } from "react";
import { UserContext } from "../../auth/context/authContext";
import { UserContextType } from "../../auth/context/types/userContext.type";

const Profile = () => {
    const { currentUser } = useContext(UserContext) as UserContextType;
    
    return (
        <div>
            Logged in as {currentUser.username}
        </div>
    )
}

export default Profile;