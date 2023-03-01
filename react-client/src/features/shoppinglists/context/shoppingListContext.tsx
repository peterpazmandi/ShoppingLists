import { createContext, FC, useContext, useState } from "react";
import { ShoppingList } from "./entities/shoppinglist.entity";
import { getMyShoppingLists, getShoppingListById } from '../../../services/shoppingListService'
import { UserContext } from "../../auth/context/authContext";
import { UserContextType } from "../../auth/context/types/userContext.type";
import { ShoppingList as ShoppingListEntity } from "../context/entities/shoppinglist.entity";

type ShoppingListContextProps = {
    children: React.ReactNode;
};

export const ShoppingListContext = createContext({});

export const ShoppingListProvider: FC<ShoppingListContextProps> = (children: ShoppingListContextProps) => {
    const [isLoading, setIsLoading] = useState(false);
    const { currentUser } = useContext(UserContext) as UserContextType;
    const [shoppingLists, setShoppingLists] = useState([] as ShoppingList[])
    const [selectedShoppingList, setSelectedShoppingList] = useState<ShoppingListEntity>();

    const getShoppingLists = () => {
        setIsLoading(true);
        getMyShoppingLists(currentUser.token).then(shoppingLists => {
            setIsLoading(false);
            setShoppingLists(shoppingLists);
        }, (error) => {
            setIsLoading(false);
        })
    }

    const getSelectedShoppingList = (id: number) => {
        return getShoppingListById(id, currentUser.token).then(shoppingList => {
            console.log(shoppingList);
            setSelectedShoppingList(shoppingList);
            return true;
        }, error => {
            return false;
        })
    }

    return <ShoppingListContext.Provider value={{
        isLoading,
        shoppingLists, selectedShoppingList,
        getShoppingLists, setSelectedShoppingList, getSelectedShoppingList
    }}>
        {children.children}
    </ShoppingListContext.Provider>
}

export default ShoppingListProvider;