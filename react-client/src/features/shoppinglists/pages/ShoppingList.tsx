import { useContext, useEffect, useRef } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { ShoppingListContext } from "../context/shoppingListContext";
import { ShoppingListContextType } from "../context/types/shoppingList.type";
import Item from './Item'

const ShoppingList = () => {
    const initialized = useRef(false);
    const { id } = useParams();
    const navigate = useNavigate();
    const { selectedShoppingList, getSelectedShoppingList } = useContext(ShoppingListContext) as ShoppingListContextType;

    useEffect(() => {
        if(!initialized.current) {
            initialized.current = true;

            if (selectedShoppingList === undefined && id !== undefined && Number.isInteger(Number(id))) {
                console.log(id);
                getSelectedShoppingList(Number.parseInt(id)).then(result => {
                    if (!result) {
                        navigate("/");
                    }
                });
            }
        }
    }, [])

    return (
        <div>
            { selectedShoppingList &&
                (
                    <div>
                        <h1>{selectedShoppingList.title}</h1>
                        <div>
                            {
                                selectedShoppingList.items.map((item) => {
                                    return <Item key={item.id} item={item}/>
                                })
                            }
                        </div>
                    </div>
                )
            }
            
        </div>
    )
}

export default ShoppingList;