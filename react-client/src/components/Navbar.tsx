import { useContext } from "react";
import { UserContext } from "../features/auth/context/authContext";
import { UserContextType } from "../features/auth/context/types/userContext.type";
import { AiOutlineLogout } from 'react-icons/ai';
import { FaPlusCircle } from 'react-icons/fa';
import { useNavigate, useLocation } from "react-router-dom";
import { ShoppingListContext } from "../features/shoppinglists/context/shoppingListContext";
import { BsFillPencilFill, BsTrashFill } from 'react-icons/bs'
import { ShoppingListContextType } from "../features/shoppinglists/context/types/shoppingList.type";
import { ModalContext } from "./modal/context/modalContext";
import { ModalContextType } from "./modal/type/modelContext.type";

const Navbar = () => {
    const navigate = useNavigate();
    const location = useLocation();
    
    const { currentUser, logOut } = useContext(UserContext) as UserContextType;
    const { selectedShoppingList } = useContext(ShoppingListContext) as ShoppingListContextType;
    const { createShoppingList } = useContext(ModalContext) as ModalContextType;

    const logOutUser = () => {
        logOut();
        navigate('/login');
    }

    return (
        <nav className="navbar navbar-expand-lg bg-light">
            <div className="container-fluid">
                <a className="navbar-brand" href="/shoppinglists">Shopping Lists</a>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                        <li className="nav-item">
                            <a className="nav-link active" aria-current="page" href="/shoppinglists">Home</a>
                        </li>
                    </ul>
                    { selectedShoppingList &&
                        <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                            <li className="nav-item">
                                <a className="nav-link active" aria-current="page" href="/shoppinglists"><BsFillPencilFill /> Edit</a>
                            </li>
                            <li className="nav-item">
                                <a className="nav-link active" aria-current="page" href="/shoppinglists"><BsTrashFill /> Delete</a>
                            </li>
                        </ul>
                    }
                    { location.pathname === "/shoppinglists" &&
                        <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                            <li className="nav-item">
                                <button 
                                    className="nav-link btn btn-light"
                                    onClick={createShoppingList}>
                                    <FaPlusCircle /> Create
                                </button>
                            </li>
                        </ul>
                    }
                    <span className="navbar-text">
                        <a className="nav-link" href="/profile">
                            {currentUser.username}
                        </a>
                    </span>
                    <button
                        className="navbar-text btn btn-light"
                        onClick={logOutUser}>
                        <AiOutlineLogout />
                    </button>
                </div>
            </div>
        </nav>
    )
}

export default Navbar;