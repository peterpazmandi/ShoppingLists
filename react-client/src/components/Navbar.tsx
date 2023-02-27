import { useContext } from "react";
import { Link } from "react-router-dom";
import { UserContext } from "../pages/auth/authContext";
import { UserContextType } from "../pages/auth/types/userContext.type";

const Navbar = () => {
    const { currentUser } = useContext(UserContext) as UserContextType;

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
                    <div className="d-flex">
                        <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                            <li className="nav-item">
                                <a className="nav-link" href="/profile">
                                    {currentUser.username}
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </nav>
    )
}

export default Navbar;