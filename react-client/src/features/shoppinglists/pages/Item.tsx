import { useContext, useEffect } from "react";
import { Item as ItemEntity } from "../context/entities/item.entity";
import { ShoppingListContext } from "../context/shoppingListContext";
import { ShoppingListContextType } from "../context/types/shoppingList.type";

interface Props {
    item: ItemEntity;
}

const Item = (props: Props) => {
    const { item } = props;
    const { shoppingLists, selectedShoppingList } = useContext(ShoppingListContext) as ShoppingListContextType;

    useEffect(() => {
        console.log(shoppingLists);
        console.log(selectedShoppingList);
    }, [])

    return (
        <div>
            { item.name }
        </div>
    )
}

export default Item;