import './css/ShoppingList.css'
import { ShoppingList as ShoppingListEntity} from "../context/entities/shoppinglist.entity";
import { useNavigate } from 'react-router-dom';
import { useContext } from 'react';
import { ShoppingListContext } from '../context/shoppingListContext';
import { ShoppingListContextType } from '../context/types/shoppingList.type';
import { TiInputChecked } from 'react-icons/ti'

interface Props {
    shoppingList: ShoppingListEntity;
}

export const ShoppingListItem = (props: Props) => {
    const { setSelectedShoppingList } = useContext(ShoppingListContext) as ShoppingListContextType;
    const { shoppingList } = props;
    const navigate = useNavigate();

    const openShoppingList = () => {
        setSelectedShoppingList(shoppingList);
        navigate(`/shoppinglists/${shoppingList.id}`);
    }

    return (
        <div className="border border-1 rounded-3 shadow-lg mb-3 p-3">
            <div className="row">
                <div className="col d-flex justify-content-start">
                    <div>
                        <span className="title" onClick={openShoppingList}>
                            <h3>{shoppingList.title}</h3>
                        </span>
                        <p className='d-flex justify-content-start'>
                            Items: {shoppingList.items.length} / {shoppingList.items.filter((item) => item.bought).length}
                        </p>
                    </div>
                    <div>
                    </div>
                </div>
                { shoppingList.items.filter(i => i.bought).length === shoppingList.items.length &&
                    <div className="col d-flex justify-content-end">
                    <div className="done-icon">
                        <span>
                            <TiInputChecked size={68} color="lightgreen" />
                        </span>
                    </div>
                    </div>
                }
            </div>
        </div>
    )
}