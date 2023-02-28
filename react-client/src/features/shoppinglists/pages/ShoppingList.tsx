import './css/ShoppingList.css'
import { ShoppingList as ShoppingListEntity} from "../context/entities/shoppinglist.entity";
import { BsTrashFill, BsFillPencilFill } from "react-icons/bs";
import { Link } from 'react-router-dom';

interface Props {
    shoppingList: ShoppingListEntity;
}

export const ShoppingList = (props: Props) =>{
    const { shoppingList } = props;

    return (
        <div className="border border-1 rounded-3 shadow-lg mb-3 p-3">
            <div className="row">
                <div className="col">
                    <div className="d-flex justify-content-start">
                        <Link to="/">
                            <h3>{shoppingList.title}</h3>
                        </Link>
                    </div>
                    <div className="d-flex justify-content-start">
                        <p>Items: {shoppingList.items.length} / {shoppingList.items.filter((item) => item.bought).length}</p>
                    </div>
                </div>
                <div className="col d-flex align-items-center justify-content-end">
                    <div className="row">
                        <div className="col me-5">
                            <div className="edit-icon">
                                <span>
                                    <h1><BsFillPencilFill /></h1>
                                </span>
                            </div>
                        </div>
                        <div className="col me-5">
                            <div className="delete-icon">
                                <span>
                                    <h1><BsTrashFill/></h1>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    )
}