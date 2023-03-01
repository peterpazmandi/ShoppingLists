import { ShoppingList } from "../entities/shoppinglist.entity";

export type ShoppingListContextType = {
    isLoading: boolean;
    shoppingLists: ShoppingList[];
    selectedShoppingList: ShoppingList;
    getShoppingLists: () => void;
    setSelectedShoppingList: React.Dispatch<React.SetStateAction<ShoppingList | undefined>>;
    updateSelectedShoppingListById: (id: number) => void;
}