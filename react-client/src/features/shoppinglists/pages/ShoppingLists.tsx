import { useContext, useEffect } from "react";
import { UserContext } from "../../auth/context/authContext";
import { UserContextType } from "../../auth/context/types/userContext.type";
import { ShoppingList as ShoppingListEntity} from "../context/entities/shoppinglist.entity";
import { ShoppingListContext } from "../context/shoppingListContext";
import { ShoppingListContextType } from "../context/types/shoppingList.type";
import { ShoppingList } from "./ShoppingList";

const ShoppingLists = () => {
    const { currentUser } = useContext(UserContext) as UserContextType;
    const { shoppingLists, getShoppingLists } = useContext(ShoppingListContext) as ShoppingListContextType;

    useEffect(() => {
        getShoppingLists();
    }, [])

    return (
        <div className="mt-3">
            { shoppingLists.length > 0 && shoppingLists.map((shoppingList: ShoppingListEntity) => {
                return (
                    <div className="container">
                        <ShoppingList key={shoppingList.id} shoppingList={shoppingList} />
                    </div>
                )
            }) }
        </div>
    )
}

export default ShoppingLists;