import { useContext, useEffect, useRef } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { sortBy } from "../../../utils/extensions/array.extension";
import { ShoppingList as ShoppingListEntity } from "../context/entities/shoppinglist.entity";
import { ShoppingListContext } from "../context/shoppingListContext";
import { ShoppingListContextType } from "../context/types/shoppingList.type";
import Item from './Item'

const ShoppingList = () => {
    const initialized = useRef(false);
    const { id } = useParams();
    const navigate = useNavigate();
    const { selectedShoppingList, setSelectedShoppingList, getSelectedShoppingList } = useContext(ShoppingListContext) as ShoppingListContextType;

    useEffect(() => {
        if(!initialized.current) {
            initialized.current = true;

            if (selectedShoppingList === undefined && id !== undefined && Number.isInteger(Number(id))) {
                getSelectedShoppingList(Number.parseInt(id)).then(result => {
                    if (!result) {
                        navigate("/");
                    }
                });
            }
        }
    }, [])

    useEffect(() => {
        console.log(selectedShoppingList);
    }, [selectedShoppingList])
    
    const setItemBoughtState = (id: number, bought: boolean) => {
        const item = selectedShoppingList.items.find(i => i.id === id);
        item!.bought = bought;
        const newList = {
            id: selectedShoppingList.id,
            title: selectedShoppingList.title,
            items: selectedShoppingList.items,
            modified: selectedShoppingList.modified,
            members: selectedShoppingList.members
        } as ShoppingListEntity;
        sortItemByBoughtState(newList);
        setSelectedShoppingList(newList);
    }

    const sortItemByBoughtState = (list: ShoppingListEntity) => {
        const sortedA = sortBy(selectedShoppingList.items, i => i.bought);

        console.log(sortedA);
    }

    return (
        <div>
            { selectedShoppingList &&
                (
                    <div>
                        <h1 className="m-4">{selectedShoppingList.title}</h1>
                        <div>
                            {
                                selectedShoppingList.items.map((item) => {
                                    return <Item key={item.id} item={item} setItemBoughtState={setItemBoughtState}/>
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