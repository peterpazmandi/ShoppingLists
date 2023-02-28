import { createContext, FC, useContext, useState } from "react";
import { ShoppingList } from "./entities/shoppinglist.entity";
import { getMyShoppingLists } from '../../../services/shoppingListService'
import { UserContext } from "../../auth/context/authContext";
import { UserContextType } from "../../auth/context/types/userContext.type";

type ShoppingListContextProps = {
    children: React.ReactNode;
};

export const ShoppingListContext = createContext({});

export const ShoppingListProvider: FC<ShoppingListContextProps> = (children: ShoppingListContextProps) => {
    const [isLoading, setIsLoading] = useState(false);
    const { currentUser } = useContext(UserContext) as UserContextType;
    const [shoppingLists, setShoppingLists] = useState([] as ShoppingList[])

    const getShoppingLists = () => {
        setIsLoading(true);
        getMyShoppingLists(currentUser.token).then(shoppingLists => {
            setIsLoading(false);
            setShoppingLists(shoppingLists);
        }, (error) => {
            setIsLoading(false);
        })
    }

    return <ShoppingListContext.Provider value={{
        isLoading,
        shoppingLists,
        getShoppingLists
    }}>
        {children.children}
    </ShoppingListContext.Provider>
}

export default ShoppingListProvider;