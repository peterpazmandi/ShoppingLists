import { createContext, FC, useState } from "react";


type ModalContextProps = {
    children: React.ReactNode;
};


export const ModalContext = createContext({});

export const ModalProvider: FC<ModalContextProps> = (children: ModalContextProps) => {
    const [showModal, setShowModal] = useState(false);
    
    const createShoppingList = () => {
        setShowModal(true);
    }

    const closeModal = () => {
        setShowModal(false);
    }

    return (
        <ModalContext.Provider value={{
            showModal, 
            closeModal,
            createShoppingList
            }}>
            {children.children}
        </ModalContext.Provider>
    )
}

export default ModalProvider;