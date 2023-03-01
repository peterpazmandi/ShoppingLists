import './css/ShoppingList.css'
import { ShoppingList as ShoppingListEntity} from "../context/entities/shoppinglist.entity";
import { useNavigate } from 'react-router-dom';
import { useContext } from 'react';
import { ShoppingListContext } from '../context/shoppingListContext';
import { ShoppingListContextType } from '../context/types/shoppingList.type';

interface Props {
    shoppingList: ShoppingListEntity;
}

export const ShoppingListItem = (props: Props) => {
    const { shoppingLists, setSelectedShoppingList } = useContext(ShoppingListContext) as ShoppingListContextType;
    const { shoppingList } = props;
    const navigate = useNavigate();

    const openShoppingList = () => {
        console.log(shoppingList);
        setSelectedShoppingList(shoppingList);
        navigate(`/shoppinglists/${shoppingList.id}`);
    }

    return (
        <div className="border border-1 rounded-3 shadow-lg mb-3 p-3">
            <div className="row d-flex justify-content-center">
                <div className="col">
                    <span className="title" onClick={openShoppingList}>
                        <h3>{shoppingList.title}</h3>
                    </span>                    
                    <p>
                        Items: {shoppingList.items.length} / {shoppingList.items.filter((item) => item.bought).length}
                    </p>
                </div>
            </div>
        </div>
    )
}