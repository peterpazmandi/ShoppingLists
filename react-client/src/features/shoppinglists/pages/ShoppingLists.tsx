import { useContext, useEffect } from "react";
import { UserContext } from "../../auth/context/authContext";
import { UserContextType } from "../../auth/context/types/userContext.type";
import { ShoppingList } from "../context/entities/shoppinglist.entity";
import { ShoppingListContext } from "../context/shoppingListContext";
import { ShoppingListContextType } from "../context/types/shoppingList.type";

const ShoppingLists = () => {
    const { currentUser } = useContext(UserContext) as UserContextType;
    const { shoppingLists, getShoppingLists } = useContext(ShoppingListContext) as ShoppingListContextType;

    useEffect(() => {
        getShoppingLists();
    }, [])

    return (
        <div>
            {/* { shoppingLists.length > 0 && shoppingLists.map((shoppingList: ShoppingList) => {
                return (
                    <div>{shoppingList.title}</div>
                )
            }) } */}
        </div>
    )
}

export default ShoppingLists;