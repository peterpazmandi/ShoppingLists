import { useContext, useEffect, useRef } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { sortBy } from "../../../utils/extensions/array.extension";
import { ShoppingList as ShoppingListEntity } from "../context/entities/shoppinglist.entity";
import { ShoppingListContext } from "../context/shoppingListContext";
import { ShoppingListContextType } from "../context/types/shoppingList.type";
import Item from './Item'
import { toast } from 'react-toastify';

const successToast = (message: string) => toast.success(message);
const errorToast = (message: string) => toast.error(message);

const ShoppingList = () => {
    const initialized = useRef(false);
    const { id } = useParams();
    const navigate = useNavigate();
    const { selectedShoppingList, setSelectedShoppingList, getSelectedShoppingList, updateBoughtState } = useContext(ShoppingListContext) as ShoppingListContextType;

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
        updateBoughtState( { itemId: id, bought: bought }).then(response => {
            if (response) {
                const item = selectedShoppingList.items.find(i => i.id === id);
                const message = `${item!.name}: Updated succefully!`;
                successToast(message);

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
            } else {
                errorToast('Failed to update item!');
            }
        });
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