import { useContext, useEffect, useState } from "react";
import Checkbox from "../../../components/Checkbox";
import { Item as ItemEntity } from "../context/entities/item.entity";

interface Props {
    item: ItemEntity;
    setItemBoughtState: (id: number, bought: boolean) => void;
}

const Item = (props: Props) => {
    const { item, setItemBoughtState } = props;
    const [isChecked, setIsChecked] = useState(item.bought);

    const updateItemBoughtState = (checked: boolean) => {
        setIsChecked(checked);
        setItemBoughtState(item.id, checked);
    }

    return (
        <div className="d-flex justify-content-center">
            <div className="border border-1 rounded-3 shadow-lg mb-3 p-3 w-50">
                <div className="row">
                    <div className="col">
                        <div className="d-flex justify-content-start">                    
                            <figure>
                                <blockquote className="blockquote">
                                    <p>{item.name}</p>
                                </blockquote>
                                <figcaption className="blockquote-footer">
                                    {item.qty} {item.unit}
                                </figcaption>
                            </figure>
                        </div>
                    </div>
                    <div className="col d-flex align-items-center justify-content-end">
                        <Checkbox label={""} value={isChecked} onChange={(e) => updateItemBoughtState(e.target.checked)} />
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Item;