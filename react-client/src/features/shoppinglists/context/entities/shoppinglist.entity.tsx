import { Item } from "./item.entity";

export interface ShoppingList {
    id: number;
    title: string;
    created: Date;
    modified: Date;
    members: string[];
    items: Item[];
}