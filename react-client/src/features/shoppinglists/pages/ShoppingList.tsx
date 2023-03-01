import { useContext, useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { number } from "yup";
import { ShoppingListContext } from "../context/shoppingListContext";
import { ShoppingListContextType } from "../context/types/shoppingList.type";
import Item from './Item'

const ShoppingList = () => {
    const { id } = useParams();
    const { shoppingLists, selectedShoppingList, updateSelectedShoppingListById } = useContext(ShoppingListContext) as ShoppingListContextType;

    useEffect(() => {
        console.log(shoppingLists);
        console.log(selectedShoppingList);
        if (selectedShoppingList === undefined && id !== undefined) {
            updateSelectedShoppingListById(Number.parseInt(id));
        }
    }, [])

    return (
        <div>
            { selectedShoppingList 
                ? (
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
                : (
                    <div></div>
                )
            }
            
        </div>
    )
}

export default ShoppingList;