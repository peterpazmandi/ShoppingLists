import { useContext, useEffect } from "react";
import { ShoppingList as ShoppingListEntity} from "../context/entities/shoppinglist.entity";
import { ShoppingListContext } from "../context/shoppingListContext";
import { ShoppingListContextType } from "../context/types/shoppingList.type";
import { ShoppingListItem } from "./ShoppingListItem";

const ShoppingLists = () => {
    const { shoppingLists, getShoppingLists } = useContext(ShoppingListContext) as ShoppingListContextType;

    useEffect(() => {
        getShoppingLists();
    }, [])

    return (
        <div className="mt-3">
            { shoppingLists.length > 0 && shoppingLists.map((shoppingList: ShoppingListEntity) => {
                return (
                    <div className="container" key={shoppingList.id}>
                        <ShoppingListItem key={shoppingList.id} shoppingList={shoppingList} />
                    </div>
                )
            }) }
        </div>
    )
}

export default ShoppingLists;