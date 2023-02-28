import { ShoppingList } from "../entities/shoppinglist.entity";

export type ShoppingListContextType = {
    isLoading: boolean;
    shoppingLists: ShoppingList[];
    getShoppingLists: () => void;
}